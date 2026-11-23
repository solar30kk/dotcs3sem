namespace Lab2
{
    public sealed class Programmer : Employee
    {
        public string Language { get; }

        // Сохраняет язык программирования
        public Programmer(string name, string workplace, string language)
            : base(name, workplace)
        {
            Language = language;
        }

        // Описывает занятие
        public override string DescribeActivity()
        {
            return $"Пишет программы на {Language}.";
        }

        // Добавляет язык программирования
        public override string ToString()
        {
            return $"{base.ToString()}, язык: {Language}";
        }
    }
}
