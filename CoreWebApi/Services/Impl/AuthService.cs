using CoreWebApi.Models;

namespace CoreWebApi.Services.Impl
{
    public  class AuthService : IAuthService
    {
        public LoginModel Authenticate(string username, string password)
        {
            // Check hardcoded username and password
            if (username == "shehan" && password == "12345")
            {
                return new LoginModel
                {
                    Username = username,
                    IsAuthenticated = true,
                    DisplayName = "Your Display Name"
                    // You can set additional user information here
                };
            }
            return null;
        }
    }
}
