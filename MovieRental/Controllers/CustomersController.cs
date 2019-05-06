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

            var newCustomer = new NewCustomer()
            {
                MembershipTypes = membershipTypes
            };

            return View(newCustomer);
        }
    }
}