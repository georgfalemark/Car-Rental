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

namespace BiluthyrningAB.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AppDbContext _context;

        public BookingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookings.Include(x => x.Car).ToListAsync());
        }

        //GET: Bookings for a certain customer
        public async Task<IActionResult> BookingsForCertainCustomer(Guid? CustomerId)
        {
            return View(await _context.Bookings.Include(x => x.Car).Include(x => x.Customer).Where(x => x.Customer.CustomerId == CustomerId).ToListAsync());
        }

        //GET: Bookings Not ongoing
        public async Task<IActionResult> OnGoingBookings()
        {
            return View(await _context.Bookings.Include(x => x.Car).Where(x => x.OnGoing == true).ToListAsync());
        }

        //GET: Bookings ongoing
        public async Task<IActionResult> Not_OnGoingBookings()
        {
            return View(await _context.Bookings.Include(x => x.Car).Where(x => x.OnGoing == false).ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.Include(x => x.Customer).Include(x => x.Car)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET:
        public IActionResult Create()
        {
            BookingVm bookingVm = new BookingVm();


            //Fyller listan med biltyper!
            string[] arr = Enum.GetNames(typeof(CarType));
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in arr)
            {
                var y = new SelectListItem() { Text = item, Value = item };
                list.Add(y);
            }

            bookingVm.CarTypes = list;

            //Fyller listan med kunder
            var customers = _context.Customers.ToList();
            List<SelectListItem> listOfCustomers = new List<SelectListItem>();

            foreach (var customer in customers)
            {
                string wholeName = $"{customer.FirstName} {customer.LastName}";
                var x = new SelectListItem() { Text = wholeName, Value = customer.CustomerId.ToString() };
                listOfCustomers.Add(x);
            }

            bookingVm.Customers = listOfCustomers;


            return View(bookingVm);
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CustomerId,Car,StartDate")] Booking booking)
        {

            booking.ReturnDate = booking.StartDate.AddDays(1);
            booking.OnGoing = true;

            if (ModelState.IsValid)
            {
                //Lägger till bokningen i systemet
                booking.BookingId = Guid.NewGuid();
                _context.Add(booking);


                //Lägger till bilen i systemet
                booking.Car.CarId = Guid.NewGuid();
                _context.Add(booking.Car);


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            //Om det misslyckas så hämtar vi biltyperna på nytt
            BookingVm bookingVm = new BookingVm();
            string[] arr = Enum.GetNames(typeof(CarType));
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in arr)
            {
                var y = new SelectListItem() { Text = item, Value = item };
                list.Add(y);
            }
            bookingVm.CarTypes = list;

            //Om det misslyckas så hämtar vi kunderna på nytt
            var customers = _context.Customers.ToList();
            List<SelectListItem> listOfCustomers = new List<SelectListItem>();

            foreach (var customer in customers)
            {
                string wholeName = $"{customer.FirstName} {customer.LastName}";
                var x = new SelectListItem() { Text = wholeName, Value = customer.CustomerId.ToString() };
                listOfCustomers.Add(x);
            }

            bookingVm.Customers = listOfCustomers;

            return View(bookingVm);
        }

        //GET: vy för att slutföra bokning
        public async Task<IActionResult> FinishBooking(Guid? id)
        {
            if (id == null)
                return NotFound();

            var booking = _context.Bookings.Include(x => x.Car).Include(x => x.Customer).Single(x => x.BookingId == id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // POST: slutför bokningen
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

                    //uppdaterar bilens antal körda kilometer
                    booking.Car.NumberOfDrivenKm = booking.Car.NumberOfDrivenKm + Convert.ToInt32(booking.NumberOfKm);

                    //Uppdaterar sedan både bilen (för antalet mils räkning) samt bokningen
                    _context.Update(booking.Car);
                    _context.Update(booking);

                    await _context.SaveChangesAsync();
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

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var booking = _context.Bookings.Include(x => x.Car).Include(x => x.Customer).Single(x => x.BookingId == id);
            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // POST: Bookings/Edit/5
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
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
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

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(Guid id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
