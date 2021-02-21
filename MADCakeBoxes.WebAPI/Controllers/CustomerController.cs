using MADCakeBoxes.Models;
using MADCakeBoxes.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MADCakeBoxes.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            CustomerService service = CreateCustomerService();

            if (!service.CreateCustomer(customer)) return BadRequest();
            return Ok();
        }
        public IHttpActionResult Put(CustomerEdit customer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            CustomerService service = CreateCustomerService();

            if (!service.UpdateCustomer(customer)) return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            CustomerService service = CreateCustomerService();

            if (!service.DeleteCustomer(id)) return InternalServerError();
            return Ok();
        }
        public IHttpActionResult GetCustomer(int id)
        {
            CustomerService service = CreateCustomerService();
            var cart = service.GetCustomerById(id);
            return Ok(cart);
        }
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var customerService = new CustomerService(userId);
            return customerService;
        }
    }
}
