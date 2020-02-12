using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using vidly.Dtos;
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

        public IHttpActionResult GetCutomers()
        {
            var customersDtos =  _context.Customers
                .Include(x => x.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customersDtos);
        }

        public CustomerDto GetCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer, CustomerDto>(customer); ;
        }

        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return  customerDto;
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var CustomerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, CustomerInDb);
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
