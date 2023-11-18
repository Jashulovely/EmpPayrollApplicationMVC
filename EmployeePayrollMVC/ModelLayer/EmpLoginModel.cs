using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer
{
    public class EmpLoginModel
    {
        [Required]
        public int EmpId { get; set; }
        //[Required(ErrorMessage = "Name is required")]
        //[RegularExpression(@"^[A-Z][a-z]{1,}(\s[A-Z][a-z]{2,})*$", ErrorMessage = "Name is not valid")]
        [Required]
        public string EmpName { get; set; }
    }
}
