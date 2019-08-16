using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CBT.Entity.ViewModels
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            this.CreatedDate = DateTime.Now;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string SecurityStamp { get; set; }

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
        public string CategoryName { get; set; }

        public int ExamCategoryId { get; set; }
    }
}
