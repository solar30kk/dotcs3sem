using System;

namespace Lab2
{
    public sealed class Password
    {
        public const string DefaultValue = "Default1";

        public string Value { get; }

        public int Length
        {
            get
            {
                return Value.Length;
            }
        }

        // Символ по индексу
        public char this[int index]
        {
            get
            {
                return Value[index];
            }
        }

        // Пароль по умолчанию
        public Password() : this(DefaultValue)
        {
        }

        // Создаёт пароль
        public Password(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
        }

        // Заменяет последний символ
        public static Password operator -(Password password, char item)
        {
            if (password.Length == 0)
            {
                throw new InvalidOperationException("У пустого пароля нет последнего символа.");
            }

            string start = password.Value.Substring(0, password.Length - 1);
            return new Password(start + item);
        }

        // Сравнивает длины паролей
        public static bool operator >(Password left, Password right)
        {
            return left.Length > right.Length;
        }

        // Сравнивает длины паролей
        public static bool operator <(Password left, Password right)
        {
            return left.Length < right.Length;
        }

        // Проверяет равенство паролей
        public static bool operator ==(Password? left, Password? right)
        {
            return object.Equals(left, right);
        }

        // Проверяет различие паролей
        public static bool operator !=(Password? left, Password? right)
        {
            return !(left == right);
        }

        // Сравнивает текст паролей
        public override bool Equals(object? obj)
        {
            if (obj is Password other)
            {
                return Value == other.Value;
            }

            return false;
        }

        // Возвращает хеш-код пароля
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        // Сбрасывает пароль.
        public static Password operator ++(Password password)
        {
            return new Password();
        }

        // Проверяет стойкость пароля
        private bool IsStrong()
        {
            if (!this.HasValidLength())
            {
                return false;
            }

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            foreach (char symbol in Value)
            {
                if (char.IsUpper(symbol))
                {
                    hasUpper = true;
                }

                if (char.IsLower(symbol))
                {
                    hasLower = true;
                }

                if (char.IsDigit(symbol))
                {
                    hasDigit = true;
                }
            }

            return hasUpper && hasLower && hasDigit;
        }

        // Проверяет условие if (password)
        public static bool operator true(Password password)
        {
            return password.IsStrong();
        }

        // Проверяет обратное условие
        public static bool operator false(Password password)
        {
            return !password.IsStrong();
        }
    }
}
