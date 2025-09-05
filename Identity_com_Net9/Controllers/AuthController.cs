using Identity_com_Net9.Dto;
using Identity_com_Net9.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity_com_Net9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var resultado = await _authService.Register(registerDto);
            if (!resultado.Status) return BadRequest(resultado);
            return Ok(resultado);




        }
    }
}
