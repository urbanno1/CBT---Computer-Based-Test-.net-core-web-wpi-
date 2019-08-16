using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBT.DataModel.Models
{
   public class ExamTopic
    {

        [Key]
        public int ExamTopicId { get; set; }

        public string ExamTopicName { get; set; }

        [Required]
        [ForeignKey("ExamCategoryId")]
        public int ExamCategoryId { get; set; }

        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ExamCategory ExamCategory { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<PreviousExamQuestion> PreviousExamQuestion { get; set; }
    }
}
