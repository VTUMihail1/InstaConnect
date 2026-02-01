using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Repositories;

internal class ForgotPasswordTokenCommandRepository : IForgotPasswordTokenCommandRepository
{
    private readonly IIdentityContext _context;
    private readonly IForgotPasswordTokenIncludePropertyFactory _forgotPasswordTokenIncludePropertyFactory;

    public ForgotPasswordTokenCommandRepository(
        IIdentityContext context,
        IForgotPasswordTokenIncludePropertyFactory forgotPasswordTokenIncludePropertyFactory)
    {
        _context = context;
        _forgotPasswordTokenIncludePropertyFactory = forgotPasswordTokenIncludePropertyFactory;
    }

    public async Task<ForgotPasswordToken?> GetByIdAsync(
        ForgotPasswordTokenId id,
        ForgotPasswordTokenInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .ForgotPasswordTokens
            .Aggregate()
            .Includes(_forgotPasswordTokenIncludePropertyFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ForgotPasswordToken?> GetByIdAsync(
        ForgotPasswordTokenId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(ForgotPasswordToken entity, CancellationToken cancellationToken)
    {
        await _context
            .ForgotPasswordTokens
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
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
