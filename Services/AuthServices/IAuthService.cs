using Homezmart.Services.ServiceModels;

namespace Homezmart.Services.AuthServices
{
    public interface IAuthService
    {
        AuthModel GenerateToken(TokenRequest request);
        AuthModel Login(LoginRequest request);
        AuthModel Register(RegisterRquest rquest);
    }
}