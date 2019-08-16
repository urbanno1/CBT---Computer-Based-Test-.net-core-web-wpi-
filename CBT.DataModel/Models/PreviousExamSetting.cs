using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CBT.DataModel.Models
{
    public class PreviousExamSetting 
    {
       
        [Key]
        public int ExamSettingId { get; set; }
        [Required]
        public bool ToggleExamSetting { get; set; }
        [Required]
        public string ExamSettingLookUp { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        public int NumberToBeRegistered { get; set; }
        public string GeneratedPassword { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
