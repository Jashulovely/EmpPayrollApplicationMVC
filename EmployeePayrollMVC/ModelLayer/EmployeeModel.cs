using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer
{
    public class EmployeeModel
    {

        public int EmpId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Z][a-z]{1,}(\s[A-Z][a-z]{2,})*$", ErrorMessage = "Name is not valid")]
        public string EmpName { get; set; }
        [Required]
        public string ProfileImage { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}
