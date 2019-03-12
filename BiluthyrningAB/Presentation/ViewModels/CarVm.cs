using BiluthyrningAB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiluthyrningAB.ViewModels
{
    public class CarVm
    {
        public Car Car { get; set; }
        public List<SelectListItem> CarTypes { get; set; }
    }
}
