using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CAEmployeeManagement.Attributes.Employee
{
    public class FINValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            ArgumentNullException.ThrowIfNull(value, $"{nameof(RequiredAttribute)} requred");

            var fin = value.ToString();
            string pattern = @"^([A-Z0-9]{7}$)";
            return Regex.IsMatch(fin, pattern);
        }
    }
}
