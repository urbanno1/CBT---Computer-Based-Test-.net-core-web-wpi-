using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBT.DataModel.Models
{
    public class PreviousExamQuestion
    {
        private bool questionChoice;

        [Key]
        public int ExamQuestionId { get; set; }
        public string ImageUrl { get; set; }

        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string OptionE { get; set; }

        [Required]
        public string Answer { get; set; }

        public string QuestionType { get; set; }

        public bool QuestionChoice
        {
            get
            {
                if (QuestionChoice.ToString() == "Multiple Choice")
                    return questionChoice = true;
                else
                    return questionChoice = false;
            }
            set { this.questionChoice = value; }
        }

        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        //[Required]
        //[ForeignKey("ExamTopicId")]
        //public int ExamTopicId { get; set; }
        public virtual ExamTopic ExamTopic { get; set; }
    }
}
