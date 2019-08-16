using System.Collections.Generic;

namespace CBT.Entity.ViewModels
{
    public class ExamTopicViewModel
    {
        public TopicViewModel TopicViewModel { get; set; }
        public List<ExamQuestionsViewModel> ExamQuestionsViewModels { get; set; }
    }

    public class TopicViewModel
    {
        public int ExamTopicId { get; set; }
        public string ExamTopicName { get; set; }
    }

    public class ExamQuestionsViewModel
    {
        public int ExamQuestionId { get; set; }
        public int ExamTopicId { get; set; }
        public string QuestionBody { get; set; }
        public string ImageUrl { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string OptionE { get; set; }
        public string Answer {
            get
            {
                return null;
            }
        }
        public string QuestionType { get; set; }
        public bool QuestionChoice { get; set; }
    }
}
