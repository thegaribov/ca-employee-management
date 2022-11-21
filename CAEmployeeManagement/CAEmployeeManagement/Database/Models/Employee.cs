using System.ComponentModel;

namespace CAEmployeeManagement.Database.Models
{
    public class Employee
    {
        public string EmployeeCode { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }
        public string PIN { get; set; }
        public bool IsDeleted { get; set; }
    }
}
