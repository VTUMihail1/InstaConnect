using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
public interface IUserService
{
    public Task<User> AddAsync(AddUserCommand command, CancellationToken cancellationToken);

    public Task<User> UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteUserCommand command, CancellationToken cancellationToken);
}
