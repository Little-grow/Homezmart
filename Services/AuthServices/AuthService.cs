using Homezmart.Models.Users;
using Homezmart.Services.ServiceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Homezmart.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private JWT _jwt;

        public AuthService(JWT jwt, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _jwt = jwt;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //This method is used to generate a token for the user
        public AuthModel GenerateToken(TokenRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Name, request.UserName),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim("id", new Guid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthModel
            {
                Token = tokenHandler.WriteToken(token),
                ExpiresOn = tokenDescriptor.Expires.Value,
                UserName = request.UserName,
                Email = request.Email,
                IsAuth = true,
                Roles = { "User" }
            };
            throw new NotImplementedException();
        }

        //This method is used to login the user
        public async Task<AuthModel> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return GenerateToken(new TokenRequest
                {
                    Email = user.Email,
                    UserName = user.UserName
                });
            }

            return new AuthModel
            {
                Message = "Invalid Credentials",
                IsAuth = false
            };
            throw new NotImplementedException();
        }

        public async Task<AuthModel> Register(RegisterRequest request)
        {
            if (await _userManager.FindByEmailAsync(request.Email) is not null || await _userManager.FindByNameAsync(request.UserName) is not null)
            {
                return new AuthModel
                {
                    Message = "User already exists",
                    IsAuth = false
                };
            }

            if (request.Password != request.ConfirmPassword)
            {
                return new AuthModel
                {
                    Message = "Password and Confirm Password do not match",
                    IsAuth = false
                };
            }

            var user = new AppUser
            {
                Email = request.Email,
                UserName = request.UserName
            };

            var result = _userManager.CreateAsync(user, request.Password).Result;

            if (!result.Succeeded)
            {
                return new AuthModel
                {
                    Message = "Invalid Credentials",
                    IsAuth = false
                };
            }

            return GenerateToken(new TokenRequest
            {
                Email = user.Email,
                UserName = user.UserName
            });
            throw new NotImplementedException();
        }
    }
}
