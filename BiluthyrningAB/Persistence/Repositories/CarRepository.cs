using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiluthyrningAB.Data;
using BiluthyrningAB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiluthyrningAB.Persistence.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddCar(Car car)
        {
            _context.Add(car);
        }

        public void UpdateCar(Car car)
        {
            _context.Update(car);
        }

        public void RemoveCar(Car car)
        {
            _context.Cars.Remove(car);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public IEnumerable<Car> GetCarsDependingOnBookingStatus(bool status)
        {
            return _context.Cars.Where(x => x.Booked == status).ToList();
        }

        public Car GetCarById(Guid? id)
        {
            return _context.Cars.Single(x => x.CarId == id);
        }

        public bool CarExists(Guid id)
        {
            return _context.Cars.Any(e => e.CarId == id);
        }
    }
}
