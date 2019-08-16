using CBT.DataModel.DataModel;
using CBT.DataModel.GenericRepository.Concrete;
using CBT.DataModel.Models;
using CBT.DataModel.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Transactions;

namespace CBT.DataModel.UnitOfWork.Concrete
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private variables
        private CBTDbContext _context = null;
        private GenericRepository<ExamCategory> examCategoryRepository;
        private GenericRepository<ExamQuestion> examQuestionRepository;
        private GenericRepository<PreviousExamQuestion> previousExamQuestionRepository;
        private GenericRepository<AuditReport> auditReportRepository;
        private GenericRepository<ApplicationUser> applicationUserRepository;
        #endregion

        #region constructor

        public UnitOfWork(CBTDbContext context)
        {
            this._context = context;
        }
        #endregion

        #region public member
        public GenericRepository<ExamCategory> ExamCategoryRepository
        {
            get
            {
                if (this.examCategoryRepository == null)
                    this.examCategoryRepository = new GenericRepository<ExamCategory>(_context);
                return examCategoryRepository;
            }
        }

        public GenericRepository<ExamQuestion> ExamQuestionRepository
        {
            get
            {
                if (this.examQuestionRepository == null)
                    this.examQuestionRepository = new GenericRepository<ExamQuestion>(_context);
                return examQuestionRepository;
            }
        }
        public GenericRepository<PreviousExamQuestion> PreviousExamQuestionRepository
        {
            get
            {
                if (this.previousExamQuestionRepository == null)
                    this.previousExamQuestionRepository = new GenericRepository<PreviousExamQuestion>(_context);
                return previousExamQuestionRepository;
            }
        }
        public GenericRepository<AuditReport> AuditReportRepository
        {
            get
            {
                if (this.auditReportRepository == null)
                    this.auditReportRepository = new GenericRepository<AuditReport>(_context);
                return auditReportRepository;
            }
        }

        public GenericRepository<ApplicationUser> ApplicationUserRepository
        {
            get
            {
                if (this.applicationUserRepository == null)
                    this.applicationUserRepository = new GenericRepository<ApplicationUser>(_context);
                return applicationUserRepository;
            }
        }

        #endregion

        #region Save action
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch(Exception x)
            {
                throw new NotImplementedException("Error occured during saving of Object.");
            }
        }
        #endregion

       
        #region Audit Trail
        public void AuditTrail(string actionPerformed, string userId)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                    IPAddress ipAddress = ipHostInfo.AddressList[1];

                    var audit = new AuditReport()
                    {
                        ActionPerformed = actionPerformed,
                        UserId = userId,
                        SystemIpAddress = ipAddress.ToString(),
                    };
                    AuditReportRepository.InsertObject(audit);
                    Save();
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
            }
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
