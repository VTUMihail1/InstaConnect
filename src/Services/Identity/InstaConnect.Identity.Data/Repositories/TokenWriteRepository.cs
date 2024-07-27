using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Data.Repositories;

internal class TokenWriteRepository : BaseWriteRepository<Token>, ITokenWriteRepository
{
    private readonly IdentityContext _identityContext;

    public TokenWriteRepository(IdentityContext identityContext) : base(identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task<Token?> GetByValueAsync(string value, CancellationToken cancellationToken)
    {
        var token = await _identityContext.Tokens
            .FirstOrDefaultAsync(e => e.Value == value, cancellationToken);

        return token;
    }
}
