namespace CBT.Entity.ViewModels
{
    public class ExamInstructionViewModel
    {
        public InstructionViewModel InstructionViewModel { get; set; }
        public TimeViewModel TimeViewModel { get; set; }
    }


    public class InstructionViewModel
    {
        public string ExamInstructionTitle { get; set; }
        public string ExamInstructionBody { get; set; }
    }

}
