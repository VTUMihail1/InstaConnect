using InstaConnect.Chats.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;

public interface IUserQueryRepository
{
	public Task<UserResponse?> GetByIdAsync(
        UserId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
        UserId id,
        CancellationToken cancellationToken);
}
