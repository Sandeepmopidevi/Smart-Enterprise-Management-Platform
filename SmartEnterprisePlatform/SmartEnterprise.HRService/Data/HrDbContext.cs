using Microsoft.EntityFrameworkCore;
using SmartEnterprise.HRService.Models;
using System.Collections.Generic;

namespace SmartEnterprise.HRService.Data
{
    public class HrDbContext : DbContext
    {
        public HrDbContext(DbContextOptions<HrDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
