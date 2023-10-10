using api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using api.Utilities;
using api.Services.Features.Authentication;

namespace api.Controllers;

public class LoginController : ApiController
{
    private readonly AuthService _authService;

    public LoginController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("authenticate")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        var response = await _authService.Login(request);
        if(response.IsFailed)
            return BadRequest(response.Errors.Select(e => e.Message));

        return Ok(response.Value);
    }

    [Authorize]
    [HttpPut("password")]
    public async Task<ActionResult<ChangePasswordResponse>> ChangePassword(ChangePasswordRequest requestDto)
    {
        var userId = Headers.GetUserId(Request.Headers);
        var request = new ChangePasswordCommand(userId, requestDto.Password, requestDto.NewPassword);
        var response = await _authService.ChangePassword(request);
        if(response.IsFailed)
            return BadRequest(response.Errors.Select(e => e.Message));

        return Ok(response.Value);
    }
}
