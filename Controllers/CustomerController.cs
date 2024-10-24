using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RannaPanelManagement.Entities;
using RannaPanelManagement.Business.Abstract;

namespace RannaPanelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController:ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _customerService.Create(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _customerService.Update(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Customer customer)
        {
            _customerService.Delete(customer);
            return NoContent();
        }
    }
}
