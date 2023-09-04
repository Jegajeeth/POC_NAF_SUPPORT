using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAFSupport.Shared.Models
{
    public class Role
    {
        [Key]
        public int roleId {  get; set; }
        public string? roleName { get; set; }
    }
}
