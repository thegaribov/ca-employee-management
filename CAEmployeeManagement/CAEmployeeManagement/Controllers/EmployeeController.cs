using CAEmployeeManagement.Database.Contexts;
using CAEmployeeManagement.Database.Models;
using CAEmployeeManagement.Migrations;
using CAEmployeeManagement.Services;
using CAEmployeeManagement.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Net.NetworkInformation;

namespace CAEmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly EmployeeService _employeeService;

        public EmployeeController()
        {
            _dataContext = new DataContext(); //buradan eliyende usingi vere bilmirik
            _employeeService = new EmployeeService();
        }

        ~EmployeeController()
        {
            _dataContext.Dispose();
        }

        #region List


        [HttpGet]
        public IActionResult List()
        {
            var model = _dataContext.Employees
                .Where(e => e.IsDeleted == false)
                .Select(e => new ListItemViewModel(e.EmployeeCode, e.Name, e.LastName, e.FatherName))
                .ToList();

            return View(model);
        }

        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] AddViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var employee = new Database.Models.Employee
            {
                EmployeeCode = _employeeService.GetEmployeeCode(),
                Name = model.Name,
                LastName = model.LastName,
                FatherName = model.FatherName,
                Email = model.Email,
                PIN = model.PIN
            };

            _dataContext.Employees.Add(employee);
            _dataContext.SaveChanges();

            return RedirectToAction(nameof(List));
        }

        #endregion

        #region Update

        [HttpGet("Employee/Update/{employeeCode}")]
        public IActionResult Update([FromRoute] string employeeCode)
        {
            var employee = _dataContext.Employees.FirstOrDefault(e => e.EmployeeCode == employeeCode && !e.IsDeleted);
            if (employee is null)
            {
                return NotFound();
            }

            return View(new UpdateViewModel
            {
                Name = employee.Name,
                LastName = employee.LastName,
                FatherName = employee.FatherName,
                Email = employee.Email,
                PIN = employee.PIN,
                EmployeeCode = employee.EmployeeCode
            });
        }
        
        [HttpPost("Employee/Update/{employeeCode}")]
        public IActionResult Update([FromRoute] string employeeCode, [FromForm] UpdateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var employee = _dataContext.Employees.FirstOrDefault(e => e.EmployeeCode == employeeCode && !e.IsDeleted);
            if (employee is null)
            {
                return NotFound();
            }

            employee.Name = model.Name;
            employee.LastName = model.LastName;
            employee.FatherName = model.FatherName;
            employee.Email = model.Email;
            employee.PIN = model.PIN;

            _dataContext.Update(employee);
            _dataContext.SaveChanges();

            return RedirectToAction(nameof(List));
        }

        #endregion
    }
}
