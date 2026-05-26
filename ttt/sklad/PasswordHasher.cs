using System;
using System.Security.Cryptography;
using System.Text;

namespace sklad
{
    public static class PasswordHasher
    {
        // Генерация случайной соли (16 байт)
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Хэширование пароля с солью (SHA256)
        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                string combined = password + salt;
                byte[] bytes = Encoding.UTF8.GetBytes(combined);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Проверка пароля
        public static bool Verify(string password, string salt, string expectedHash)
        {
            return HashPassword(password, salt) == expectedHash;
        }
    }
}