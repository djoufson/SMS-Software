using api.Data;
using api.Entities;
using api.Entities.Base;
using api.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Concrete;

public sealed class AuthManager : IAuthManager
{
    private readonly AppDbContext _context;

    public AuthManager(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddToRoleAsync(User user, string role)
    {
        var r = await _context.Roles.FirstOrDefaultAsync(r => r.Designation == role);
        r ??= Role.CreateNewRole(role);

        user.AssignRole(r);
        r.AssignUser(user);
        return true;
    }
}