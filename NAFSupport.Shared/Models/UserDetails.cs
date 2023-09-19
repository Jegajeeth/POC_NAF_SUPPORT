using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAFSupport.Shared.Models
{
    public class UserDetails
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? role { get; set; }
        public virtual int? roleId { set; get; }
        [ForeignKey("roleId")]
        //public virtual Role employeeRole { get; set; }
        public string? department { get; set; }

        [ForeignKey("departmentRefId")]
        public virtual int? departmentRefId { get; set; }
        
        //public virtual Department employeeDepartment { get; set; }

    }
}
