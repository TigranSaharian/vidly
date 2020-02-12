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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
            }
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
            return View("CustomerForm", ViewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
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