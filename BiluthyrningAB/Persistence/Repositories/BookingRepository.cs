using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiluthyrningAB.Data;
using BiluthyrningAB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiluthyrningAB.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAllBookings() 
        {
            return _context.Bookings.Include(x => x.Car).ToList();
        }

        public IEnumerable<Booking> GetBookingsForCertainCustomer(Guid? CustomerId)
        {
            return _context.Bookings.Include(x => x.Car).Include(x => x.Customer).Where(x => x.Customer.CustomerId == CustomerId).ToList();
        }

        public IEnumerable<Booking> GetBookingsDependingOnStatus(bool status)
        {
            return _context.Bookings.Include(x => x.Car).Where(x => x.OnGoing == status).ToList();
        }

        public Booking GetBookingById(Guid? id)
        {
            return _context.Bookings.Include(x => x.Customer).Include(x => x.Car)
                .FirstOrDefault(m => m.BookingId == id);
        }

        public bool BookingExists(Guid id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }

        public void AddBooking(Booking booking)
        {
            _context.Add(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Update(booking);
        }

        public void RemoveBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
        }

    }
}
