using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Users.Abstractions;

public interface IUserQueryRepository
{
    Task<UserResponse?> GetByIdAsync(
        UserId id,
        CurrentUserQuery currentUser,
        UserInclude? include,
        CancellationToken cancellationToken);

    Task<UserResponse?> GetByIdAsync(
        UserId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        UserId id,
        CancellationToken cancellationToken);
}
