using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Security.Cryptography;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {        
            return View(_context.Customers.Include(customer => customer.MembershipType).ToList());
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c=>c.Id== id);

            if(customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel formViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = formViewModel.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (formViewModel.Customer.Id == 0)
            {
                _context.Customers.Add(formViewModel.Customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == formViewModel.Customer.Id);

                customerInDb.Name = formViewModel.Customer.Name;
                customerInDb.Birthday = formViewModel.Customer.Birthday;
                customerInDb.MembershipTypeId = formViewModel.Customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = formViewModel.Customer.IsSubscribedToNewsletter;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);

        }
    }
}