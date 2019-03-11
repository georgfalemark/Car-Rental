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
        public void GetSelectListItems_Customer_1()
        {
            Car car = _context.Cars.First();
            Customer dude = _context.Customers.First();

            Booking input = new Booking { StartDate = new DateTime(2019, 01, 04), CarId = car.CarId, CustomerId = dude.CustomerId };
            var result = _bookingsController.Create(input);

            Task<IActionResult> expected;


            //hur ska man göra här för att få ett expected? 



            //Assert.AreEqual(expected, result);
        }







    }
}
