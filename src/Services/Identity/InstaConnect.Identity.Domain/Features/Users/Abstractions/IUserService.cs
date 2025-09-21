using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Users.Domain.Features.Users.Abstractions;
public interface IUserService
{
    public Task<UserCollection> GetAllAsync(GetAllUsersQuery query, CancellationToken cancellationToken);

    public Task<User> GetByIdAsync(GetUserByIdQuery query, CancellationToken cancellationToken);

    public Task<User> AddAsync(AddUserCommand command, CancellationToken cancellationToken);

    public Task<User> UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeleteUserCommand command, CancellationToken cancellationToken);
}
