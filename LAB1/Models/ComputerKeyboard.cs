using System;

namespace Lab1.Models
{
    public class ComputerKeyboard : ComputerEquipment
    {
        private int keyCount = 104;
        private bool isMechanical;

        public int KeyCount
        {
            get
            {
                return keyCount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(KeyCount),
                        "Количество клавиш должно быть больше нуля.");
                }

                keyCount = value;
            }
        }

        public bool IsMechanical
        {
            get
            {
                return isMechanical;
            }
            set
            {
                isMechanical = value;
            }
        }

        public ComputerKeyboard()
        {
        }

        public ComputerKeyboard(
            string manufacturer,
            string model,
            int price,
            int warrantyMonths,
            int keyCount,
            bool isMechanical)
            : base(manufacturer, model, price, warrantyMonths)
        {
            KeyCount = keyCount;
            IsMechanical = isMechanical;
        }

        public override string ToString()
        {
            string keyboardType;

            if (IsMechanical)
            {
                keyboardType = "механическая";
            }
            else
            {
                keyboardType = "мембранная";
            }

            return "Клавиатура | " + base.ToString() +
                   $"; клавиши: {KeyCount}; тип: {keyboardType}";
        }
    }
}