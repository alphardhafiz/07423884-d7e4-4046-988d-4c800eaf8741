using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(GenerateSeedData());
        }

        private IEnumerable<Employee> GenerateSeedData()
        {
            var employees = new List<Employee>();
            for (int i = 1; i <= 20; i++)
            {
                employees.Add(new Employee
                {
                    Id = i,
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                    Position = $"Position{i}",
                    Phone = $"123-456-78{i:D2}",
                    Email = $"email{i}@example.com"
                });
            }

            return employees;
        }
    }
}