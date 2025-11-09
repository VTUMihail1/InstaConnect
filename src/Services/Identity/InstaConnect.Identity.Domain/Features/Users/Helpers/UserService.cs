using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Events.Abstractions;
using InstaConnect.Identity.Domain.Helpers;

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
    private readonly IUserIncludeQueryBuilderFactory _userIncludeQueryBuilderFactory;
    private readonly IEmailConfirmationTokenRepository _emailConfirmationTokenRepository;

    public UserService(
        IUserFactory userFactory,
        IImageHandler imageHandler,
        IPasswordHasher passwordHasher,
        IEventPublisher eventPublisher,
        IUserRepository userRepository,
        IDateTimeProvider dateTimeProvider,
        IApplicationMapper applicationMapper,
        IUserIncludeQueryBuilderFactory userIncludeQueryBuilderFactory,
        IEmailConfirmationTokenRepository emailConfirmationTokenRepository)
    {
        _userFactory = userFactory;
        _imageHandler = imageHandler;
        _passwordHasher = passwordHasher;
        _eventPublisher = eventPublisher;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
        _applicationMapper = applicationMapper;
        _userIncludeQueryBuilderFactory = userIncludeQueryBuilderFactory;
        _emailConfirmationTokenRepository = emailConfirmationTokenRepository;
    }

    public async Task<UserCollection> GetAllAsync(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        var existingUserCollection = await _userRepository.GetAllAsync(
            query.Filter,
            query.Sorting,
            query.Pagination,
            query.Include,
            cancellationToken);

        return existingUserCollection;
    }

    public async Task<User> GetByIdAsync(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(
            query.Id,
            query.Include,
            cancellationToken);

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
        await _userRepository.AddAsync(user, cancellationToken);

        var userAddedEvent = _applicationMapper.Map<UserAddedEventRequest>(user);
        await _eventPublisher.PublishAsync(userAddedEvent, cancellationToken);

        return user;
    }

    public async Task<User> UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var include = _userIncludeQueryBuilderFactory.Create().WithEmailConfirmationTokens().Build();
        var existingUser = await _userRepository.GetByIdAsync(command.Id, include, cancellationToken);

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
            await _emailConfirmationTokenRepository.DeleteRangeAsync(existingUser.EmailConfirmationTokens, cancellationToken);

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

        await _userRepository.DeleteAsync(existingUser!, cancellationToken);

        var eventRequest = _applicationMapper.Map<UserDeletedEventRequest>(existingUser!);
        await _eventPublisher.PublishAsync(eventRequest, cancellationToken);
    }
}
