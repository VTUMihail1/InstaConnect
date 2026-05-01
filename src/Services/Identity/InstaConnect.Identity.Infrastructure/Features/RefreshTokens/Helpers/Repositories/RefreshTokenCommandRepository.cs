using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Repositories;

internal class RefreshTokenCommandRepository : IRefreshTokenCommandRepository
{
	private readonly IIdentityContext _context;
	private readonly IRefreshTokenIncluderFactory _refreshTokenIncluderFactory;

	public RefreshTokenCommandRepository(
		IIdentityContext context,
		IRefreshTokenIncluderFactory refreshTokenIncluderFactory)
	{
		_context = context;
		_refreshTokenIncluderFactory = refreshTokenIncluderFactory;
	}

	public async Task<RefreshToken?> GetByIdAsync(
		RefreshTokenId id,
		RefreshTokenInclude? include,
		CancellationToken cancellationToken)
	{
		return await _context
			.RefreshTokens
			.Aggregate()
			.Includes(_refreshTokenIncluderFactory, include)
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<RefreshToken?> GetByIdAsync(
		RefreshTokenId id,
		CancellationToken cancellationToken)
	{
		return await GetByIdAsync(id, null, cancellationToken);
	}

	public async Task AddAsync(RefreshToken entity, CancellationToken cancellationToken)
	{
		await _context
			.RefreshTokens
			.AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<RefreshToken> entities, CancellationToken cancellationToken)
	{
		await _context
			.RefreshTokens
			.AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
	}

	public async Task UpdateAsync(RefreshToken entity, CancellationToken cancellationToken)
	{
		await _context.RefreshTokens
			.UpdateAsync(
			_context.ClientSessionHandle,
			entity,
			cancellationToken);
	}

	public async Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken)
	{
		await _context.RefreshTokens
			.DeleteAsync(
			_context.ClientSessionHandle,
			entity,
			cancellationToken);
	}
}
