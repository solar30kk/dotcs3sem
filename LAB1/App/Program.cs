using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Lab1.Models;

namespace Lab1.App
{
    internal class Program
    {
        private static List<ComputerEquipment> equipment =
            new List<ComputerEquipment>();

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            equipment.Add(
                new ComputerEquipment("Generic", "USB Hub", 1500, 12));

            equipment.Add(
                new ComputerMonitor("AOC", "24G2", 18000, 36, 23.8, 144));

            equipment.Add(
                new ComputerKeyboard("Logitech", "K120", 1500, 24, 104, false));

            PrintAll();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1 — показать список");
                Console.WriteLine("2 — добавить устройство");
                Console.WriteLine("3 — удалить устройство");
                Console.WriteLine("4 — изменить цену");
                Console.WriteLine("0 — выход");

                string? command = Console.ReadLine();

                if (command == null || command == "0")
                {
                    break;
                }

                try
                {
                    switch (command)
                    {
                        case "1":
                            PrintAll();
                            break;

                        case "2":
                            AddEquipment();
                            break;

                        case "3":
                            RemoveEquipment();
                            break;

                        case "4":
                            ChangePrice();
                            break;

                        default:
                            Console.WriteLine("Нет такого пункта.");
                            break;
                    }
                }
                catch (EndOfStreamException)
                {
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка ввода: " + ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Ошибка ввода: неверный формат числа.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine(
                        "Ошибка ввода: число выходит за допустимый диапазон.");
                }
            }
        }

        static void AddEquipment()
        {
            Console.WriteLine(
                "Тип: 1 — техника, 2 — монитор, 3 — клавиатура");

            string type = Read();

            if (type != "1" && type != "2" && type != "3")
            {
                throw new ArgumentException("Неизвестный тип.");
            }

            string manufacturer = Ask("Производитель:");
            string model = Ask("Модель:");
            int price = int.Parse(Ask("Цена в целых рублях:"));
            int warrantyMonths = int.Parse(Ask("Гарантия в месяцах:"));

            ComputerEquipment item;

            switch (type)
            {
                case "2":
                    double diagonalInches =
                        double.Parse(Ask("Диагональ в дюймах:"));

                    int refreshRateHz =
                        int.Parse(Ask("Частота в герцах:"));

                    item = new ComputerMonitor(
                        manufacturer,
                        model,
                        price,
                        warrantyMonths,
                        diagonalInches,
                        refreshRateHz);

                    break;

                case "3":
                    int keyCount =
                        int.Parse(Ask("Количество клавиш:"));

                    bool isMechanical = ReadMechanical();

                    item = new ComputerKeyboard(
                        manufacturer,
                        model,
                        price,
                        warrantyMonths,
                        keyCount,
                        isMechanical);

                    break;

                default:
                    item = new ComputerEquipment(
                        manufacturer,
                        model,
                        price,
                        warrantyMonths);

                    break;
            }

            equipment.Add(item);
            Console.WriteLine("Добавлено.");
        }

        static void RemoveEquipment()
        {
            int index = ReadIndex();

            equipment.RemoveAt(index);

            Console.WriteLine("Удалено.");
        }

        static void ChangePrice()
        {
            int index = ReadIndex();
            int newPrice = int.Parse(Ask("Новая цена в целых рублях:"));

            equipment[index].Price = newPrice;

            Console.WriteLine(equipment[index]);
        }

        static void PrintAll()
        {
            Console.WriteLine();
            Console.WriteLine("Список компьютерной техники:");

            if (equipment.Count == 0)
            {
                Console.WriteLine("Список пуст.");
            }

            for (int i = 0; i < equipment.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {equipment[i]}");
            }
        }

        static string Read()
        {
            string? text = Console.ReadLine();

            if (text == null)
            {
                throw new EndOfStreamException();
            }

            return text;
        }

        static string Ask(string prompt)
        {
            Console.WriteLine(prompt);
            return Read();
        }

        static bool ReadMechanical()
        {
            string answer = Ask("Механическая? 1 — да, 0 — нет");

            if (answer == "1")
            {
                return true;
            }
            else if (answer == "0")
            {
                return false;
            }
            else
            {
                throw new ArgumentException("Введите 0 или 1.");
            }
        }

        static int ReadIndex()
        {
            int number = int.Parse(Ask("Номер устройства в списке:"));

            if (number < 1 || number > equipment.Count)
            {
                throw new ArgumentException(
                    "Нет устройства с таким номером.");
            }

            return number - 1;
        }
    }
}