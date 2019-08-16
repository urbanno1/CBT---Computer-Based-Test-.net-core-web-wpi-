using System;
using System.Collections.Generic;
using System.Text;

namespace CBT.DataModel.Models
{
    public class ExamScheduleTime
    {
       
        public int ExamScheduleTimeId {get; set;}
        public int InstructionDays { get; set; }
        public int InstructionHours { get; set; }
        public int InstructionMins { get; set; }
        public int InstructionSeconds { get; set; }

        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
