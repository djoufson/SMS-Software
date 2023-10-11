using api.Data;
using api.Utilities;
using Microsoft.EntityFrameworkCore;

namespace api.Middlewares;

public class VerifyExistenceMiddleware : IMiddleware
{
    private readonly AppDbContext _context;

    public VerifyExistenceMiddleware(AppDbContext context)
    {
        _context = context;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var userId = Headers.GetUserId(context.Request.Headers);
        if(string.IsNullOrEmpty(userId))
        {
            await next(context);
            return;
        }

        bool exists = await _context.Users.AnyAsync(u => u.Id == userId);
        if(exists)
        {
            await next(context);
            return;
        }

        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsJsonAsync(new {
            Message = "The user you are logged in with does not or no longer exist"
        });
    }
}
