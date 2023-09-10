namespace CoreWebApi.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        // Additional properties to carry user information
        public bool IsAuthenticated { get; set; }
        public string DisplayName { get; set; }
        // You can add more properties as needed.
    }
}