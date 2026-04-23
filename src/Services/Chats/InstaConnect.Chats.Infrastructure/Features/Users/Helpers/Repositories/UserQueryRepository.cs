using InstaConnect.Chats.Domain.Features.Users.Models.Responses;
using InstaConnect.Chats.Infrastructure.Features.Common.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Repositories;

internal class UserQueryRepository : IUserQueryRepository
{
    private readonly IChatsContext _context;

    public UserQueryRepository(IChatsContext context)
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
