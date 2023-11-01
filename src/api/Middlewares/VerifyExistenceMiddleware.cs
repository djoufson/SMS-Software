using api.Data;
using api.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace api.Middlewares;

/// <summary>
/// This middleware is used to validate the authenticated user existence.
/// Since the user is authenticated with his ID through a JWT token, we must ensure that the user is in the database,
/// in case he has been deleted or revoked.
/// </summary> 
public class VerifyExistenceMiddleware : IMiddleware
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _cache;

    public VerifyExistenceMiddleware(AppDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var userId = Headers.GetUserId(context.Request.Headers);
        if(string.IsNullOrEmpty(userId))
        {
            await next(context);
            return;
        }

        // Check in the cache
        if(_cache.TryGetValue(userId, out bool exists) && exists)
        {
            await next(context);
        }

        // Get from the database
        else if(await _context.Users.AnyAsync(u => u.Id == userId))
        {
            _cache.Set(userId, true);
            await next(context);
        }

        // Else the user does not exist either in the cache nor in the database
        else
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new
            {
                Message = "The user you are logged in with does not or no longer exist"
            });
        }
    }
}
