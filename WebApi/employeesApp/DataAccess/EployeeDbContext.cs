using EmployeesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.DataAccess
{
    public class EployeeDbContext : DbContext
    {
        public DbSet<Position> Position { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}