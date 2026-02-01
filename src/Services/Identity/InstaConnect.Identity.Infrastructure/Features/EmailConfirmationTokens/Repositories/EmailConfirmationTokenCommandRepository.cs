using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Repositories;

internal class EmailConfirmationTokenCommandRepository : IEmailConfirmationTokenCommandRepository
{
    private readonly IIdentityContext _context;
    private readonly IEmailConfirmationTokenIncludePropertyFactory _emailConfirmationTokenIncludePropertyFactory;

    public EmailConfirmationTokenCommandRepository(
        IIdentityContext context,
        IEmailConfirmationTokenIncludePropertyFactory emailConfirmationTokenIncludePropertyFactory)
    {
        _context = context;
        _emailConfirmationTokenIncludePropertyFactory = emailConfirmationTokenIncludePropertyFactory;
    }

    public async Task<EmailConfirmationToken?> GetByIdAsync(
        EmailConfirmationTokenId id,
        EmailConfirmationTokenInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .EmailConfirmationTokens
            .Aggregate()
            .Includes(_emailConfirmationTokenIncludePropertyFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<EmailConfirmationToken?> GetByIdAsync(
        EmailConfirmationTokenId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(EmailConfirmationToken entity, CancellationToken cancellationToken)
    {
        await _context
            .EmailConfirmationTokens
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken)
    {
        await _context.EmailConfirmationTokens
            .DeleteRangeAsync(
            _context.ClientSessionHandle,
            entities,
            cancellationToken);
    }
}
