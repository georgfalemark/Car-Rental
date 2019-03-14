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
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IEntityFrameworkRepository _entityFrameworkRepository;

        public CarsController(ICarRepository carRepository, IEntityFrameworkRepository entityFrameworkRepository)
        {
            _carRepository = carRepository;
            _entityFrameworkRepository = entityFrameworkRepository;
        }


        public async Task<IActionResult> Index()
        {
            var myTask = Task.Run(() => _carRepository.GetAllCars());
            return View(await myTask);
        }


        public async Task<IActionResult> CarsNotBooked()
        {
            var myTask = Task.Run(() => _carRepository.GetCarsDependingOnBookingStatus(false));
            return View(await myTask);
        }


        public async Task<IActionResult> CarsBooked()
        {
            var myTask = Task.Run(() => _carRepository.GetCarsDependingOnBookingStatus(true));
            return View(await myTask);
        }


        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var car = _carRepository.GetCarById(id);
                
            if (car == null)
                return NotFound();

            return View(car);
        }


        public IActionResult Create()
        {
            CarVm carTypeVm = new CarVm();

            carTypeVm.CarTypes = GetCarTypesToSelectList();

            return View(carTypeVm);
        }


        private List<SelectListItem> GetCarTypesToSelectList()
        {
            string[] arr = Enum.GetNames(typeof(CarType));
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in arr)
            {
                var y = new SelectListItem() { Text = item, Value = item };
                list.Add(y);
            }

            return list;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,LicenseNumber,CarType")] Car car)
        {
            if (ModelState.IsValid)
            {
                car.CarId = Guid.NewGuid();
                _carRepository.AddCar(car);

                _entityFrameworkRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var car = _carRepository.GetCarById(id);

            if (car == null)
                return NotFound();

            CarVm carTypeVm = new CarVm();

            carTypeVm.CarTypes = GetCarTypesToSelectList();
            carTypeVm.Car = car;

            return View(carTypeVm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CarId,LicenseNumber,CarType,NumberOfDrivenKm")] Car car)
        {
            if (id != car.CarId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _carRepository.UpdateCar(car);
                    _entityFrameworkRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
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

            CarVm carTypeVm = new CarVm();

            carTypeVm.CarTypes = GetCarTypesToSelectList();
            carTypeVm.Car = car;

            return View(carTypeVm);
        }


        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var car = _carRepository.GetCarById(id);

            if (car == null)
                return NotFound();

            return View(car);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var car = _carRepository.GetCarById(id);
            _carRepository.RemoveCar(car);
            _entityFrameworkRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CarExists(Guid id)
        {
            return _carRepository.CarExists(id);
        }
    }
}
