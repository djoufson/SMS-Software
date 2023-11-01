using System.Security.Claims;
using api.Utilities;

namespace api.Middlewares;

/// <summary>
/// In order to use the authenticated user ID in the pipeline, this middleware will retrieve it from the Token / ClaimsPrincipal,
/// and register it as a Request Header.
/// </summary>
public class RegisterUserIdMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Before
        Claim? userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        string userId = userIdClaim is null ? string.Empty : userIdClaim.Value;
        context.Request.Headers.TryAdd(Headers.UserId, userId);

        await next(context);
        // After
    }
}
