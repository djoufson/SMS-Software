using api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using api.Services.Authentication;

namespace api.Controllers;

public class LoginController : ApiController
{
    private readonly AuthService _authService;

    public LoginController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _authService.Login(request);
        if(response.IsFailed)
            return BadRequest(response.Errors.Select(e => e.Message));

        return Ok(response.Value);
    }
}
