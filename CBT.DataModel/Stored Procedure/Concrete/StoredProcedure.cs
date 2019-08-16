using CBT.DataModel.DataModel;
using CBT.DataModel.Models;
using CBT.DataModel.Stored_Procedure.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CBT.DataModel.Stored_Procedure
{
    public class StoredProcedure : IDisposable, IStoredProcedure
    {
        #region Private variables
        private CBTDbContext _context = null;
        #endregion

        #region constructor

        public StoredProcedure(CBTDbContext context)
        {
            this._context = context;
        }
        #endregion

        #region Public methods
        public ApplicationUserView GetUserClaimsView(string userId)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "userId",
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                Value = userId
            };

            var user = _context.ApplicationUserViews.FromSql($"GetUserClaimsView @userId", inputValue).FirstOrDefault();
            return user;
        }

        public List<ExamCategory> GetCategoryList()
        {
            var categoryList = _context.ExamCategories.FromSql($"GetCategoryList").ToList();
            return categoryList;
        }

        public ExamInstruction GetExamInstruction()
        {
            var examIntruction = _context.ExamInstructions.FromSql($"GetInstruction").FirstOrDefault();
            return examIntruction;
        }

        public ExamInstructionTime GetTimeObject(string timeLookUp)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "timeObject",
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                Value = timeLookUp
            };

            var examIntructionTime = _context.ExamInstructionTimes.FromSql($"GetTimeObject @timeObject", inputValue).FirstOrDefault();
            return examIntructionTime;
        }
        
        public List<ExamTopic> GetExamTopics(string userId)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "userId",
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                Value = userId
            };
            var inputValue2 = new SqlParameter
            {
                ParameterName = "categoryId",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                Value = 0
            };

            var examTopics = _context.ExamTopics.FromSql($"GetExamTopics @userId, @categoryId", inputValue, inputValue2).ToList();
            return examTopics;
        }

        public List<ExamQuestion> GetExamQuestions(int topicId)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "topicId",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                Value = topicId
            };

            var examQuestions = _context.ExamQuestions.FromSql($"GetExamQuestions @topicId", inputValue).ToList();
            return examQuestions;
        }

        //Get the Toggling of systems
        public bool GetToggledSettings(string settingLookUp)
        {
                var inputValue = new SqlParameter
                {
                    ParameterName = "settingLookUp",
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    Value = settingLookUp
                };

                var outputValue = new SqlParameter
                {
                    ParameterName = "isSetting",
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output
                };

                var sql = "exec GetToggledSettings @settingLookUp, @isSetting OUT";
                var result = _context.Database.ExecuteSqlCommand(sql, inputValue, outputValue);

                var isSetting = (int)outputValue.Value == 1 ? true : (int)outputValue.Value == 0 ? false : false;
                return isSetting;
        }

        //Return Number to be registered.
        public int GetNumberToBeRegistered(string settingLookUp)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "settingLookUp",
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                Value = settingLookUp
            };

            var outputValue = new SqlParameter
            {
                ParameterName = "numberToBeRegistered",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };

            var sql = "exec NumberToBeRegistered @settingLookUp, @numberToBeRegistered OUT";
            var result = _context.Database.ExecuteSqlCommand(sql, inputValue, outputValue);

            var numberToBeRegistered = (int)outputValue.Value;
            return numberToBeRegistered;
        }
        //Return number successfully registered
        public int GetNumberSuccessfullyRegistered(string settingLookUp)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "settingLookUp",
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                Value = settingLookUp
            };

            var outputValue = new SqlParameter
            {
                ParameterName = "successfullyRegistered",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };

            var sql = "exec SuccessfullyRegistered @settingLookUp, @successfullyRegistered OUT";
            var result = _context.Database.ExecuteSqlCommand(sql, inputValue, outputValue);

            var successfullyRegistered = (int)outputValue.Value;
            return successfullyRegistered;
        }
        //Return number failed during registering
        public int GetNumberFailedRegistered(string settingLookUp)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "settingLookUp",
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                Value = settingLookUp
            };

            var outputValue = new SqlParameter
            {
                ParameterName = "failedRegistered",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };

            var sql = "exec FailedRegistered @settingLookUp, @failedRegistered OUT";
            var result = _context.Database.ExecuteSqlCommand(sql, inputValue, outputValue);

            var failedRegistered = (int)outputValue.Value;
            return failedRegistered;
        }

        //Return Generated password during registration
        public string GetGeneratedPassword(string settingLookUp)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "settingLookUp",
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                Value = settingLookUp
            };

            SqlParameter outputValue = new SqlParameter("password", SqlDbType.NVarChar, 7);
            outputValue.Direction = ParameterDirection.Output;

            var sql = "exec GetGeneratedPassword @settingLookUp, @password OUT";
            var result = _context.Database.ExecuteSqlCommand(sql, inputValue, outputValue);

            var password = outputValue.Value == DBNull.Value ? string.Empty: (string)outputValue.Value;
            return password;
        }
        //Updating the failed registration
        public void UpdateExamSettingFailedRegisteration(int failedRegistered, string settingLookUp)
        {
            var inputValue1 = new SqlParameter
            {
                ParameterName = "failedRegistered",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                Value = failedRegistered
            };

            var inputValue3 = new SqlParameter
            {
                ParameterName = "settingLookUp",
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                Value = settingLookUp
            };

            var sql = "exec UpdateExamSettingsFailedRegistration @failedRegistered, @settingLookUp";
            var result = _context.Database.ExecuteSqlCommand(sql, inputValue1, inputValue3);
        }
        //Updating the successful registration 
        public void UpdateExamSettingAfterSuccessfulRegisteration(int successfullRegistered, string password, string settingLookUp)
        {
            var inputValue1 = new SqlParameter
            {
                ParameterName = "successfullRegistered",
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
                Value = successfullRegistered
            };

            var inputValue2 = new SqlParameter
            {
                ParameterName = "password",
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                Value = password
            };

            var inputValue3 = new SqlParameter
            {
                ParameterName = "settingLookUp",
                DbType = DbType.String,
                Direction = ParameterDirection.Input,
                Value = settingLookUp
            };

            var sql = "exec UpdateExamSettingsAfterSuccessRegistration @successfullRegistered, @password, @settingLookUp";
            var result = _context.Database.ExecuteSqlCommand(sql, inputValue1, inputValue2, inputValue3);
        }

        #endregion


        #region dispose members
        // private dispose variable declaration...
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
