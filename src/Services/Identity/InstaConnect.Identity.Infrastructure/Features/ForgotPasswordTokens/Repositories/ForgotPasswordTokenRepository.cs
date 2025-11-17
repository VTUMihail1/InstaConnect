using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Repositories;

internal class ForgotPasswordTokenRepository : IForgotPasswordTokenRepository
{
    private readonly IIdentityContext _identityContext;
    private readonly IForgotPasswordTokenIncludePropertyFactory _forgotPasswordTokenIncludePropertyFactory;

    public ForgotPasswordTokenRepository(
        IIdentityContext identityContext,
        IForgotPasswordTokenIncludePropertyFactory forgotPasswordTokenIncludePropertyFactory)
    {
        _identityContext = identityContext;
        _forgotPasswordTokenIncludePropertyFactory = forgotPasswordTokenIncludePropertyFactory;
    }

    public async Task<ForgotPasswordToken?> GetByIdAsync(
        ForgotPasswordTokenId id,
        ForgotPasswordTokenIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _forgotPasswordTokenIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .ForgotPasswordTokens
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<ForgotPasswordToken?> GetByIdAsync(
        ForgotPasswordTokenId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .ForgotPasswordTokens
            .AddAsync(_identityContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken)
    {
        var ids = entities.Select(e => e.Id);

        await _identityContext.ForgotPasswordTokens
            .DeleteRangeAsync(
            _identityContext.ClientSessionHandle,
            x => ids.Any(a => a == x.Id),
            cancellationToken);
    }
}
