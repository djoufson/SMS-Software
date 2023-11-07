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
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _authService.Login(request);
        if(response.IsSuccess)
            return Ok(response.Value);

        Console.WriteLine(HttpContext.Response.Headers["Access-Control-Allow-Origin"]);

        var error = response.Errors.Select(e => e.Message);
        return response.Errors.First() switch
        {
            BadCredentialsError or PasswordRequirementsError => BadRequest(error),
            UserNotFoundError => NotFound(error),
            _ => Problem()
        };
    }

    [Authorize]
    [HttpPut("password")]
    [ProducesResponseType(typeof(ChangePasswordResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest requestDto)
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
    [ProducesResponseType(typeof(ResetPasswordResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> ResetPassword(string email, ResetPasswordRequest request)
    {
        var command = new ResetPasswordCommand(email, request.Password);
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
