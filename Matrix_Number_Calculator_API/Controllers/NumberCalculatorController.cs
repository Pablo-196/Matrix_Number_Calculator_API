using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Matrix_Number_Calculator_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberCalculatorController : Controller
    {

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("{firstNumber}/{secondNumber}")]
        public string Calculate([FromHeader] string operation, int firstNumber, int secondNumber)
        {
            if (operation != string.Empty)
            {
                operation = operation.ToLower();
                try
                {
                    switch (operation)
                    {
                        case "addition":
                            return $"The result of the addition operation is {firstNumber + secondNumber}";
                        case "subtraction":
                            return $"The result of the subtraction operation is {firstNumber - secondNumber}";
                        case "division":
                            return $"The result of the division operation is {firstNumber / secondNumber}";
                        case "multiplication":
                            return $"The result of the multiplication operation is {firstNumber * secondNumber}";
                        default:
                            return "The opertaion you specified is not valid, please try again";
                    }
                }
                catch (System.Exception ex)
                {

                    return ex.InnerException.ToString();
                }
            }
            else
            {
                return "Operation type cannot be empty.";
            }

        }
    }
}