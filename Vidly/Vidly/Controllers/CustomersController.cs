using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            return View();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(_context.Customers.Include(c => c.MembershipType).ToList());
        }

        public ActionResult CustomerDetails(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}