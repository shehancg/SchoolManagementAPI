using CoreWebApi.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace CoreWebApi.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken(string username, List<string> roles);
    }
}
