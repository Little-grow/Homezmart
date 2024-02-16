using Homezmart.Services.ServiceModels;

namespace Homezmart.Services.AuthServices
{
    public interface IAuthService
    {
        AuthModel GenerateToken(TokenRequest request);
        Task<AuthModel> Login(LoginRequest request);
        Task<AuthModel> Register(RegisterRequest request);
    }
}