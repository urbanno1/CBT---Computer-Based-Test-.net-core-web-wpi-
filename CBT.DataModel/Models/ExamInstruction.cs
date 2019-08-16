using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CBT.DataModel.Models
{
    public class ExamInstruction
    {
        [Key]
        public int ExamInstructionId { get; set; }
        public string ExamInstructionTitle { get; set; }
        public string ExamInstructionBody { get; set; }

        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
