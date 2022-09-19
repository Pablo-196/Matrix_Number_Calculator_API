using Matrix_Number_Calculator_API.Models;

namespace Matrix_Number_Calculator_API.Services
{
    public interface IAuthenticationService
    {
        User Authenticate(string username, string password);
    }
}
