using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiluthyrningAB.Data;
using BiluthyrningAB.Models;
using BiluthyrningAB.Persistence.Repositories;

namespace BiluthyrningAB.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEntityFrameworkRepository _entityFrameworkRepository;

        public CustomersController(ICustomerRepository customerRepository, IEntityFrameworkRepository entityFrameworkRepository)
        {
            _customerRepository = customerRepository;
            _entityFrameworkRepository = entityFrameworkRepository;
        }


        public async Task<IActionResult> Index()
        {
            var myTask = Task.Run(() => _customerRepository.GetAllCustomers());
            return View(await myTask);
        }


        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,PersonNumber,FirstName,LastName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerId = Guid.NewGuid();
                _customerRepository.AddCustomer(customer);

                _entityFrameworkRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CustomerId,PersonNumber,FirstName,LastName")] Customer customer)
        {
            if (id != customer.CustomerId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _customerRepository.UpdateCustomer(customer);

                    _entityFrameworkRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }


        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            _customerRepository.RemoveCustomer(customer);

            _entityFrameworkRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CustomerExists(Guid id)
        {
            return _customerRepository.CustomerExists(id);
        }
    }
}
