using Microsoft.EntityFrameworkCore;
using Practial.Domain.Models;
using System;

namespace Practial.Domain
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Club> Club { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Employee>().HasOne(b => b.Department).WithMany(a => a.Employees).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
