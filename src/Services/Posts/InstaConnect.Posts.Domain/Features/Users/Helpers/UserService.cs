using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Exceptions.Users;
using InstaConnect.Common.Extensions;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Exceptions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Events;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Exceptions;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;
internal class UserService : IUserService
{
    private readonly IUserFactory _userFactory;
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public PostService(
        IUserFactory userFactory,
        IUserRepository userRepository,
        IDateTimeProvider dateTimeProvider)
    {
        _userFactory = userFactory;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
    }
    public async Task AddAsync(AddUserCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNotNull())
        {
            throw new UserAlreadyExistsException(command.Id);
        }

        var user = _userFactory.Create(
            command.Id,
            command.FirstName,
            command.LastName,
            command.Name,
            command.Email,
            command.ProfileImage);

        _userRepository.Add(user);
    }

    public async Task UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        existingUser!.Update(
            command.FirstName,
            command.LastName,
            command.Name,
            command.ProfileImage,
           utcNow);
        _userRepository.Add(existingUser);
    }

    public async Task DeleteAsync(DeletePostCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id);
        }

        _userRepository.Delete(existingUser!);
    }
}
