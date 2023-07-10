using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskMgt.DTOs;
using TaskMgt.Models;
using TaskMgt.Services;

namespace TaskMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            return Ok(await _authService.Register(register));


        }

    }
}
