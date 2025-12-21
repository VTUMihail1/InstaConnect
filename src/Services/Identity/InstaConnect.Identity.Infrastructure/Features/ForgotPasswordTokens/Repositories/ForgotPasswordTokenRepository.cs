using InstaConnect.Common.Domain.Models;

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
        var match = Builders<ForgotPasswordToken>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id.Id, id.Id.Id)
            .AndEqualsCaseInsensitive(p => p.Id.Value, id.Value);

        var includeProperties = _forgotPasswordTokenIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .ForgotPasswordTokens
            .Aggregate()
            .Includes(includeProperties)
            .Match(match)
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
        var ids = entities.Select(e => e.Id.Id.Id);
        var values = entities.Select(e => e.Id.Value);

        var match = Builders<ForgotPasswordToken>.Filter.Empty
            .AndInCaseInsensitive(p => p.Id.Id.Id, ids)
            .AndInCaseInsensitive(p => p.Id.Value, values);

        await _identityContext.ForgotPasswordTokens
            .DeleteRangeAsync(
            _identityContext.ClientSessionHandle,
            match,
            cancellationToken);
    }
}
