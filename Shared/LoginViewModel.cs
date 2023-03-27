using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tool.Shared
{
    public class LoginViewModel
    {
        public int Id
        {
            get;
            set;
        }
        [Required]
        [EmailAddress]
        [RegularExpression(".*@persistent\\.com$",
    ErrorMessage = "Email must contain @persistent.com")]
        public string Email
        {
            get;
            set;
        }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$",
            ErrorMessage = "Passwords must be at least 8 characters and contain the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password
        {
            get;
            set;
        }
    }
}