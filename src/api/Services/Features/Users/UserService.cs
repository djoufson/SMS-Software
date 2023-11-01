using api.Data;
using api.Services.Abstractions;

namespace api.Services.Features.Users;

public partial class UserService
{
    private readonly AppDbContext _context;
    private readonly IRolesManager _rolesManager;
    private readonly IHashGenerator _hashGenerator;
    public UserService(
        AppDbContext context,
        IRolesManager authManager,
        IHashGenerator hashGenerator)
    {
        _context = context;
        _rolesManager = authManager;
        _hashGenerator = hashGenerator;
    }
}
