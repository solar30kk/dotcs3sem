using System;
using System.Collections.Generic;
using Lab1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class EquipmentTests
    {
        [TestMethod]
        public void DefaultConstructors_SetDefaultValues() // Проверка начальных значений

        {
            // Arrange
            int expectedPrice = 0;
            double expectedDiagonal = 24;
            int expectedRefreshRate = 60;
            int expectedKeyCount = 104;

            // Act
            ComputerEquipment device = new ComputerEquipment();
            ComputerMonitor monitor = new ComputerMonitor();
            ComputerKeyboard keyboard = new ComputerKeyboard();

            // Assert
            Assert.AreEqual("Не указан", device.Manufacturer);
            Assert.AreEqual("Не указана", device.Model);
            Assert.AreEqual(expectedPrice, device.Price);
            Assert.AreEqual(0, device.WarrantyMonths);

            Assert.AreEqual(expectedDiagonal, monitor.DiagonalInches);
            Assert.AreEqual(expectedRefreshRate, monitor.RefreshRateHz);

            Assert.AreEqual(expectedKeyCount, keyboard.KeyCount);
            Assert.IsFalse(keyboard.IsMechanical);
        }

        [TestMethod]
        public void MonitorConstructor_SavesProperties() // Проверка конструктора монитора
        {
            // Arrange
            string manufacturer = "AOC";
            string model = "24G2";
            int price = 18000;
            int warrantyMonths = 36;
            double diagonalInches = 23.8;
            int refreshRateHz = 144;

            // Act
            ComputerMonitor monitor = new ComputerMonitor(
                manufacturer,
                model,
                price,
                warrantyMonths,
                diagonalInches,
                refreshRateHz);

            // Assert
            Assert.AreEqual(manufacturer, monitor.Manufacturer);
            Assert.AreEqual(model, monitor.Model);
            Assert.AreEqual(price, monitor.Price);
            Assert.AreEqual(warrantyMonths, monitor.WarrantyMonths);
            Assert.AreEqual(diagonalInches, monitor.DiagonalInches);
            Assert.AreEqual(refreshRateHz, monitor.RefreshRateHz);
        }

        [TestMethod]
        public void KeyboardConstructor_SavesProperties() // Проверка конструктора клавиатуры
        {
            // Arrange
            string manufacturer = "Logitech";
            string model = "K120";
            int price = 1500;
            int warrantyMonths = 24;
            int keyCount = 104;
            bool isMechanical = false;

            // Act
            ComputerKeyboard keyboard = new ComputerKeyboard(
                manufacturer,
                model,
                price,
                warrantyMonths,
                keyCount,
                isMechanical);

            // Assert
            Assert.AreEqual(manufacturer, keyboard.Manufacturer);
            Assert.AreEqual(model, keyboard.Model);
            Assert.AreEqual(price, keyboard.Price);
            Assert.AreEqual(warrantyMonths, keyboard.WarrantyMonths);
            Assert.AreEqual(keyCount, keyboard.KeyCount);
            Assert.AreEqual(isMechanical, keyboard.IsMechanical);
        }

        [TestMethod]
        public void Properties_WithValidValues_AreChanged() // Проверка изменения свойств
        {
            // Arrange
            ComputerMonitor monitor = new ComputerMonitor();
            ComputerKeyboard keyboard = new ComputerKeyboard();

            // Act
            monitor.Manufacturer = "Dell";
            monitor.Model = "G";
            monitor.Price = 20000;
            monitor.WarrantyMonths = 24;
            monitor.DiagonalInches = 27;
            monitor.RefreshRateHz = 165;

            keyboard.KeyCount = 61;
            keyboard.IsMechanical = true;

            // Assert
            Assert.AreEqual("Dell", monitor.Manufacturer);
            Assert.AreEqual("G", monitor.Model);
            Assert.AreEqual(20000, monitor.Price);
            Assert.AreEqual(24, monitor.WarrantyMonths);
            Assert.AreEqual(27.0, monitor.DiagonalInches);
            Assert.AreEqual(165, monitor.RefreshRateHz);

            Assert.AreEqual(61, keyboard.KeyCount);
            Assert.IsTrue(keyboard.IsMechanical);
        }

        [TestMethod]
        public void Price_WithNegativeValue_ThrowsAndKeepsOldPrice() // Проверка отрицательной цены
        {
            // Arrange
            ComputerEquipment device =
                new ComputerEquipment("AOC", "24G2", 18000, 36);

            bool exceptionWasThrown = false;

            // Act
            try
            {
                device.Price = -100;
            }
            catch (ArgumentOutOfRangeException)
            {
                exceptionWasThrown = true;
            }

            // Assert
            Assert.IsTrue(
                exceptionWasThrown,
                "При отрицательной цене должно возникать исключение.");

            Assert.AreEqual(
                18000,
                device.Price,
                "После ошибки старая цена должна сохраниться.");
        }

        [TestMethod]
        public void Constructor_TrimsTextAndAllowsZeroValues() // Проверка пробелов и нулей
        {
            // Arrange
            string manufacturer = "  AOC  ";
            string model = "  24G2  ";

            // Act
            ComputerEquipment device =
                new ComputerEquipment(manufacturer, model, 0, 0);

            // Assert
            Assert.AreEqual("AOC", device.Manufacturer);
            Assert.AreEqual("24G2", device.Model);
            Assert.AreEqual(0, device.Price);
            Assert.AreEqual(0, device.WarrantyMonths);
        }

        [TestMethod]
        public void ToString_InBaseTypeCollection_UsesObjectType() // Проверка полиморфизма
        {
            // Arrange
            List<ComputerEquipment> items =
                new List<ComputerEquipment>();

            items.Add(
                new ComputerEquipment("B", "X", 0, 0));

            items.Add(
                new ComputerMonitor("B", "M", 100, 12, 24, 60));

            items.Add(
                new ComputerKeyboard("B", "K", 50, 6, 104, false));

            string expectedDevice =
                "Техника: B X; цена: 0 руб.; гарантия: 0 мес.";

            string expectedMonitor =
                "Монитор | Техника: B M; цена: 100 руб.; " +
                "гарантия: 12 мес.; диагональ: 24 дюйм.; частота: 60 Гц";

            string expectedKeyboard =
                "Клавиатура | Техника: B K; цена: 50 руб.; " +
                "гарантия: 6 мес.; клавиши: 104; тип: мембранная";

            // Act
            string actualDevice = items[0].ToString();
            string actualMonitor = items[1].ToString();
            string actualKeyboard = items[2].ToString();

            // Assert
            Assert.AreEqual(expectedDevice, actualDevice);
            Assert.AreEqual(expectedMonitor, actualMonitor);
            Assert.AreEqual(expectedKeyboard, actualKeyboard);
        }
    }
}