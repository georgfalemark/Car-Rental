using BiluthyrningAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiluthyrningAB.Persistence.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetCarsDependingOnBookingStatus(bool status);

        Car GetCarById(Guid? id);
        bool CarExists(Guid id);

        void AddCar(Car car);
        void UpdateCar(Car car);
        void RemoveCar(Car car);
    }
}
