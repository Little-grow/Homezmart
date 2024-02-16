namespace Homezmart.Services.ServiceModels
{
    public class AuthModel
    {
        public string Message { get; set; } = null!;

        public bool IsAuth { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public List<string> Roles { get; set; }

        public string Token { get; set; } = null!;

        public DateTime ExpiresOn { get; set; }
    }
}