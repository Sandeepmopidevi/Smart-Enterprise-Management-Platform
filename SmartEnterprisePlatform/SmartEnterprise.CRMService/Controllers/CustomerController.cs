using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartEnterprise.CRMService.Data;
using SmartEnterprise.CRMService.Models;

namespace SmartEnterprise.CRMService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly CrmDbContext _context;

        public CustomerController(CrmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Customers.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            customer.CreatedAt = DateTime.UtcNow;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }
    }
}
