using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiluthyrningAB.Models
{
    public class Car
    {
        public Guid CarId { get; set; }

        [Display(Name = "Nummerskylt")]
        [Required (ErrorMessage = "Du måste ange ett registreringsnummer på bilen")]
        [RegularExpression("[A-ZÅÄÖ]{3}[0-9]{3}", ErrorMessage = "Ange formatet ABC123 tack")]
        public string LicenseNumber { get; set; }

        [Display(Name = "Biltyp")]
        [Required (ErrorMessage = "Du måste ange vilken typ av bil det är")]
        public CarType CarType { get; set; }

        [Display(Name = "Antal körda mil")]
        public int NumberOfDrivenKm { get; set; }

        public List<Booking> Bookings { get; set; }   //En till mångarelation gentemot bokningar, "1 bil kan finnas i flera bokningar"
    }

    public enum CarType
    {
        Small,
        Van,
        Minibus
    };
}
