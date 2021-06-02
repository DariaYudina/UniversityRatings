using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityRating.Models
{
    public class RegisterVM
    {
        [RegularExpression(@"(^[A-Za-z]([_]{0,1}[A-Za-z0-9]+)*([_]{0,1}[A-Za-z0-9]+$))|(^[A-Za-z]$)", ErrorMessage = "Login is not corrected")]
        [Required(ErrorMessage = "Login not specified")]

        public string Login { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"(^[A-Za-z]([_]{0,1}[A-Za-z0-9]+)*([_]{0,1}[A-Za-z0-9]+$))|(^[A-Za-z]$)", ErrorMessage = "Password is not corrected")]
        [Required(ErrorMessage = "Password not specified")]

        public string Password { get; set; }
    }
}
