using InstaConnect.Common.Domain.Models;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

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
        CommonIncludeQuery<ForgotPasswordTokenIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _forgotPasswordTokenIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .ForgotPasswordTokens
            .Aggregate()
            .Includes(includeProperties)
            .Match(id.GetFilter())
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
        await _identityContext.ForgotPasswordTokens
            .DeleteRangeAsync(
            _identityContext.ClientSessionHandle,
            entities.Select(p => p.Id).GetFilter(),
            cancellationToken);
    }
}
