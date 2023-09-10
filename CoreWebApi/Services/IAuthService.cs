using CoreWebApi.Models;

namespace CoreWebApi.Services
{
    public interface IAuthService
    {
        LoginModel Authenticate(string username, string password);
    }
}
