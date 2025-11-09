namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;
public interface IUserService
{
    public Task<User> AddAsync(AddUserCommand command, CancellationToken cancellationToken);

    public Task<User> UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteUserCommand command, CancellationToken cancellationToken);
}
