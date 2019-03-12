using BiluthyrningAB.Controllers;
using BiluthyrningAB.Data;
using BiluthyrningAB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    class MethodsUnitTest
    {
        private readonly BookingsController _bookingsController;
        private readonly AppDbContext _context;

        public MethodsUnitTest(BookingsController bookingsController, AppDbContext context)
        {
            _bookingsController = bookingsController;
            _context = context;
        }

        [TestMethod]
        public async void TryAddBooking_1()
        {
            Car car = _context.Cars.Single(x => x.LicenseNumber == "ABC123");
            Customer dude = _context.Customers.Single(x => x.FirstName == "Georg" && x.LastName == "Fälemark");

            Booking input = new Booking { StartDate = new DateTime(2019, 01, 04), CarId = car.CarId, CustomerId = dude.CustomerId };
            await _bookingsController.Create(input);




            //Task<IActionResult> expected;

            //hur ska man göra här för att få ett expected? 
            //Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TryAddBooking_2()
        {
            Car car = null;
            Customer dude = null;

            Booking input = new Booking { StartDate = new DateTime(2019, 01, 04), CarId = car.CarId, CustomerId = dude.CustomerId };
            var result = _bookingsController.Create(input);




            //Task<IActionResult> expected;

            //hur ska man göra här för att få ett expected? 
            //Assert.AreEqual(expected, result);
        }









    }
}
