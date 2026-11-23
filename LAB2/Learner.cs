namespace Lab2
{
    public abstract class Learner : Person
    {
        public string Institution { get; }

        // Сохраняет место учёбы
        protected Learner(string name, string institution)
            : base(name)
        {
            Institution = institution;
        }

        // Описывает занятие
        public override string DescribeActivity()
        {
            return "Посещает занятия.";
        }

        // Добавляет место учёбы
        public override string ToString()
        {
            return $"{base.ToString()}, место учёбы: {Institution}";
        }
    }
}
