namespace Lab2
{
    public class Employee : WorkingPerson
    {
        // Создаёт служащего
        public Employee(string name, string workplace)
            : base(name, workplace)
        {
        }

        // Описывает занятие
        public override string DescribeActivity()
        {
            return "Оформляет документы.";
        }

        // Добавляет должность
        public override string ToString()
        {
            return $"{base.ToString()}, служащий";
        }
    }
}
