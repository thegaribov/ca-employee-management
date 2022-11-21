namespace CAEmployeeManagement.ViewModels.Employee
{
    public class ListItemViewModel
    {
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }

        public ListItemViewModel(string employeeCode, string name, string lastName, string fatherName)
        {
            EmployeeCode = employeeCode;
            Name = name;
            LastName = lastName;
            FatherName = fatherName;
        }
    }
}
