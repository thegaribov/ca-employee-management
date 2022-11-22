using CAEmployeeManagement.Attributes.Employee;
using System.ComponentModel.DataAnnotations;

namespace CAEmployeeManagement.ViewModels.Employee
{
    public class AddViewModel : BaseViewModel
    {
        [Required]
        [FINValidation]
        public string PIN { get; set; }
        public string Email { get; set; }
    }
}
