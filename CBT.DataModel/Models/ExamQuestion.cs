using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBT.DataModel.Models
{
    public class ExamQuestion
    {

        [Key]
        public int ExamQuestionId { get; set; }
        [Required]
        public string QuestionBody { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        public string Answer { get; set; }
        public string QuestionType  { get; set; }
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

        [Required]
        [ForeignKey("ExamTopicId")]
        public int ExamTopicId { get; set; }
        public virtual ExamTopic ExamTopic { get; set; }
    }
}
