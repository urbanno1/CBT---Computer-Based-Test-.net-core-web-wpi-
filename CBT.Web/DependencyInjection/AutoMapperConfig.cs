using AutoMapper;
using CBT.DataModel.Models;
using CBT.Entity.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CBT.Web.DependencyInjection
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ExamCategory, ExamCategoryViewModel>();
                cfg.CreateMap<RegisterViewModel, ApplicationUser>();
                cfg.CreateMap<ExamInstruction, ExamInstructionViewModel>();
                cfg.CreateMap<ApplicationUserView, AspNetUserViewModel>();
                cfg.CreateMap<ExamQuestion, ExamQuestionsViewModel>();
                
            });
        }
    }
}
