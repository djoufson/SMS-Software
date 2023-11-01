using api.Data;
using api.Services.Abstractions;

namespace api.Features.Authentication;

public partial class AuthService
{
    private readonly AppDbContext _context;
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IHashGenerator _hashGenerator;
    public AuthService(
        AppDbContext context,
        IJwtTokenGenerator tokenGenerator,
        IHashGenerator hashGenerator)
    {
        _tokenGenerator = tokenGenerator;
        _context = context;
        _hashGenerator = hashGenerator;
    }
}
