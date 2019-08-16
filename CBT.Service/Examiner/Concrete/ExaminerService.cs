using System;
using System.Collections.Generic;
using AutoMapper;
using CBT.DataModel.Models;
using CBT.DataModel.Stored_Procedure.Abstract;
using CBT.DataModel.UnitOfWork.Abstract;
using CBT.Entity.ViewModels;
using CBT.Service.Examiner.Abstract;

namespace CBT.Service.Examiner.Concrete
{
    public class ExaminerService : IExaminerService
    {
        #region private variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoredProcedure _storedProcedure;
        #endregion
        #region constructor
        public ExaminerService(IUnitOfWork unitOfWork, IStoredProcedure storedProcedure)
        {
            this._unitOfWork = unitOfWork;
            this._storedProcedure = storedProcedure;
        }
        
        #endregion

        #region public methods

       

        #endregion
    }
}
