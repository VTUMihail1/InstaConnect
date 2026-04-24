using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers.Repositories;

internal class ForgotPasswordTokenCommandRepository : IForgotPasswordTokenCommandRepository
{
    private readonly IIdentityContext _context;
    private readonly IForgotPasswordTokenIncluderFactory _forgotPasswordTokenIncluderFactory;

    public ForgotPasswordTokenCommandRepository(
        IIdentityContext context,
        IForgotPasswordTokenIncluderFactory forgotPasswordTokenIncluderFactory)
    {
        _context = context;
        _forgotPasswordTokenIncluderFactory = forgotPasswordTokenIncluderFactory;
    }

    public async Task<ForgotPasswordToken?> GetByIdAsync(
        ForgotPasswordTokenId id,
        ForgotPasswordTokenInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .ForgotPasswordTokens
            .Aggregate()
            .Includes(_forgotPasswordTokenIncluderFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ForgotPasswordToken?> GetByIdAsync(
        ForgotPasswordTokenId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        ForgotPasswordTokenId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .ForgotPasswordTokens
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }

    public async Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
    {
        await _context
            .ForgotPasswordTokens
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken)
    {
        await _context
            .ForgotPasswordTokens
            .AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
    {
        await _context
            .ForgotPasswordTokens
            .UpdateAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
    {
        await _context
            .ForgotPasswordTokens
            .DeleteAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<ForgotPasswordToken> entities, CancellationToken cancellationToken)
    {
        await _context.ForgotPasswordTokens
            .DeleteRangeAsync(
            _context.ClientSessionHandle,
            entities,
            cancellationToken);
    }
}
