using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CBT.DataModel.Models
{
    public class AuditReport
    {
        public AuditReport()
        {
            ActionPerformedTime = DateTime.Now;
            CreatedDate = DateTime.Now;
        }

        [Key]
        public int AuditReportId { get; set; }
       
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public string SystemIpAddress { get; set; }
        [Required]
        public string ActionPerformed { get; set; }
        public DateTime ActionPerformedTime { get; set; }

        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
