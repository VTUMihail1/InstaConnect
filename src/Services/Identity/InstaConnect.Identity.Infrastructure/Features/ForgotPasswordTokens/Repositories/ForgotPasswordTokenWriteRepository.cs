using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;

using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Repositories;

internal class ForgotPasswordTokenWriteRepository : IForgotPasswordTokenWriteRepository
{
    private readonly IdentityContext _identityContext;

    public ForgotPasswordTokenWriteRepository(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task<ForgotPasswordToken?> GetByValueAsync(string value, CancellationToken cancellationToken)
    {
        var token = await _identityContext.ForgotPasswordTokens
            .FirstOrDefaultAsync(e => e.Value == value, cancellationToken);

        return token;
    }

    public void Add(ForgotPasswordToken forgotPasswordToken)
    {
        _identityContext
            .ForgotPasswordTokens
            .Add(forgotPasswordToken);
    }

    public void Delete(ForgotPasswordToken forgotPasswordToken)
    {
        _identityContext
            .ForgotPasswordTokens
            .Remove(forgotPasswordToken);
    }
}
