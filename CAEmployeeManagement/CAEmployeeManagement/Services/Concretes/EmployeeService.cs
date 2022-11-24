using CAEmployeeManagement.Database.Contexts;
using CAEmployeeManagement.Services.Abstracts;
using System;

namespace CAEmployeeManagement.Services.Concretes
{
    public class EmployeeService : IEmployeeService
    {
        public readonly DataContext _dataContext;
        private const string EMPLOYEE_CODE_PREFIX = "E";
        private const int EMPLOYEE_CODE_MIN_RANGE = 10000;
        private const int EMPLOYEE_CODE_MAX_RANGE = 100000;

        public EmployeeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public string GetEmployeeCode()
        {
            string employeeCode = null;

            do
            {
                employeeCode = GenerateEmployeeCode();

            } while (_dataContext.Employees.Any(e => e.EmployeeCode == employeeCode));

            return employeeCode;
        }

        private string GenerateEmployeeCode()
        {
            var random = new Random();
            var randomNumber = random.Next(EMPLOYEE_CODE_MIN_RANGE, EMPLOYEE_CODE_MAX_RANGE);
            return string.Concat(EMPLOYEE_CODE_PREFIX, randomNumber);
        }
    }
}
