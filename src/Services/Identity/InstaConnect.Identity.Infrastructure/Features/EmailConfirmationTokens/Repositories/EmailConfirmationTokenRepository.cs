using InstaConnect.Identity.Infrastructure.Abstractions;

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
        string id,
        string value,
        EmailConfirmationTokenIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _emailConfirmationTokenIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .EmailConfirmationTokens
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == id && p.Value == value)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<EmailConfirmationToken?> GetByIdAsync(
        string id,
        string value,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, value, null, cancellationToken);
    }

    public async Task AddAsync(EmailConfirmationToken entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .EmailConfirmationTokens
            .AddAsync(_identityContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken)
    {
        var ids = entities.Select(e => new { e.Id, e.Value });

        await _identityContext.EmailConfirmationTokens
            .DeleteRangeAsync(
            _identityContext.ClientSessionHandle,
            x => ids.Any(a => a.Id == x.Id && a.Value == x.Value),
            cancellationToken);
    }
}
