using System;
using MySql.Data.MySqlClient;

namespace sklad
{
    public class AuthService
    {
        private readonly DB _db;
        private int _failedAttempts = 0;
        private DateTime? _blockedUntil = null;

        public AuthService()
        {
            _db = new DB();
        }

        /// <summary>
        /// Проверяет, не заблокирован ли вход в данный момент
        /// </summary>
        private void CheckBlock()
        {
            if (_blockedUntil.HasValue && DateTime.Now < _blockedUntil.Value)
                throw new Exception($"Вход временно заблокирован до {_blockedUntil.Value:HH:mm:ss}. Попробуйте позже.");

            // Если время блокировки истекло – сбрасываем счётчик и блокировку
            if (_blockedUntil.HasValue && DateTime.Now >= _blockedUntil.Value)
            {
                _failedAttempts = 0;
                _blockedUntil = null;
            }
        }

        /// <summary>
        /// Регистрирует неудачную попытку, увеличивает счётчик и при необходимости блокирует вход
        /// </summary>
        private void RegisterFailure(string login, string reason)
        {
            _failedAttempts++;
            LogAttempt(login, false, reason);

            if (_failedAttempts >= 3)
            {
                _blockedUntil = DateTime.Now.AddSeconds(30);
                _failedAttempts = 0;
                throw new Exception("Вы исчерпали 3 попытки входа. Вход заблокирован на 30 секунд.");
            }
        }

        public User Login(string login, string password, string captchaInput, CaptchaService captcha)
        {
            // 1. Проверяем блокировку
            CheckBlock();

            // 2. Проверяем CAPTCHA (любая ошибка CAPTCHA увеличивает счётчик)
            if (!captcha.Validate(captchaInput))
            {
                RegisterFailure(login, "Неверная CAPTCHA");
                throw new Exception("Неверный код CAPTCHA.");
            }

            // 3. Ищем пользователя в БД
            string query = @"
                SELECT u.id, u.username, u.password, u.salt, u.role_id, r.role_name 
                FROM users u 
                JOIN roles r ON u.role_id = r.id 
                WHERE u.username = @login";

            MySqlCommand cmd = new MySqlCommand(query, _db.GetConnection());
            cmd.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;

            _db.openConnection();
            MySqlDataReader reader = cmd.ExecuteReader();
            bool found = reader.Read();
            string storedHash = "", storedSalt = "";
            int userId = 0;
            string roleName = "";
            int roleId = 0;
            if (found)
            {
                userId = reader.GetInt32(0);
                storedHash = reader.GetString(2);
                storedSalt = reader.GetString(3);
                roleId = reader.GetInt32(4);
                roleName = reader.GetString(5);
            }
            reader.Close();
            _db.closeConnection();

            // 4. Проверка логина/пароля
            if (!found || !PasswordHasher.Verify(password, storedSalt, storedHash))
            {
                RegisterFailure(login, "Неверный логин или пароль");
                throw new Exception("Неверный логин или пароль.");
            }

            // 5. Успешный вход – сбрасываем счётчик и блокировку
            _failedAttempts = 0;
            _blockedUntil = null;
            LogAttempt(login, true, "Успешный вход");

            return new User
            {
                Id = userId,
                Login = login,
                RoleId = roleId,
                RoleName = roleName
            };
        }

        private void LogAttempt(string login, bool success, string message)
        {
            string query = "INSERT INTO login_attempts (user_login, is_success, message, created_at) VALUES (@login, @success, @msg, @date)";
            MySqlCommand cmd = new MySqlCommand(query, _db.GetConnection());
            cmd.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            cmd.Parameters.Add("@success", MySqlDbType.Byte).Value = success ? 1 : 0;
            cmd.Parameters.Add("@msg", MySqlDbType.VarChar).Value = message;
            cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = DateTime.Now;
            _db.openConnection();
            cmd.ExecuteNonQuery();
            _db.closeConnection();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}