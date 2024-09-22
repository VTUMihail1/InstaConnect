using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Repositories;

internal class ForgotPasswordTokenWriteRepository : BaseWriteRepository<ForgotPasswordToken>, IForgotPasswordTokenWriteRepository
{
    private readonly IdentityContext _identityContext;

    public ForgotPasswordTokenWriteRepository(IdentityContext identityContext) : base(identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task<ForgotPasswordToken?> GetByValueAsync(string value, CancellationToken cancellationToken)
    {
        var token = await _identityContext.ForgotPasswordTokens
            .FirstOrDefaultAsync(e => e.Value == value, cancellationToken);

        return token;
    }
}
