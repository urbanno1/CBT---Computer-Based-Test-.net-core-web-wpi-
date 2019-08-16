using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CBT.DataModel.Models
{
    public class ExamCategory
    {
        [Key]
        public int ExamCategoryId { get; set; }

        public Nullable<int> ParentExamCategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<ExamTopic> ExamTopics { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
