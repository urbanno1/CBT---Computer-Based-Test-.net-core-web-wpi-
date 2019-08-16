using CBT.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBT.DataModel.Stored_Procedure.Abstract
{
   public interface IStoredProcedure
    {
        ApplicationUserView GetUserClaimsView(string userId);
        List<ExamCategory> GetCategoryList();
        ExamInstruction GetExamInstruction();
        ExamInstructionTime GetTimeObject(string timeLookUp);
        List<ExamTopic> GetExamTopics(string userId);
        List<ExamQuestion> GetExamQuestions(int topicId);
        bool GetToggledSettings(string settingLookUp);
        int GetNumberToBeRegistered(string settingLookUp);
        int GetNumberSuccessfullyRegistered(string settingLookUp);
        int GetNumberFailedRegistered(string settingLookUp);
        string GetGeneratedPassword(string settingLookUp);
        void UpdateExamSettingFailedRegisteration(int failedRegistered, string settingLookUp);
        void UpdateExamSettingAfterSuccessfulRegisteration(int successfullRegistered, string password, string settingLookUp);
        
    }
}
