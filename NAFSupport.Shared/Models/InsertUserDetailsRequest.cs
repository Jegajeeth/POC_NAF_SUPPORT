using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAFSupport.Shared.Models
{
    public class InsertUserDetailsRequest
    {

        [Required(ErrorMessage = "Name is required")]
        public string? name {  get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? password { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public string? department { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string? role { get; set; }
    }
}
