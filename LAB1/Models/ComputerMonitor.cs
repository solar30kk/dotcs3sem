using System;

namespace Lab1.Models
{
    public class ComputerMonitor : ComputerEquipment
    {
        private double diagonalInches = 24;
        private int refreshRateHz = 60;

        public double DiagonalInches
        {
            get
            {
                return diagonalInches;
            }
            set
            {
                if (!double.IsFinite(value) || value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(DiagonalInches),
                        "Диагональ должна быть положительным конечным числом.");
                }

                diagonalInches = value;
            }
        }

        public int RefreshRateHz
        {
            get
            {
                return refreshRateHz;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(RefreshRateHz),
                        "Частота должна быть больше нуля.");
                }

                refreshRateHz = value;
            }
        }

        public ComputerMonitor()
        {
        }

        public ComputerMonitor(
            string manufacturer,
            string model,
            int price,
            int warrantyMonths,
            double diagonalInches,
            int refreshRateHz)
            : base(manufacturer, model, price, warrantyMonths)
        {
            DiagonalInches = diagonalInches;
            RefreshRateHz = refreshRateHz;
        }

        public override string ToString()
        {
            return "Монитор | " + base.ToString() +
                   $"; диагональ: {DiagonalInches} дюйм.; " +
                   $"частота: {RefreshRateHz} Гц";
        }
    }
}