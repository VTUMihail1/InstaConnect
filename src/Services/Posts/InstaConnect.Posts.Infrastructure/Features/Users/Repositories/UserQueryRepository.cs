using InstaConnect.Posts.Domain.Features.Users.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Repositories;

internal class UserQueryRepository : IUserQueryRepository
{
    private readonly IPostsContext _context;
    private readonly IUserIncluderFactory _userIncluderFactory;

    public UserQueryRepository(
        IPostsContext context,
        IUserIncluderFactory userIncluderFactory)
    {
        _context = context;
        _userIncluderFactory = userIncluderFactory;
    }
    public async Task<UserResponse?> GetByIdAsync(
        UserId id,
        CurrentUserQuery currentUser,
        UserInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .Aggregate()
            .Includes(_userIncluderFactory, include)
            .Match(id)
            .ProjectToResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<UserResponse?> GetByIdAsync(
        UserId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, currentUser, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        UserId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .Aggregate()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
