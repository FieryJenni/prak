using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace sklad
{
    public partial class RegistrForm : Form
    {
        public RegistrForm()
        {
            InitializeComponent();
        }

        // --- Обработчики подсказок для всех полей ---

        private void textBoxFIO_Enter(object sender, EventArgs e)
        {
            if (textBoxFIO.Text == "Иванов Иван Иванович")
            {
                textBoxFIO.Text = "";
                textBoxFIO.ForeColor = Color.Black;
            }
        }

        private void textBoxFIO_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFIO.Text))
            {
                textBoxFIO.Text = "Иванов Иван Иванович";
                textBoxFIO.ForeColor = Color.Gray;
            }
        }

        private void textBoxUserName_Enter(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == "ivanov")
            {
                textBoxUserName.Text = "";
                textBoxUserName.ForeColor = Color.Black;
            }
        }

        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserName.Text))
            {
                textBoxUserName.Text = "ivanov";
                textBoxUserName.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "example@mail.com")
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                textBoxEmail.Text = "example@mail.com";
                textBoxEmail.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "пароль")
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.Black;
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.Text = "пароль";
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void textBoxConfirimPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxConfirimPassword.Text == "пароль")
            {
                textBoxConfirimPassword.Text = "";
                textBoxConfirimPassword.ForeColor = Color.Black;
                textBoxConfirimPassword.UseSystemPasswordChar = true;
            }
        }

        private void textBoxConfirimPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxConfirimPassword.Text))
            {
                textBoxConfirimPassword.UseSystemPasswordChar = false;
                textBoxConfirimPassword.Text = "пароль";
                textBoxConfirimPassword.ForeColor = Color.Gray;
            }
        }

        // --- Навигация на форму входа ---
        private void labelToGoLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        // --- Регистрация ---
        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            string fio = textBoxFIO.Text.Trim();
            string login = textBoxUserName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text;
            string confirm = textBoxConfirimPassword.Text;

            // Проверки (как были, плюс минимальная длина пароля)
            if (fio == "Иванов Иван Иванович" || string.IsNullOrEmpty(fio)) { MessageBox.Show("Введите ФИО."); return; }
            if (login == "ivanov" || string.IsNullOrEmpty(login)) { MessageBox.Show("Введите логин."); return; }
            if (email == "example@mail.com" || string.IsNullOrEmpty(email)) { MessageBox.Show("Введите email."); return; }
            if (password == "пароль" || string.IsNullOrEmpty(password)) { MessageBox.Show("Введите пароль."); return; }
            if (confirm == "пароль" || string.IsNullOrEmpty(confirm)) { MessageBox.Show("Подтвердите пароль."); return; }
            if (password != confirm) { MessageBox.Show("Пароли не совпадают."); return; }
            if (password.Length < 4) { MessageBox.Show("Пароль должен быть не менее 4 символов."); return; }

            // Генерация соли и хэша
            string salt = PasswordHasher.GenerateSalt();
            string hash = PasswordHasher.HashPassword(password, salt);

            DB db = new DB();
            MySqlCommand command = new MySqlCommand(
                "INSERT INTO `users` (`FIO`, `emailaddress`, `username`, `password`, `salt`, `role_id`) VALUES (@fio, @email, @usn, @pass, @salt, 2)",
                db.GetConnection());

            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = fio;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = hash;
            command.Parameters.Add("@salt", MySqlDbType.VarChar).Value = salt;

            db.openConnection();
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт создан!");
                    this.Hide();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
                else MessageBox.Show("Ошибка при создании.");
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) MessageBox.Show("Логин уже существует.");
                else MessageBox.Show("Ошибка БД: " + ex.Message);
            }
            finally { db.closeConnection(); }
        }
    }
}