using CBT.Service.Examiner.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CBT.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]/")]
    [ApiController]
    public class ExaminerController : ControllerBase
    {
        private readonly IExaminerService _examiner;
        public ExaminerController(IExaminerService examiner)
        {
            _examiner = examiner;
        }

       
    }
}