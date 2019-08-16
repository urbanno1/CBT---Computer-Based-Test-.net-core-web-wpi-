using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBT.DataModel.Models
{
    public class ExamOption
    {
        [Key]
        public int ExamOptionId { get; set; }

        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string OptionE { get; set; }

        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        //[Required]
        //[ForeignKey("ExamQuestionId")]
        //public int ExamQuestionId { get; set; }
       // public virtual ExamQuestion ExamQuestion { get; set; }
    }
}
