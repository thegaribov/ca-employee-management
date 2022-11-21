using CAEmployeeManagement.Database.Contexts;
using CAEmployeeManagement.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CAEmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult List()
        {
            var dbContext = new DataContext();
            var model = dbContext.Employees
                .Where(e => e.IsDeleted == false)
                .Select(e => new ListItemViewModel(e.EmployeeCode, e.Name, e.LastName, e.FatherName))
                .ToList();

            return View(model);
        }
    }
}
