using CBT.DataModel.Stored_Procedure;
using CBT.DataModel.Stored_Procedure.Abstract;
using CBT.DataModel.UnitOfWork.Abstract;
using CBT.DataModel.UnitOfWork.Concrete;
using CBT.Service.Candidate.Abstract;
using CBT.Service.Candidate.Concrete;
using CBT.Service.Examiner.Abstract;
using CBT.Service.Examiner.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace CBT.Web.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {

            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IExaminerService, ExaminerService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IStoredProcedure, StoredProcedure>();
            // Add all other services here.
            return services;
        }
    }
}
