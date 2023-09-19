using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAFSupport.Shared.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        //ticked id, created by, assigned to, status, start date, end date, priority, severity, due by, view, edit, delete, escalate/reopen
        public string? ticketId { get; set; }
        public string createdBy { get; set; }
        public string assignedBy { get; set; }
        public int status { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int priority { get; set; }
        public int severity { get; set; }

    }
}
