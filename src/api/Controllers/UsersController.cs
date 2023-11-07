using api.Controllers.Base;
using api.Features.Users;
using api.Features.Users.Errors;
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
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var command = new RegisterUserCommand(request);
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

    [HttpDelete("{email}")]
    [Authorize(Policy = Policies.AdminOnly)]
    [ProducesResponseType(typeof(DeleteUserResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteUser(string email)
    {
        var command = new DeleteUserCommand(email);
        var response = await _userService.DeleteUser(command);
        if(response.IsSuccess)
            return Ok(response.Value);

        var error = response.Errors.Select(e => e.Message);
        return Problem();
    }

    [HttpGet]
    [Authorize(Policy = Policies.AdminAndSecretary)]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllUsers(bool? active)
    {
        var query = new GetUsersQuery(active);
        var users = await _userService.GetAllUsers(query);
        return Ok(users);
    }
}
