namespace Lab2
{
    public abstract class Person
    {
        public string Name { get; }

        // Сохраняет имя
        protected Person(string name)
        {
            Name = name;
        }

        // Описывает занятие человека
        public virtual string DescribeActivity()
        {
            return "Занимается повседневными делами.";
        }

        // Выводит тип и имя
        public override string ToString()
        {
            return $"{GetType().Name}: {Name}";
        }
    }
}
