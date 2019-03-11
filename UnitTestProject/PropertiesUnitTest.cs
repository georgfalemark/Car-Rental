using BiluthyrningAB.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestProject
{
    [TestClass]
    public class PropertiesUnitTest
    {
        [TestMethod]
        public void CalculateBookingPrice_small_1()
        {
            Car myTestCar = new Car { LicenseNumber = "ABC123", CarType = CarType.Small };
            Booking input = new Booking { NumberOfKm = 100, StartDate = new DateTime(2018, 05, 10), ReturnDate = new DateTime(2018, 05, 20), Car = myTestCar };

            decimal result = input.Price;
            decimal expected = 1000;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateBookingPrice_small_2()
        {
            Car myTestCar = new Car { LicenseNumber = "ABC123", CarType = CarType.Small };
            Booking input = new Booking { NumberOfKm = 100, StartDate = new DateTime(2018, 04, 29), ReturnDate = new DateTime(2018, 05, 02), Car = myTestCar };

            decimal result = input.Price;
            decimal expected = 300;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateBookingPrice_small_3()
        {
            Car myTestCar = new Car { LicenseNumber = "ABC123", CarType = CarType.Small };
            Booking input = new Booking { NumberOfKm = 100, StartDate = new DateTime(2018, 05, 10), ReturnDate = new DateTime(2018, 05, 15), Car = myTestCar };

            decimal result = input.Price;
            decimal expected = 500;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateBookingPrice_small_4()
        {
            Car myTestCar = new Car { LicenseNumber = "ABC123", CarType = CarType.Small };
            Booking input = new Booking { NumberOfKm = 100, StartDate = new DateTime(2018, 05, 10, 10, 00, 00), ReturnDate = new DateTime(2018, 05, 15, 16, 00, 00), Car = myTestCar };

            decimal result = input.Price;
            decimal expected = 600;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateBookingPrice_van_1()
        {
            Car myTestCar = new Car { LicenseNumber = "ABC123", CarType = CarType.Van };
            Booking input = new Booking { NumberOfKm = 100, StartDate = new DateTime(2018, 05, 10), ReturnDate = new DateTime(2018, 05, 20), Car = myTestCar };

            decimal result = input.Price;
            decimal expected = 1700;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateBookingPrice_van_2()
        {
            Car myTestCar = new Car { LicenseNumber = "ABC123", CarType = CarType.Van };
            Booking input = new Booking { NumberOfKm = 1000, StartDate = new DateTime(2018, 05, 10), ReturnDate = new DateTime(2018, 05, 20), Car = myTestCar };

            decimal result = input.Price;
            decimal expected = 6200;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateBookingPrice_van_3()
        {
            Car myTestCar = new Car { LicenseNumber = "ABC123", CarType = CarType.Van };
            Booking input = new Booking { NumberOfKm = 1000, StartDate = new DateTime(2018, 05, 10), ReturnDate = new DateTime(2018, 05, 17), Car = myTestCar };

            decimal result = input.Price;
            decimal expected = 5840;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateBookingPrice_van_4()
        {
            Car myTestCar = new Car { LicenseNumber = "ABC123", CarType = CarType.Van };
            Booking input = new Booking { NumberOfKm = 1000, StartDate = new DateTime(2018, 05, 10, 16, 00, 00), ReturnDate = new DateTime(2018, 05, 17, 12, 00, 00), Car = myTestCar };

            decimal result = input.Price;
            decimal expected = 5840;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateBookingPrice_minibus_1()
        {
            Car myTestCar = new Car { LicenseNumber = "ABC123", CarType = CarType.Minibus };
            Booking input = new Booking { NumberOfKm = 100, StartDate = new DateTime(2018, 05, 10), ReturnDate = new DateTime(2018, 05, 20), Car = myTestCar };

            decimal result = input.Price;
            decimal expected = 2450;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CalculateBookingPrice_minibus_2()
        {
            Car myTestCar = new Car { LicenseNumber = "ABC123", CarType = CarType.Minibus };
            Booking input = new Booking { NumberOfKm = 1000, StartDate = new DateTime(2018, 05, 10), ReturnDate = new DateTime(2018, 05, 20), Car = myTestCar };

            decimal result = input.Price;
            decimal expected = 9200;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertTwoDatetimesToDecimal_1()
        {
            Booking input = new Booking { StartDate = new DateTime(2018, 05, 07), ReturnDate = new DateTime(2018, 05, 27) };

            decimal result = input.NumberOfDays;
            decimal expected = 20;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertTwoDatetimesToDecimal_2()
        {
            Booking input = new Booking { StartDate = new DateTime(2018, 05, 07), ReturnDate = new DateTime(2018, 05, 14) };

            decimal result = input.NumberOfDays;
            decimal expected = 7;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertTwoDatetimesToDecimal_3()
        {
            Booking input = new Booking { StartDate = new DateTime(2018, 05, 07), ReturnDate = new DateTime(2018, 05, 08) };

            decimal result = input.NumberOfDays;
            decimal expected = 1;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertTwoDatetimesToDecimal_CheckForTime_1()
        {
            Booking input = new Booking { StartDate = new DateTime(2018, 05, 07, 12, 00, 00), ReturnDate = new DateTime(2018, 05, 14, 16, 00, 00) };

            decimal result = input.NumberOfDays;
            decimal expected = 8;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertTwoDatetimesToDecimal_CheckForTime_2()
        {
            Booking input = new Booking { StartDate = new DateTime(2018, 05, 07, 16, 00, 00), ReturnDate = new DateTime(2018, 05, 14, 14, 00, 00) };

            decimal result = input.NumberOfDays;
            decimal expected = 7;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetEnumCarTypes()
        {
            string[] arr = Enum.GetNames(typeof(CarType));

            string result = arr.Single(x => x == "Small");
            string expected = "Small";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPersonNumberValidation_1()
        {
            Customer dude = new Customer { PersonNumber = "960506-0632" };

            var result = Validator.TryValidateObject(dude, new ValidationContext(dude, null, null), null, true);
            var expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPersonNumberValidation_2()
        {
            Customer dude = new Customer { PersonNumber = "780102-4575" };

            var result = Validator.TryValidateObject(dude, new ValidationContext(dude, null, null), null, true);
            var expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPersonNumberValidation_3()
        {
            Customer dude = new Customer { PersonNumber = "441111-7874" };

            var result = Validator.TryValidateObject(dude, new ValidationContext(dude, null, null), null, true);
            var expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPersonNumberValidation_4()
        {
            Customer dude = new Customer { PersonNumber = "421324-0000" };

            var result = Validator.TryValidateObject(dude, new ValidationContext(dude, null, null), null, true);
            var expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPersonNumberValidation_5()
        {
            Customer dude = new Customer { PersonNumber = "42AAA24-0000" };

            var result = Validator.TryValidateObject(dude, new ValidationContext(dude, null, null), null, true);
            var expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPersonNumberValidation_6()
        {
            Customer dude = new Customer { PersonNumber = "421132-4451" };

            var result = Validator.TryValidateObject(dude, new ValidationContext(dude, null, null), null, true);
            var expected = false;

            Assert.AreEqual(expected, result);
        }



    }
}
