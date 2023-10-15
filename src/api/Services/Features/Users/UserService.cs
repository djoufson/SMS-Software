using api.Data;
using api.Services.Abstractions;

namespace api.Services.Features.Users;

public partial class UserService
{
    private readonly AppDbContext _context;
    private readonly IAuthManager _authManager;
    private readonly IHashGenerator _hashGenerator;
    public UserService(
        AppDbContext context,
        IAuthManager authManager,
        IHashGenerator hashGenerator)
    {
        _context = context;
        _authManager = authManager;
        _hashGenerator = hashGenerator;
    }
}
