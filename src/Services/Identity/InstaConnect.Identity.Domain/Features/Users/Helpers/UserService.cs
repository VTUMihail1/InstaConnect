using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Exceptions;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Abstractions;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Domain.Features.Users.Helpers;
internal class UserService : IUserService
{
    private readonly IUserFactory _userFactory;
    private readonly IImageHandler _imageHandler;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IEmailConfirmationTokenRepository _emailConfirmationTokenRepository;

    public UserService(
        IUserFactory userFactory,
        IImageHandler imageHandler,
        IPasswordHasher passwordHasher,
        IEventPublisher eventPublisher,
        IUserRepository userRepository,
        IDateTimeProvider dateTimeProvider,
        IApplicationMapper applicationMapper,
        IEmailConfirmationTokenRepository emailConfirmationTokenRepository)
    {
        _userFactory = userFactory;
        _imageHandler = imageHandler;
        _passwordHasher = passwordHasher;
        _eventPublisher = eventPublisher;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
        _applicationMapper = applicationMapper;
        _emailConfirmationTokenRepository = emailConfirmationTokenRepository;
    }

    public async Task<UserCollection> GetAllAsync(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        var existingUserCollection = await _userRepository.GetAllAsync(query, cancellationToken);

        return existingUserCollection;
    }

    public async Task<User> GetByIdAsync(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(query.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(query.Id);
        }

        return existingUser!;
    }

    public async Task<User> AddAsync(AddUserCommand command, CancellationToken cancellationToken)
    {
        var existingUserByEmail = await _userRepository.GetByEmailAsync(command.Email, cancellationToken);

        if (existingUserByEmail.IsNotNull())
        {
            throw new UserEmailAlreadyTakenException(command.Email);
        }

        var existingUserByName = await _userRepository.GetByNameAsync(command.Name, cancellationToken);

        if (existingUserByName.IsNotNull())
        {
            throw new UserNameAlreadyTakenException(command.Name);
        }

        var profileImage = (string?)null;

        if (command.ProfileImage.IsNotNull())
        {
            profileImage = await _imageHandler.UploadAsync(command.ProfileImage!, cancellationToken);
        }

        var passwordHash = _passwordHasher.Hash(command.Password);
        var user = _userFactory.Create(
            command.Name, command.FirstName, command.LastName, command.Email, passwordHash, profileImage);
        _userRepository.Add(user);

        var userAddedEvent = _applicationMapper.Map<UserAddedEventRequest>(user);
        await _eventPublisher.PublishAsync(userAddedEvent, cancellationToken);

        return user;
    }

    public async Task<User> UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id);
        }

        var existingUserByEmail = await _userRepository.GetByEmailAsync(command.Email, cancellationToken);

        if (existingUser!.DoesNotHaveEmail(command.Email) && existingUserByEmail.IsNotNull())
        {
            throw new UserEmailAlreadyTakenException(command.Email);
        }

        if (existingUser.DoesNotHaveEmail(command.Email))
        {
            var emailConfirmationTokenRequest = _applicationMapper.Map<GetAllEmailConfirmationTokensQuery>(existingUser);
            var emailConfirmationTokenCollection = await _emailConfirmationTokenRepository.GetAllAsync(emailConfirmationTokenRequest, cancellationToken);
            _emailConfirmationTokenRepository.DeleteRange(emailConfirmationTokenCollection.Data);

            existingUser.UpdateEmail(command.Email);
        }

        var existingUserByName = await _userRepository.GetByNameAsync(command.Name, cancellationToken);

        if (existingUser.DoesNotHaveName(command.Name) && existingUserByName.IsNotNull())
        {
            throw new UserNameAlreadyTakenException(command.Name);
        }

        if (command.ProfileImage.IsNotNull())
        {
            var profileImage = await _imageHandler.UploadAsync(command.ProfileImage!, cancellationToken);
            existingUser.UpdateProfileImage(profileImage);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        existingUser.Update(command.FirstName, command.LastName, command.Name, utcNow);

        var userUpdatedEvent = _applicationMapper.Map<UserUpdatedEventRequest>(existingUser);
        await _eventPublisher.PublishAsync(userUpdatedEvent, cancellationToken);

        return existingUser;
    }

    public async Task DeleteAsync(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id);
        }

        _userRepository.Delete(existingUser!);

        var eventRequest = _applicationMapper.Map<UserDeletedEventRequest>(existingUser!);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}
