using CAEmployeeManagement.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CAEmployeeManagement.Database.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MAHMOOD-PC;Database=CodeAcademy;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
