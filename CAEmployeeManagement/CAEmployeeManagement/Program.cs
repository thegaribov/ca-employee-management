using CAEmployeeManagement.Database.Contexts;
using CAEmployeeManagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CAEmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Native DI desing pattern (IoC container)

            // 1. IoC priciple => to avoid tightly coupled codes
            // 2. Autho dispose
            // 3. Performance 
            // Lifetime of object

            builder.Services
                .AddDbContext<DataContext>(o =>
                {
                    o.UseSqlServer("Server=MAHMOOD-PC;Database=CodeAcademy;Trusted_Connection=True;TrustServerCertificate=True;");
                }, ServiceLifetime.Transient)
                .AddScoped<EmployeeService>()
                .AddMvc()
                .AddRazorRuntimeCompilation();


            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=employee}/{action=list}");

            app.Run();
        }
    }
}