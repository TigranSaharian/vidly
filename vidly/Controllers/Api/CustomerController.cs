using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using vidly.Models;

namespace vidly.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Customer> GetCutomers()
        {
            return _context.Customers;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var CustomerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            CustomerInDb.Name = customer.Name;
            CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
            CustomerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            CustomerInDb.Birthday = customer.Birthday;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
