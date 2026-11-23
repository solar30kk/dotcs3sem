namespace Lab2
{
    public abstract class WorkingPerson : Person
    {
        public string Workplace { get; }

        // Сохраняет место работы
        protected WorkingPerson(string name, string workplace)
            : base(name)
        {
            Workplace = workplace;
        }

        // Описывает занятие
        public override string DescribeActivity()
        {
            return "Работает в организации.";
        }

        // Добавляет место работы
        public override string ToString()
        {
            return $"{base.ToString()}, место работы: {Workplace}";
        }
    }
}
