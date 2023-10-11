using api.Controllers.Base;
using api.Services.Features.Authentication.Errors;
using api.Services.Features.Sanctions;
using api.Services.Features.Sanctions.Errors;
using api.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class SanctionController : ApiController
{
    private readonly SanctionService _sanctionService;

    public SanctionController(SanctionService sanctionService)
    {
        _sanctionService = sanctionService;
    }

    [HttpPost]
    [Authorize(Policy = Policies.SecretaryOnly)]
    public async Task<IActionResult> SanctionStudent(SanctionRequest request)
    {
        var secretaryId = Headers.GetUserId(Request.Headers);
        var command = new SanctionCommand(secretaryId, request.StudentEmail, request.Motif, request.Amount);
        var result = await _sanctionService.SanctionStudent(command);
        if(result.IsSuccess)
            return Created("", result.Value);

        var error = result.Errors.Select(e => e.Message);
        return result.Errors.First() switch
        {
            BadCredentialsError or PasswordRequirementsError => BadRequest(error),
            UserNotFoundError => NotFound(error),
            FailedToSanctionStudentError => Problem(title: "Internal Server Error", detail: error.First()),
            _ => Problem()
        };
    }
}
