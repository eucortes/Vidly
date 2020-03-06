using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }
        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }
        //GET /api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id==id);
            if (customer==null)
               return NotFound();// throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Mapper.Map<Customer,CustomerDto>(customer)) ;
        }
        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            Customer customer=Mapper.Map<CustomerDto,Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            //customerDto=Mapper.Map<Customer,CustomerDto>(customer);
            customerDto.Id=customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id), customerDto);

        }
        //PUT 7api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb=_context.Customers.SingleOrDefault(c=>c.Id==id);
            if (customerInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto,customerInDb);
            _context.SaveChanges();
        }
        //DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }
    }
}
