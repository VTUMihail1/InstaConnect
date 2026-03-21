using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Repositories;

internal class EmailConfirmationTokenCommandRepository : IEmailConfirmationTokenCommandRepository
{
    private readonly IIdentityContext _context;
    private readonly IEmailConfirmationTokenIncluderFactory _emailConfirmationTokenIncluderFactory;

    public EmailConfirmationTokenCommandRepository(
        IIdentityContext context,
        IEmailConfirmationTokenIncluderFactory emailConfirmationTokenIncluderFactory)
    {
        _context = context;
        _emailConfirmationTokenIncluderFactory = emailConfirmationTokenIncluderFactory;
    }

    public async Task<EmailConfirmationToken?> GetByIdAsync(
        EmailConfirmationTokenId id,
        EmailConfirmationTokenInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .EmailConfirmationTokens
            .Aggregate()
            .Includes(_emailConfirmationTokenIncluderFactory, include)
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

    public async Task AddRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken)
    {
        await _context
            .EmailConfirmationTokens
            .AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task DeleteAsync(EmailConfirmationToken entity, CancellationToken cancellationToken)
    {
        await _context
            .EmailConfirmationTokens
            .DeleteAsync(_context.ClientSessionHandle, entity, cancellationToken);
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
