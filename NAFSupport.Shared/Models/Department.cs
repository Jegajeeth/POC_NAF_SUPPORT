using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAFSupport.Shared.Models
{
    public class Department
    {
        [Key]
        public int departmentRefId {  get; set; }
        public string departmentName { get; set; }
    }
}
