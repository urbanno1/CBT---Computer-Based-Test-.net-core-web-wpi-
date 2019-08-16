using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBT.DataModel.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string ImageUrl { get; set; }
        public string OtherNames { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [Required]
        [ForeignKey("ExamCategoryId")]
        public int ExamCategoryId { get; set; }

        public virtual ExamCategory ExamCategory { get; set; }
    }
}
