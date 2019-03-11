using BiluthyrningAB.Controllers;
using BiluthyrningAB.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiluthyrningAB.Models
{
    public class Booking
    {
        [Display(Name = "Bokningsnummer")]
        public Guid BookingId { get; set; }

        private readonly decimal baseDayRental = 100;
        private readonly decimal kmPrice = 5;

        [Display(Name = "Pris")]
        public decimal Price
        {
            get
            {
                string[] carTypes = Enum.GetNames(typeof(CarType));

                if (Car?.CarType.ToString() == null)    //nån slags indikation på att priset blir fel
                    return 1;                           

                if (carTypes.Single(x => x == "Small") == Car.CarType.ToString())
                {
                    return baseDayRental * NumberOfDays;
                }
                else if (carTypes.Single(x => x == "Van") == Car.CarType.ToString())
                {
                    return (baseDayRental * NumberOfDays * 1.2m) + (kmPrice * NumberOfKm);
                }
                else if (carTypes.Single(x => x == "Minibus") == Car.CarType.ToString())
                {
                    return (baseDayRental * NumberOfDays * 1.7m) + (kmPrice * NumberOfKm * 1.5m);
                }

                throw new Exception("Hittade inte bilmodellen");
            }
        }

        [Display(Name = "Antal körda kilometer")]
        public decimal NumberOfKm { get; set; }

        [Display(Name = "Uthyrningsdatum")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Inlämningssdatum")]
        public DateTime ReturnDate { get; set; }

        public decimal NumberOfDays
        {
            get
            {
                int hours = (ReturnDate - StartDate).Hours;
                int minutes = (ReturnDate - StartDate).Minutes;
                int seconds = (ReturnDate - StartDate).Seconds;

                if (hours == 0 && minutes == 0 && seconds == 0)
                {
                    return Convert.ToDecimal((ReturnDate - StartDate).Days);
                }
                else
                {
                    return Convert.ToDecimal((ReturnDate - StartDate).Days + 1);
                }
            }
        }

        [Display(Name = "Pågående")]
        public bool OnGoing { get; set; }

        public Car Car { get; set; }                //En bokning innehåller en bil (SO FAR)
        public Guid CarId { get; set; }

        public Customer Customer { get; set; }      //En bokning innehåller en kund (SO FAR)
        public Guid CustomerId { get; set; }
    }
}
