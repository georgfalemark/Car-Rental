using BiluthyrningAB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiluthyrningAB.ViewModels
{
    public class BookingVm
    {
        public Booking Booking { get; set; }
        public List<SelectListItem> Cars { get; set; }
        public List<SelectListItem> Customers { get; set; }
    }
}
