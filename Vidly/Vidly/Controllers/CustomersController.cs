using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> _customers = new List<Customer>
        {
            new Customer{ Id = 1, Name = "John Smith"},
            new Customer{ Id = 2, Name = "Mary Williams"}
        };

        // GET: Customers
        public ActionResult Index()
        {
            return View(_customers);
        }

        public ActionResult CustomerDetails(int Id)
        {
            var customer = _customers.Where(x => x.Id == Id).FirstOrDefault();

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}