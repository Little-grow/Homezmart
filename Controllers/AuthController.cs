using Homezmart.Models.DatabaseContext;
using Homezmart.Services.AuthServices;
using Homezmart.Services.ServiceModels;
using Microsoft.AspNetCore.Mvc;

namespace Homezmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var authModel = await _authService.Login(request);
            return Ok(authModel);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
             var authModel = await _authService.Register(request);
            return Ok();
        }
    }

}
