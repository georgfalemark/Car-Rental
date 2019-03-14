using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiluthyrningAB.Data;
using BiluthyrningAB.Models;
using BiluthyrningAB.ViewModels;
using BiluthyrningAB.Persistence.Repositories;

namespace BiluthyrningAB.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEntityFrameworkRepository _entityFrameworkRepository;

        public BookingsController(IBookingRepository bookingRepository, ICarRepository carRepository, IEntityFrameworkRepository entityFrameworkRepository, ICustomerRepository customerRepository)
        {
            _bookingRepository = bookingRepository;
            _carRepository = carRepository;
            _entityFrameworkRepository = entityFrameworkRepository;
            _customerRepository = customerRepository;
        }


        public async Task<IActionResult> Index()
        {
            var myTask = Task.Run(() => _bookingRepository.GetAllBookings());
            return View(await myTask);
        }


        public async Task<IActionResult> BookingsForCertainCustomer(Guid? CustomerId)
        {
            var myTask = Task.Run(() => _bookingRepository.GetBookingsForCertainCustomer(CustomerId));
            return View(await myTask);
        }


        public async Task<IActionResult> OnGoingBookings()
        {
            var myTask = Task.Run(() => _bookingRepository.GetBookingsDependingOnStatus(true));
            return View(await myTask);
        }


        public async Task<IActionResult> Not_OnGoingBookings()
        {
            var myTask = Task.Run(() => _bookingRepository.GetBookingsDependingOnStatus(false));
            return View(await myTask);
        }


        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var booking = _bookingRepository.GetBookingById(id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }


        public IActionResult Create()
        {
            BookingVm bookingVm = new BookingVm();

            //Fyller listan med bilarna som finns genom metod
            bookingVm.Cars = FillCarListOfSelectListItems();

            //Fyller listan med kunder som finns genom metod
            bookingVm.Customers = FillCustomerListOfSelectListItems();

            return View(bookingVm);
        }


        public List<SelectListItem> FillCustomerListOfSelectListItems()
        {
            var customers = _customerRepository.GetAllCustomers();

            List<SelectListItem> listOfCustomers = new List<SelectListItem>();

            foreach (var customer in customers)
            {
                string wholeName = $"{customer.FirstName} {customer.LastName}";
                var x = new SelectListItem() { Text = wholeName, Value = customer.CustomerId.ToString() };
                listOfCustomers.Add(x);
            }
            return listOfCustomers;
        }


        public List<SelectListItem> FillCarListOfSelectListItems()
        {
            var cars = _carRepository.GetAllCars();

            List<SelectListItem> listOfCars = new List<SelectListItem>();

            foreach (var car in cars)
            {
                var y = new SelectListItem() { Text = car.LicenseNumber, Value = car.CarId.ToString(), Group = new SelectListGroup { Name = car.CarType.ToString() } };
                listOfCars.Add(y);
            }

            return listOfCars;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CustomerId,CarId,StartDate")] Booking booking)
        {
            booking.ReturnDate = booking.StartDate.AddDays(1);
            booking.OnGoing = true;

            //Hämtar bilen vi har att göra med och sätter den till bokad. Om den redan är bokad så berättar vi det 
            booking.Car = _carRepository.GetCarById(booking.CarId);


            if (booking.Car.Booked == false)
            {
                booking.Car.Booked = true;
            }
            else
            {
                ViewBag.Message = "Bilen är redan bokad, vänligen välj en annan";
                BookingVm error_bookingVm = new BookingVm();
                error_bookingVm.Cars = FillCarListOfSelectListItems();
                error_bookingVm.Customers = FillCustomerListOfSelectListItems();
                return View(error_bookingVm);
            }

            if (ModelState.IsValid)
            {
                //Lägger till bokningen i systemet
                booking.BookingId = Guid.NewGuid();
                _bookingRepository.AddBooking(booking);

                //Uppdaterar bilen till bokad
                _carRepository.UpdateCar(booking.Car);

                _entityFrameworkRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            BookingVm bookingVm = new BookingVm();

            //Om det misslyckas så hämtar vi bilarna på nytt
            bookingVm.Cars = FillCarListOfSelectListItems();

            ////Om det misslyckas så hämtar vi kunderna på nytt
            bookingVm.Customers = FillCustomerListOfSelectListItems();

            return View(bookingVm);
        }


        public async Task<IActionResult> FinishBooking(Guid? id)
        {
            if (id == null)
                return NotFound();

            var booking = _bookingRepository.GetBookingById(id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinishBooking(Guid id, [Bind("BookingId,NumberOfKm,StartDate,ReturnDate,CustomerId,Car")] Booking booking)
        {
            if (id != booking.BookingId)
                return NotFound();

            if (booking.Price < 0)
            {
                ViewBag.Message = "Nu blev det något galet med antalet körda kilometer eller datumen, återlämningsdatum måste vara senare än inlämningsdatum";
                return View(booking);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Sätter ordern till slutförd
                    booking.OnGoing = false;

                    //Gör bilen obokad igen
                    booking.Car.Booked = false;

                    //uppdaterar bilens antal körda kilometer
                    booking.Car.NumberOfDrivenKm = booking.Car.NumberOfDrivenKm + Convert.ToInt32(booking.NumberOfKm);

                    //Uppdaterar sedan både bilen (för antalet mils räkning) samt bokningen
                    _carRepository.UpdateCar(booking.Car);
                    _bookingRepository.UpdateBooking(booking);

                    _entityFrameworkRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var booking = _bookingRepository.GetBookingById(id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BookingId,NumberOfKm,StartDate,ReturnDate,OnGoing,CarId,CustomerId,Car")] Booking booking)
        {
            if (id != booking.BookingId)
                return NotFound();

            if (booking.Price < 0)
            {
                ViewBag.Message = "Nu blev det något galet med antalet körda kilometer eller datumen, återlämningsdatum måste vara senare än inlämningsdatum";
                return View(booking);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bookingRepository.UpdateBooking(booking);
                    _entityFrameworkRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }


        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var booking = _bookingRepository.GetBookingById(id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var booking = _bookingRepository.GetBookingById(id);
            _bookingRepository.RemoveBooking(booking);
            _entityFrameworkRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool BookingExists(Guid id)
        {
            return _bookingRepository.BookingExists(id);
        }
    }
}
