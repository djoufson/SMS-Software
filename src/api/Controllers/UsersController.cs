using api.Controllers.Base;
using api.Services.Features.Users;
using api.Services.Features.Users.Errors;
using api.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class UsersController : ApiController
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    [Authorize(Policy = Policies.AdminOnly)]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var userId = Headers.GetUserId(Request.Headers);
        var command = new RegisterUserCommand(userId, request);
        var response = await _userService.Register(command);
        if(response.IsSuccess)
            return Created("", response.Value);

        var error = response.Errors.Select(e => e.Message);
        return response.Errors.First() switch
        {
            ConflictedEmailsError => Conflict(error),
            UserRegistrationError => BadRequest(error),
            _ => Problem()
        };
    }
}
