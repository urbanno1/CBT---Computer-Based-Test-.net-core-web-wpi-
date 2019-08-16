using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CBT.DataModel.Models;
using CBT.DataModel.Stored_Procedure.Abstract;
using CBT.DataModel.UnitOfWork.Abstract;
using CBT.Entity.ViewModels;
using CBT.Service.Candidate.Abstract;
using CBT.Service.Helpers;

namespace CBT.Service.Candidate.Concrete
{
    public class CandidateService : ICandidateService
    {
        #region private variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoredProcedure _storedProcedure;
        #endregion
        #region constructor
        public CandidateService(IUnitOfWork unitOfWork, IStoredProcedure storedProcedure)
        {
            this._unitOfWork = unitOfWork;
            this._storedProcedure = storedProcedure;
        }

        #endregion

        #region public methods
        public object GetExamQuestionModels(string userId, string timeLookUp)
        {
            if (timeLookUp == "Instruction")
            {
                return GetExamInstruction(userId, timeLookUp);
            }
            else if (timeLookUp == "MainQuestion")
            {
                return GetExamQuestions(userId, timeLookUp);
            }
            return null;
        }

        public ExamInstructionViewModel GetExamInstruction(string userId, string timeLookUp)
        {
            try
            {
                var timeObject = _storedProcedure.GetTimeObject(timeLookUp);
                var instruction = _storedProcedure.GetExamInstruction();
                var examInstruction = Mapper.Map<ExamInstruction, InstructionViewModel>(instruction);
                var examtimeObject = Mapper.Map<ExamScheduleTime, TimeViewModel>(timeObject);

                var examTimeInstruction = new ExamInstructionViewModel()
                {
                    InstructionViewModel = examInstruction,
                    TimeViewModel = examtimeObject
                };
                return examTimeInstruction;
            }
            catch (Exception ex)
            {
                string errorMessage = "GetExamInstruction(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
                return new ExamInstructionViewModel();
            }
        }

        public ExamMainQuestionViewModel GetExamQuestions(string userId, string timeLookUp)
        {
            try
            {
                //Get sql time object
                var timeObjectSql = _storedProcedure.GetTimeObject(timeLookUp);
                //Get time Object mapping
                var examTimeObjectMapping = Mapper.Map<ExamScheduleTime, TimeViewModel>(timeObjectSql);

                //Get Exam topic sql
                var examTopicsQL = _storedProcedure.GetExamTopics(userId);
                //Get Exam Topic mapping
                var examTopicMapping = Mapper.Map<List<ExamTopic>, List<TopicViewModel>>(examTopicsQL);

                //initialize the view model to carry topic and subsquent question lists
                var examExamQuestionModel = new List<ExamTopicViewModel>();
                //Iterate over topics to get all the questions under it.
                foreach (var topic in examTopicMapping)
                {
                    //Get sql exam questions
                    var examQuestionSql = _storedProcedure.GetExamQuestions(topic.ExamTopicId);
                    if (examQuestionSql.Count() > 0)
                    {
                        ShuffleList.Shuffle(examQuestionSql);
                        try
                        {
                            var examQuestionModel = Mapper.Map<List<ExamQuestion>, List<ExamQuestionsViewModel>>(examQuestionSql);
                            var examTopicModels = new ExamTopicViewModel()
                            {
                                TopicViewModel = topic,
                                ExamQuestionsViewModels = examQuestionModel,
                            };
                            examExamQuestionModel.Add(examTopicModels);
                        }
                        catch (Exception ex) { }
                    }
                }
                //Return the View models carrying all the questions.
                var examTimeInstruction = new ExamMainQuestionViewModel()
                {
                    ExamTopicViewModels = examExamQuestionModel,
                    TimeViewModel = examTimeObjectMapping
                };
                return examTimeInstruction;
            }
            catch (Exception ex)
            {
                string errorMessage = "GetExamQuestions(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
                return new ExamMainQuestionViewModel();
            }
        }

        public AspNetUserViewModel GetUserCLaims(string userId)
        {
            try
            {
                var user = _storedProcedure.GetUserClaimsView(userId);
                var userObject = Mapper.Map<ApplicationUserView, AspNetUserViewModel>(user);
                return userObject;
            }
            catch (Exception ex)
            {
                string errorMessage = "GetUserCLaims(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
                return new AspNetUserViewModel();
            }
        }

        public ApplicationUser GetUserViewModel(RegisterViewModel model)
        {
            if (model != null)
            {
                try
                {
                    var user = new RegisterViewModel
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        OtherNames = model.OtherNames,
                        PhoneNumber = model.PhoneNumber,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        Gender = model.Gender,
                        Status = 0,
                        ExamCategoryId = model.ExamCategoryId,
                    };
                    var userModel = Mapper.Map<RegisterViewModel, ApplicationUser>(user);
                    return userModel;
                }
                catch (Exception ex)
                {
                    var userId = "Enroll User";
                    string errorMessage = "GetUserViewModel(): " + ex.Message;
                    _unitOfWork.AuditTrail(errorMessage, userId);
                    return new ApplicationUser();
                }
            }
            else
                return new ApplicationUser();
        }

        public List<ExamCategoryViewModel> GetCatgoryList()
        {
            try
            {
                var categoryList = _storedProcedure.GetCategoryList();
                var categoryListMapping = Mapper.Map<List<ExamCategory>, List<ExamCategoryViewModel>>(categoryList);
                return categoryListMapping;
            }
            catch (Exception ex)
            {
                var userId = "Enroll User";
                string errorMessage = "GetCatgoryList(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
                return new List<ExamCategoryViewModel>();
            }
        }

        public bool GetToggledSettings(string settingLookUp)
        {
            try
            {
                var isSetting = _storedProcedure.GetToggledSettings(settingLookUp);
                return isSetting;
            }
            catch (Exception ex)
            {
                var userId = "Enroll User";
                string errorMessage = "GetToggledSettings(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
                return false;
            }
        }

        public int GetNumberToBeRegistered(string settingLookUp)
        {
            try
            {
                var numberToBeRegistered = _storedProcedure.GetNumberToBeRegistered(settingLookUp);
                return numberToBeRegistered;
            }
            catch (Exception ex)
            {
                var userId = "Enroll User";
                string errorMessage = "GetNumberToBeRegistered(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
                return 0;
            }
        }

        public int GetNumberSuccessfullyRegistered(string settingLookUp)
        {
            try
            {
                var successullyRegistered = _storedProcedure.GetNumberSuccessfullyRegistered(settingLookUp);
                return successullyRegistered;
            }
            catch (Exception ex)
            {
                var userId = "Enroll User";
                string errorMessage = "GetNumberSuccessfullyRegistered(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
                return 0;
            }
        }

        public int GetNumberFailedRegistered(string settingLookUp)
        {
            try
            {
                var failedRegistered = _storedProcedure.GetNumberFailedRegistered(settingLookUp);
                return failedRegistered;
            }
            catch (Exception ex)
            {
                var userId = "Enroll User";
                string errorMessage = "GetNumberFailedRegistered(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
                return 0;
            }
        }

        public string GetGeneratedPassword(string settingLookUp)
        {
            try
            {
                var password = _storedProcedure.GetGeneratedPassword(settingLookUp);
                return password;
            }
            catch (Exception ex)
            {
                var userId = "Enroll User";
                string errorMessage = "GetGeneratedPassword(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
                return new string("");
            }
        }

        public void UpdateExamSettingFailedRegisteration(int failedRegistered, string settingLookUp)
        {
            try
            {
                _storedProcedure.UpdateExamSettingFailedRegisteration(failedRegistered, settingLookUp);
            }
            catch (Exception ex)
            {
                var userId = "Enroll User";
                string errorMessage = "UpdateExamSettingFailedRegisteration(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
            }
        }

        public void UpdateExamSettingAfterSuccessfulRegisteration(int successfullRegistered, string password, string settingLookUp)
        {
            try
            {
                _storedProcedure.UpdateExamSettingAfterSuccessfulRegisteration(successfullRegistered, password, settingLookUp);
            }
            catch (Exception ex)
            {
                var userId = "Enroll User";
                string errorMessage = "UpdateExamSettingAfterSuccessfulRegisteration(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
            }
        }

        //Submit exam questions
        public ExamAnswerReport SubmitExamQuestions(string userId, List<ExamQuestions> examArrays)
        {
            try
            {
                int totalExamLength = 0;
                int totalCorrectScore = 0;
                int totalQuestionsAnswered = 0;

                var examScore = new List<ExamAnswerScore>();

                foreach (var score in examArrays)
                {
                    var examScoreCalculation = GetStoredProceedureExamQuestionScore(score.ExamQuestion, score.ExamTopicId);


                    totalExamLength += score.ExamQuestionLength;
                    totalCorrectScore += examScoreCalculation.topicCorrectScore;
                    totalQuestionsAnswered += examScoreCalculation.numberOfAnswered;

                    var modelScore = new ExamAnswerScore
                    {
                        TopicName = score.ExamTopicName,
                        TopicQuestionLength = score.ExamQuestionLength,
                        TopicCorrectScore = examScoreCalculation.topicCorrectScore,
                        TopicNumberAnswered = examScoreCalculation.numberOfAnswered,
                    };
                    examScore.Add(modelScore);
                }

                //Return the View models carrying all the result reports.
                var examresultReport = new ExamAnswerReport()
                {
                    TotalQuestionLength = totalExamLength,
                    TotalCorrectScore = totalCorrectScore,
                    TotalQuestionsAnswered = totalQuestionsAnswered,

                    ExamAnswerScore = examScore
                };
                return examresultReport;
            }
            catch (Exception ex)
            {
                string errorMessage = "SubmitExamQuestions(): " + ex.Message;
                _unitOfWork.AuditTrail(errorMessage, userId);
                return new ExamAnswerReport();
            }
        }
        public (int topicCorrectScore, int numberOfAnswered) GetStoredProceedureExamQuestionScore(List<ExamQuestionn> examQuestionns, int topicId)
        {
            try
            {
                int numberAnswered = 0;
                int topicCorrectscore = 0;
                if(examQuestionns.Count() > 0)
                {
                    foreach (var questions in examQuestionns)
                    {
                        //Get sql exam questions
                        var examQuestionSql = _storedProcedure.GetExamQuestions(topicId);
                        if (questions.Answer != null)
                        {
                            numberAnswered++;
                            var score = examQuestionSql.Where(c => c.Answer.ToLower().Trim() == questions.Answer.ToLower().Trim() && c.ExamQuestionId == questions.ExamQuestionId).FirstOrDefault();
                            if (score != null)
                            {
                                topicCorrectscore++;
                            }
                        }
                    }
                    return (topicCorrectscore, numberAnswered);
                }
                return (0,0);
            }
            catch(Exception ex)
            {
                return (0, 0);
            }
           
        }

        #endregion
    }
}
