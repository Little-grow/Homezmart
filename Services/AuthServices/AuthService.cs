using Homezmart.Services.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Homezmart.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private IConfiguration _config;
        private JWT _jwt;

        public AuthService(IConfiguration config, JWT jwt)
        {
            _config = config;
            _jwt = jwt;
        }



        public AuthModel Login(LoginRequest request)
        {
            AuthModel authModel = new();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var SecToken = new JwtSecurityToken
            (
               issuer: _jwt.Issuer,
               audience: _jwt.Audience,
               signingCredentials: credentials,
               expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(SecToken);


            authModel.Email = request.Email;
            authModel.UserName = request.UserName;
            authModel.isAuth = true;
            authModel.Token = token;
            authModel.ExpiresOn = SecToken.ValidTo;

            return authModel;
        }

        public AuthModel GenerateToken(TokenRequest request)
        {
            throw new NotImplementedException();
        }

        public AuthModel Register(RegisterRquest rquest)
        {
            throw new NotImplementedException();
        }
    }
}
