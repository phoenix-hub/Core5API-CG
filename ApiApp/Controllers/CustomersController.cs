
using ApiApp.Models;
using ApiApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        [HttpGet]
        [Route("api/[Controller]")]
        //[ProducesResponseType(typeof(List<CustomerDto>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetCustomers()
        {
            var listCustomer = await _customerServices.GetCustomers();
            if (!listCustomer.Any())
            {
                return NotFound($"Record not found.");
            }
            return Ok(listCustomer);
        }

        [HttpGet]
        [Route("api/[Controller]/ByCategory/{Category}")]
        [ProducesResponseType(typeof(List<CustomerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetCustomersByCategory(string Category)
        {
            if (string.IsNullOrEmpty(Category))
            {
                return BadRequest($"Please select any category.");
            }

            var listCustomer = await _customerServices.GetCustomersByCategory(Category);
            if (!listCustomer.Any())
            {
                return NotFound($"Customers having category name  \"{Category}\"  are not found.");
            }
            else
            {
                return Ok(listCustomer);
            }
        }


        [HttpGet]
        [Route("api/[Controller]/CustomerCategories")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CustomerCategories()
        {
            var listCustomer = await _customerServices.GetCustomerCategories();
            if (!listCustomer.Any())
            {
                return NotFound($"Customer's Categories not found.");
            }
            else
            {
                return Ok(listCustomer); 
            }
        }
    
    }
}
