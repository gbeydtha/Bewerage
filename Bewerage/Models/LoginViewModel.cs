using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bewerage.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name="User Name")]
        public string  Usernname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string RetunrUrl { get; set; }
    }
}
