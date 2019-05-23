using MovieRental.Models;
using MovieRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MovieRental.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(m => m.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(m => m.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var customerFormViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View(customerFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var membershipTypes = _context.MembershipTypes.ToList();

                var customerFormViewModel = new CustomerFormViewModel()
                {
                    MembershipTypes = membershipTypes,
                    Customer = customer
                };

                return View(customerFormViewModel);
            }
            else
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var customerFormViewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View(customerFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var membershipTypes = _context.MembershipTypes.ToList();

                var customerFormViewModel = new CustomerFormViewModel()
                {
                    MembershipTypes = membershipTypes,
                    Customer = customer
                };

                return View(customerFormViewModel);
            }
            else
            {

                var updatedCustomer = _context.Customers.Single(c => c.Id == customer.Id);

                updatedCustomer.Name = customer.Name;
                updatedCustomer.Birthday = customer.Birthday;
                updatedCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                updatedCustomer.MembershipTypeId = customer.MembershipTypeId;

                _context.SaveChanges();

                return RedirectToAction("index");
            }
        }
    }
}