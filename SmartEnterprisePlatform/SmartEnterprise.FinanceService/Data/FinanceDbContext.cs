using Microsoft.EntityFrameworkCore;
using SmartEnterprise.FinanceService.Models;
using System.Collections.Generic;

namespace SmartEnterprise.FinanceService.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }

        public DbSet<FinanceEntry> FinanceEntries { get; set; }
    }
}
