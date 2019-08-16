using CBT.DataModel.GenericRepository.Concrete;
using CBT.DataModel.Models;

namespace CBT.DataModel.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        #region Public Interfaces
        GenericRepository<ExamCategory> ExamCategoryRepository { get; }
        GenericRepository<ExamQuestion> ExamQuestionRepository { get; }
        GenericRepository<PreviousExamQuestion> PreviousExamQuestionRepository { get; }
        GenericRepository<AuditReport> AuditReportRepository { get; }
        GenericRepository<ApplicationUser> ApplicationUserRepository { get; }
        #endregion

        #region Audit Trail
        void AuditTrail(string actionPerformed, string userId);
        #endregion
    }
}
