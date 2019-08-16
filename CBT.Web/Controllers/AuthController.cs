using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CBT.Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CBT.Service.Helpers;
using CBT.Service.Candidate.Abstract;

namespace CBT.Web.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ICandidateService _candidate;
        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration, ICandidateService candidate)
        {
            _userManager = userManager;
            _configuration = configuration;
            _candidate = candidate;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            try
            {
                //Number to be registered
                var numberToBeRegistered = _candidate.GetNumberToBeRegistered("Enroll");
                //Number already registered
                var successfullyRegistered = _candidate.GetNumberSuccessfullyRegistered("Enroll");
                //Number already failed
                var failedRegistered = _candidate.GetNumberFailedRegistered("Enroll");
                //Total number of register and failed
                var totalRegistered = successfullyRegistered + failedRegistered + 1;
                var totalRegisteredInDb = successfullyRegistered + failedRegistered;

                int success = 0;
                int failed = 0;
                var password = "";

                //Generated password that will be shown to the admin alone
                if (successfullyRegistered == 0)
                    password = RandomPassword.GenerateRandomPassword(new PasswordOptions());
                else
                    password = _candidate.GetGeneratedPassword("Enroll");

                if (totalRegisteredInDb < numberToBeRegistered)
                {
                    var user = _candidate.GetUserViewModel(model);
                    var result = await _userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        //Update the number already registered and password
                        await _userManager.AddToRoleAsync(user, "UploadedStudent");
                        success = successfullyRegistered + 1;
                        _candidate.UpdateExamSettingAfterSuccessfulRegisteration(success, password, "Enroll");
                        return Ok(new { success = RepsonseMessages.PrintResponseMessage("AuthRegister.Success") });
                    }
                    else
                    {
                        //Update the number that failed and password
                        failed = failedRegistered + 1;
                        _candidate.UpdateExamSettingFailedRegisteration(failed, "Enroll");
                        return BadRequest(new { error = result.Errors });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            return BadRequest(new { error = RepsonseMessages.PrintResponseMessage("AuthRegister.Error") });
        }


        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var identityClaim = (ClaimsIdentity)User.Identity;
                    identityClaim.AddClaim(new Claim("UserId", user.Id));

                    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("very_long_very_secret_secret"));
                    int expiryInMinutes = Convert.ToInt32(_configuration["jwt:ExpiryInMinutes"]);
                    var token = new JwtSecurityToken(
                        issuer: "issuer",
                        audience: "audience",
                        expires: DateTime.UtcNow.AddMinutes(5),
                        signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                        claims: identityClaim.Claims
                        );

                    return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            roles = await _userManager.GetRolesAsync(user)
                        });
                }
                else
                    return BadRequest(new { error = RepsonseMessages.PrintResponseMessage("AuthLogin.Error") });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = RepsonseMessages.PrintResponseMessage("AuthLogin.Error") });
            }
        }

        [HttpGet]
        [Route("[action]/{settingLookUp}")]
        public IActionResult GetToggleSetting(string settingLookUp)
        {
            var isSetting = _candidate.GetToggledSettings(settingLookUp);
            return Ok(new { isSettingToggled = isSetting });

        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetCategoryList()
        {
            var categoryList = _candidate.GetCatgoryList();
            if (categoryList.Count > 0)
            {
                return Ok(categoryList);
            }
            else
                return BadRequest(new { error = RepsonseMessages.PrintResponseMessage("AuthGetToggleSetting.Error") });
        }




    }
}