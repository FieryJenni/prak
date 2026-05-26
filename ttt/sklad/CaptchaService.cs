using System;

namespace sklad
{
    public class CaptchaService
    {
        private static readonly Random _random = new Random();
        private const string Alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        public string CurrentCode { get; private set; } = "";

        public string Generate()
        {
            char[] chars = new char[5];
            for (int i = 0; i < 5; i++)
            {
                chars[i] = Alphabet[_random.Next(Alphabet.Length)];
            }
            CurrentCode = new string(chars);
            return CurrentCode;
        }

        public bool Validate(string input)
        {
            return string.Equals(CurrentCode, input?.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }
}