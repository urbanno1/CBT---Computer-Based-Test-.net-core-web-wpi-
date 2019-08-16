using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CBT.DataModel.Models
{
    public class RegistrationExamSetting : ExamSetting
    {
        public int NumberToBeRegistered { get; set; }
        public int NumberRegistered { get; set; }
        public int NumberFailed { get; set; }
        public string GeneratedPassword { get; set; }
    }
}
