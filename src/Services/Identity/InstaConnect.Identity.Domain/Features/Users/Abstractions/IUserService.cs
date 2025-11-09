namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;
public interface IUserService
{
    public Task<UserCollection> GetAllAsync(GetAllUsersQuery query, CancellationToken cancellationToken);

    public Task<User> GetByIdAsync(GetUserByIdQuery query, CancellationToken cancellationToken);

    public Task<User> AddAsync(AddUserCommand command, CancellationToken cancellationToken);

    public Task<User> UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteUserCommand command, CancellationToken cancellationToken);
}
