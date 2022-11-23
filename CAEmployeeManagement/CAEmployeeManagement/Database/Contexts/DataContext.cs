using CAEmployeeManagement.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CAEmployeeManagement.Database.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
           
        }


        public DbSet<Employee> Employees { get; set; }
    }
}
