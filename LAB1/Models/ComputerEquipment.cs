using System;

namespace Lab1.Models
{
    public class ComputerEquipment
    {
        private string manufacturer = "Не указан";
        private string model = "Не указана";
        private int price;
        private int warrantyMonths;

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = RequireText(value, nameof(Manufacturer));
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = RequireText(value, nameof(Model));
            }
        }

        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Price), "Цена не может быть отрицательной.");
                }

                price = value;
            }
        }

        public int WarrantyMonths
        {
            get
            {
                return warrantyMonths;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(WarrantyMonths),
                        "Гарантия не может быть отрицательной.");
                }

                warrantyMonths = value;
            }
        }

        public ComputerEquipment()
        {
        }

        public ComputerEquipment(
            string manufacturer,
            string model,
            int price,
            int warrantyMonths)
        {
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            WarrantyMonths = warrantyMonths;
        }

        protected static string RequireText(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Строка не должна быть пустой.", name);
            }

            return value.Trim();
        }

        public override string ToString()
        {
            return $"Техника: {Manufacturer} {Model}; " +
                   $"цена: {Price} руб.; гарантия: {WarrantyMonths} мес.";
        }
    }
}