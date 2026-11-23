namespace Lab2
{
    public sealed class CorrespondenceStudent : Student
    {
        // Создаёт студента-заочника
        public CorrespondenceStudent(string name, string institution, string number)
            : base(name, institution, number)
        {
        }

        // Описывает занятие
        public override string DescribeActivity()
        {
            return "Готовится самостоятельно и приезжает на сессию.";
        }

        // Добавляет форму обучения
        public override string ToString()
        {
            return $"{base.ToString()}, форма обучения: заочная";
        }
    }
}
