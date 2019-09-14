using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using vidly.Models;

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
           IList<Customer> Customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(Customers);
        }

        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{Id = 1, Name = "Jhone Smith"},
        //        new Customer{Id = 2, Name = "Freddie Mercury"}
        //    };
        //}

        void fff<T>(T source) where T : class, new()
        {
            var pl = source.GetType().GetProperties();
            var ml = source.GetType().GetMethods();
            T c = new T();
            foreach(var p in pl)
            {
                if(p.Name == "Id")
                {
                    p.SetValue(c, new object[] { 8 });
                }
                
            }
            foreach (var m in ml)
            {
                if (m.Name == "GetCustomer")
                {
                    m.Invoke(c, new object[] { 9, DateTime.Now, "poghos" });
                }

            }
        }
    }

    abstract class baseCustomer
    {
        // I'm on the call
        // Ok, I will wait for you
    }
}