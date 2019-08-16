using CBT.DataModel.Models;
using CBT.Entity.ViewModels;
using System.Collections.Generic;

namespace CBT.Service.Candidate.Abstract
{
    public interface ICandidateService
    {
        ApplicationUser GetUserViewModel(RegisterViewModel model);
        
        AspNetUserViewModel GetUserCLaims(string userId);
        List<ExamCategoryViewModel> GetCatgoryList();
        object GetExamQuestionModels(string userId, string timeLookUp);
        ExamInstructionViewModel GetExamInstruction(string userId, string timeLookUp);
        ExamMainQuestionViewModel GetExamQuestions(string userId, string timeLookUp);
        bool GetToggledSettings(string settingLookUp);
        int GetNumberToBeRegistered(string settingLookUp);
        int GetNumberSuccessfullyRegistered(string settingLookUp);
        int GetNumberFailedRegistered(string settingLookUp);
        string GetGeneratedPassword(string settingLookUp);
        void UpdateExamSettingFailedRegisteration(int failedRegistered, string settingLookUp);
        void UpdateExamSettingAfterSuccessfulRegisteration(int successfullRegistered, string password, string settingLookUp);
        ExamAnswerReport SubmitExamQuestions(string userId, List<ExamQuestions> examArrays);
    }
}
