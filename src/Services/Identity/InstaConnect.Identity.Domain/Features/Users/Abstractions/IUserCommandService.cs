namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserCommandService
{
    public Task<UserId> AddAsync(AddUserCommand command, CancellationToken cancellationToken);

    public Task<UserId> UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteUserCommand command, CancellationToken cancellationToken);
}
