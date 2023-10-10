using api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using api.Utilities;
using api.Services.Features.Authentication;
using api.Services.Features.Authentication.Errors;

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

    [HttpPut("reset/password/{email}")]
    [Authorize(Policy = Policies.AdminOnly)]
    public async Task<IActionResult> ResetPassword(string email, ResetPasswordRequest request)
    {
        var adminId = Headers.GetUserId(Request.Headers);
        var command = new ResetPasswordCommand(adminId, email, request.Password);
        var response = await _authService.ResetPassword(command);

        if(response.IsSuccess)
            return Ok(response.Value);

        var error = response.Errors.Select(e => e.Message);
        return response.Errors.First() switch
        {
            BadCredentialsError or PasswordRequirementsError => BadRequest(error),
            UserNotFoundError => NotFound(error),
            _ => Problem()
        };
    }
}
