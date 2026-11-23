using System;

namespace Lab2
{
    public static class Extensions
    {
        // Возвращает средний символ
        public static char MiddleCharacter(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Строка должна содержать символы.", nameof(text));
            }

            // При чётной длине берём левый из двух средних символов
            int middle = (text.Length - 1) / 2;
            return text[middle];
        }

        // Проверяет длину пароля
        public static bool HasValidLength(this Password password)
        {
            return password.Length >= 6 && password.Length <= 12;
        }
    }
}
