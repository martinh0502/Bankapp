using Bankapp.Core.Interfaces;
using Bankapp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bankapp.Api.Controllers
{
    [Route("customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            Customer customer = _customerService.GetCustomer(id);

            if (customer == null) return NotFound();

            return Ok(customer);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetCustomersName(string name)
        {
            var list = _customerService.GetCustomersName(name);

            if (list == null) return NoContent();

            return Ok(list);
        }

        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {
            
            try
            {
                if (customer == null) return BadRequest("Invalid customer data");

                customer = _customerService.CreateCustomer(customer);

                return Ok(customer);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
