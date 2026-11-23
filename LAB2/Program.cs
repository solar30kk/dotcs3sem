using System;

namespace Lab2
{
    internal class Program
    {
        // Запускает обе части
        static void Main()
        {
            Console.WriteLine("Часть 1. Пароли");
            TestPasswords();

            Console.WriteLine();
            Console.WriteLine("Часть 2. Люди");
            ShowPeople();
        }

        // Проверяет результат
        static void Check(string title, bool passed)
        {
            if (!passed)
            {
                throw new InvalidOperationException("Ошибка: " + title);
            }

            Console.WriteLine("Пройдено: " + title);
        }

        // Проверяет операции с паролями
        static void TestPasswords()
        {
            Password original = new Password("Code123");
            Password shortPassword = new Password("abc");

            Password changed = original - '4';
            Check("Замена последнего символа", changed.Value == "Code124");
            Check("Исходный пароль сохранился", original.Value == "Code123");
            Check("Первый символ пароля", changed[0] == 'C');

            Check("Code123 длиннее abc", original > shortPassword);
            Check("abc короче Code123", shortPassword < original);
            Check("Разные пароли одной длины", changed != original);
            Check("Совпадение текста паролей", original == new Password("Code123"));

            changed++;
            Check("Сброс на пароль по умолчанию", changed.Value == Password.DefaultValue);

            TestStrength(original, true);
            TestStrength(new Password("abcdef"), false);
            TestExtensions();
        }

        // Проверяет оператор true
        static void TestStrength(Password password, bool expected)
        {
            bool strong = false;
            if (password)
            {
                strong = true;
            }

            Check("Стойкость пароля " + password.Value, strong == expected);
        }

        // Проверяет методы расширения
        static void TestExtensions()
        {
            Check("Середина строки abcde", "abcde".MiddleCharacter() == 'c');
            Check("Середина строки abcd", "abcd".MiddleCharacter() == 'b');

            Password five = new Password("12345");
            Password six = new Password("123456");
            Password twelve = new Password("123456789012");
            Password thirteen = new Password("1234567890123");

            Check("5 символов — слишком мало", !five.HasValidLength());
            Check("6 символов допустимы", six.HasValidLength());
            Check("12 символов допустимы", twelve.HasValidLength());
            Check("13 символов — слишком много", !thirteen.HasValidLength());
        }

        // полиморфизм
        static void ShowPeople()
        {
            Person[] people =
            {
                new Employee("Иван", "Архив"),
                new Turner("Олег", "Завод", 4),
                new Programmer("Анна", "ИТ-отдел", "C#"),
                new Student("Артем", "Учебный университет", "101"),
                new CorrespondenceStudent("Мария", "Учебный университет", "102")
            };

            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
                Console.WriteLine(person.DescribeActivity());
            }

            GradeBook first = new GradeBook("Учебный университет", "101");
            GradeBook second = new GradeBook("Учебный университет", "101");
            Check("Равные зачётные книжки", first.Equals(second));
            Check("Совпадение хеш-кодов равных книжек", first.GetHashCode() == second.GetHashCode());
        }
    }
}
