using api.Data;
using api.Services.Abstractions;

namespace api.Services.Features.Authentication;

public partial class AuthService
{
    private readonly AppDbContext _context;
    private readonly IJwtTokenGenerator _tokenGenerator;
    public AuthService(AppDbContext context, IJwtTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
        _context = context;
    }
}
