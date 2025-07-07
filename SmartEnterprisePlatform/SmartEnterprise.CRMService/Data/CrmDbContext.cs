using Microsoft.EntityFrameworkCore;
using SmartEnterprise.CRMService.Models;

namespace SmartEnterprise.CRMService.Data
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
