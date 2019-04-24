using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Controllers
{
    public class CustomersController : Controller
    {
        
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{ Id=1, Name = "Tarek"},
                new Customer{ Id=2, Name = "Eya"}
            };
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            var customer = GetCustomers().SingleOrDefault(m => m.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}