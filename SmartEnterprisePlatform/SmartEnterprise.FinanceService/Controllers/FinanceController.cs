using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartEnterprise.FinanceService.Data;
using SmartEnterprise.FinanceService.Models;

namespace SmartEnterprise.FinanceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FinanceController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public FinanceController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.FinanceEntries.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> AddEntry(FinanceEntry entry)
        {
            entry.Date = DateTime.UtcNow;
            _context.FinanceEntries.Add(entry);
            await _context.SaveChangesAsync();
            return Ok(entry);
        }
    }
}
