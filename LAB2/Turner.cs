namespace Lab2
{
    public sealed class Turner : WorkingPerson
    {
        public int Grade { get; }

        // Сохраняет разряд токаря
        public Turner(string name, string workplace, int grade)
            : base(name, workplace)
        {
            Grade = grade;
        }

        // Описывает занятие
        public override string DescribeActivity()
        {
            return "Обрабатывает деталь на токарном станке.";
        }

        // Добавляет разряд токаря
        public override string ToString()
        {
            return $"{base.ToString()}, разряд: {Grade}";
        }
    }
}
