using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModel;

namespace vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ViewResult Index()
        {
            var Customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(Customers);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var CustomerIdDb = _context.Customers.Single(c => c.Id == customer.Id);

                CustomerIdDb.Name = customer.Name;
                CustomerIdDb.Birthday = customer.Birthday;
                CustomerIdDb.MembershipTypeId = customer.MembershipTypeId;
                CustomerIdDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var ViewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(ViewModel);
        }    
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == Id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }
    }

}