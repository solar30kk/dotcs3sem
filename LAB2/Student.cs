namespace Lab2
{
    public class Student : Learner
    {
        public GradeBook Book { get; }

        // Создаёт зачётную книжку
        public Student(string name, string institution, string number)
            : base(name, institution)
        {
            Book = new GradeBook(institution, number);
        }

        // Описывает занятие
        public override string DescribeActivity()
        {
            return "Сдаёт экзамены.";
        }

        // Добавляет номер зачётки
        public override string ToString()
        {
            return $"{base.ToString()}, зачётная книжка: {Book.Number}";
        }
    }
}
