using System.Collections.Generic;
using System.Linq;
using CBT.Entity.ViewModels;
using CBT.Service.Candidate.Abstract;
using CBT.Service.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CBT.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidate;
        public CandidateController(ICandidateService candidate)
        {
            _candidate = candidate;
        }


        [HttpGet]
        [Route("[action]/{timeLookUp}")]
        public IActionResult GetExamQuestionModel(string timeLookUp)
        {
            var userId = User.Claims.SingleOrDefault(c => c.Type == "UserId").Value;
               var model = _candidate.GetExamQuestionModels(userId, timeLookUp);
            if (model != null)
                return Ok(model);
            else
                return BadRequest(new { error = RepsonseMessages.PrintResponseMessage("CandidateGetQuestions.Error") });
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SubmitExamQuestionModel(List<ExamQuestions> examArrays)
        {
            var userId = User.Claims.SingleOrDefault(c => c.Type == "UserId").Value;
            if(examArrays != null && examArrays.Count() > 0)
            {
                var examResult = _candidate.SubmitExamQuestions(userId, examArrays);
                if (examResult != null)
                    return Ok(examResult);
                else
                    return BadRequest(new { error = RepsonseMessages.PrintResponseMessage("CandidateGetQuestions.Error") });
            }
            return BadRequest(new { error = RepsonseMessages.PrintResponseMessage("CandidateGetQuestions.Error") });
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult GetUserClaims()
        {
            try
            {
                var userId = User.Claims.SingleOrDefault(c => c.Type == "UserId").Value;
                var userObject = _candidate.GetUserCLaims(userId);
                return Ok(userObject);
            }
            catch
            {
                return BadRequest(new { error = RepsonseMessages.PrintResponseMessage("CandidateGetUserClaims.Error") });
            }
        }

    }
}