using System;
using System.Collections.Generic;

namespace CBT.Entity.ViewModels
{
    public class ExamQuestions
    {
        public int ExamQuestionLength { get; set; }
        public int ExamTopicId { get; set; }
        public string ExamTopicName { get; set; }
        public List<ExamQuestionn> ExamQuestion { get; set; }
    }

    public class ExamQuestionn
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
        public string Answer { get; set; }
        public string QuestionType { get; set; }
        public bool QuestionChoice { get; set; }
    }

    public class ExamAnswerReport
    {
        public int TotalCorrectScore { get; set; }
        public int TotalQuestionsAnswered { get; set; }
        public int TotalQuestionLength { get; set; }

        public decimal TotalPercentageQuestionsAnswered {
            get
            {
                return Math.Floor(((decimal)TotalQuestionsAnswered / (decimal)TotalQuestionLength) * 100);
            }
        }
        public decimal PercentageTotalCorrectScore
        {
            get
            {
                return Math.Floor(((decimal)TotalCorrectScore / (decimal)TotalQuestionLength) * 100);
            }
        }

        public List<ExamAnswerScore> ExamAnswerScore { get; set; }
    }

    public class ExamAnswerScore
    {
        public string TopicName { get; set; }
        public int TopicCorrectScore { get; set; }
        public int TopicNumberAnswered { get; set; }
        public int TopicQuestionLength { get; set; }
        public decimal PercentageTopicCorrectScore
        {
            get
            {
                return Math.Floor(((decimal)TopicCorrectScore / (decimal)TopicQuestionLength) * 100);
            }
        }
    }


}
