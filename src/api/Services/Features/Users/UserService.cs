using api.Data;
using api.Services.Abstractions;

namespace api.Services.Features.Users;

public partial class UserService
{
    private readonly AppDbContext _context;
    private readonly IAuthManager _authManager;
    public UserService(AppDbContext context, IAuthManager authManager)
    {
        _context = context;
        _authManager = authManager;
    }
}
