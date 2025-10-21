using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Users.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Repositories;

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
        string id,
        string value,
        ForgotPasswordTokenIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _forgotPasswordTokenIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .ForgotPasswordTokens
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == id && p.Value == value)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<ForgotPasswordToken?> GetByIdAsync(
        string id,
        string value,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, value, null, cancellationToken);
    }

    public async Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .ForgotPasswordTokens
            .AddAsync(_identityContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteRangeAsync(ICollection<ForgotPasswordToken> entities, CancellationToken cancellationToken)
    {
        var ids = entities.Select(e => new { e.Id, e.Value });

        await _identityContext.ForgotPasswordTokens
            .DeleteRangeAsync(
            _identityContext.ClientSessionHandle,
            x => ids.Any(a => a.Id == x.Id && a.Value == x.Value),
            cancellationToken);
    }
}
