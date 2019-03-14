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

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var myTask = Task.Run(() => _customerRepository.GetAllCustomers());
            return View(await myTask);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();


            var customer = _customerRepository.GetCustomerById(id);


            //var customer = await _context.Customers
            //    .FirstOrDefaultAsync(m => m.CustomerId == id);


            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,PersonNumber,FirstName,LastName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerId = Guid.NewGuid();

                _customerRepository.AddCustomer(customer);

                //_context.Add(customer);

                _entityFrameworkRepository.SaveChangesAsync();

                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetCustomerById(id);


            //var customer = await _context.Customers.FindAsync(id);



            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CustomerId,PersonNumber,FirstName,LastName")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _customerRepository.UpdateCustomer(customer);


                    //_context.Update(customer);

                    _entityFrameworkRepository.SaveChangesAsync();

                    //await _context.SaveChangesAsync();
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

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();


            var customer = _customerRepository.GetCustomerById(id);


            //var customer = await _context.Customers
            //    .FirstOrDefaultAsync(m => m.CustomerId == id);


            if (customer == null)
                return NotFound();

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var customer = _customerRepository.GetCustomerById(id);



            //var customer = await _context.Customers.FindAsync(id);


            _customerRepository.RemoveCustomer(customer);
            //_context.Customers.Remove(customer);


            _entityFrameworkRepository.SaveChangesAsync();

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(Guid id)
        {
            return _customerRepository.CustomerExists(id);


            //return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
