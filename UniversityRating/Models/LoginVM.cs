using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityRating.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Login not specified")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password not specified")]

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
