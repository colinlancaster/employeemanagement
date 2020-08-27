using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Mary",
                    Department = Dept.HR,
                    Email = "mary@pragim.co"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Colin",
                    Department = Dept.IT,
                    Email = "colin@pragim.co"
                }
            );
        }
    }
}
