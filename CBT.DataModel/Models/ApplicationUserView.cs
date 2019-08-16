using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CBT.DataModel.Models
{
   public class ApplicationUserView
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ImageUrl { get; set; }
        public string OtherNames { get; set; }
        public string Discriminator { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
