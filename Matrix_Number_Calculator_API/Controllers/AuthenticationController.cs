using Matrix_Number_Calculator_API.Models;
using Matrix_Number_Calculator_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Matrix_Number_Calculator_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private IAuthenticationService _authenticateService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticateService = authenticationService;
        }
        [HttpPost]
        public IActionResult Authenticate([FromBody]Login model)
        {
            try
            {
                var user = _authenticateService.Authenticate(model.UserName, model.Password);

                if (user == null)
                {
                    return BadRequest(new { message = "Username of password is incorrect" });
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
    
        }
    }
}
