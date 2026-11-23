using System;

namespace Lab2
{
    public sealed class GradeBook
    {
        public string Institution { get; }
        public string Number { get; }

        // Создаёт зачётную книжку
        public GradeBook(string institution, string number)
        {
            Institution = institution;
            Number = number;
        }

        // Сравнивает вуз и номер
        public override bool Equals(object? obj)
        {
            if (obj is GradeBook other)
            {
                return Institution == other.Institution && Number == other.Number;
            }

            return false;
        }

        // Возвращает хеш-код книжки
        public override int GetHashCode()
        {
            return HashCode.Combine(Institution, Number);
        }

        // Выводит данные книжки
        public override string ToString()
        {
            return $"{GetType().Name}: {Institution}, № {Number}";
        }
    }
}
