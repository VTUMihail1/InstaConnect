using InstaConnect.Follows.Domain.Features.Users.Models.Responses;
using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Repositories;

internal class UserQueryRepository : IUserQueryRepository
{
    private readonly IFollowsContext _context;

    public UserQueryRepository(IFollowsContext context)
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
