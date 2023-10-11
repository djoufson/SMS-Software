using api.Data;

namespace api.Services.Features.Sanctions;

public partial class SanctionService
{
    private readonly AppDbContext _context;

    public SanctionService(AppDbContext context)
    {
        _context = context;
    }
}

public record SanctionResponse(
    string Id,
    string StudentId,
    string SecretaryId,
    string Motif,
    decimal Amount,
    bool Status);
