using InstaConnect.Common.Domain.Models;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Repositories;

internal class EmailConfirmationTokenRepository : IEmailConfirmationTokenRepository
{
    private readonly IIdentityContext _identityContext;
    private readonly IEmailConfirmationTokenIncludePropertyFactory _emailConfirmationTokenIncludePropertyFactory;

    public EmailConfirmationTokenRepository(
        IIdentityContext identityContext,
        IEmailConfirmationTokenIncludePropertyFactory emailConfirmationTokenIncludePropertyFactory)
    {
        _identityContext = identityContext;
        _emailConfirmationTokenIncludePropertyFactory = emailConfirmationTokenIncludePropertyFactory;
    }

    public async Task<EmailConfirmationToken?> GetByIdAsync(
        EmailConfirmationTokenId id,
        CommonIncludeQuery<EmailConfirmationTokenIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = Builders<EmailConfirmationToken>.Filter.Empty
            .AndEqualsCaseInsensitive(p => p.Id.Id.Id, id.Id.Id)
            .AndEqualsCaseInsensitive(p => p.Id.Value, id.Value);

        var includeProperties = _emailConfirmationTokenIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .EmailConfirmationTokens
            .Aggregate()
            .Includes(includeProperties)
            .Match(match)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<EmailConfirmationToken?> GetByIdAsync(
        EmailConfirmationTokenId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(EmailConfirmationToken entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .EmailConfirmationTokens
            .AddAsync(_identityContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken)
    {
        var ids = entities.Select(e => e.Id.Id.Id);
        var values = entities.Select(e => e.Id.Value);

        var match = Builders<EmailConfirmationToken>.Filter.Empty
            .AndInCaseInsensitive(p => p.Id.Id.Id, ids)
            .AndInCaseInsensitive(p => p.Id.Value, values);

        await _identityContext.EmailConfirmationTokens
            .DeleteRangeAsync(
            _identityContext.ClientSessionHandle,
            match,
            cancellationToken);
    }
}
