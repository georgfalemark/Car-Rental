using BiluthyrningAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiluthyrningAB.Persistence.Repositories
{
    interface ICarRepository
    {
        Car GetCarById(Guid? id);
    }
}
