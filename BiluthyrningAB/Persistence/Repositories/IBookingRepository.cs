using BiluthyrningAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiluthyrningAB.Persistence.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<Booking> GetBookingsForCertainCustomer(Guid? CustomerId);
        IEnumerable<Booking> GetBookingsDependingOnStatus(bool status);

        Booking GetBookingById(Guid? id);
        bool BookingExists(Guid id);

        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void RemoveBooking(Booking booking);
    }
}
