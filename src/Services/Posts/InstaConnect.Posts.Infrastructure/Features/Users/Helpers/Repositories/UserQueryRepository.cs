using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Repositories;

internal class UserQueryRepository : IUserQueryRepository
{
	private readonly IPostsContext _context;

	public UserQueryRepository(IPostsContext context)
	{
		_context = context;
	}
	public async Task<UserResponse?> GetByIdAsync(
		UserId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		return await _context
			.Users
			.AggregateWithCaseInsensitiveCollation()
			.Match(id)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		UserId id,
		CancellationToken cancellationToken)
	{
		return await _context
			.Users
			.AggregateWithCaseInsensitiveCollation()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
