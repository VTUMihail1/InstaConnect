using InstaConnect.Common.Events.Abstractions;
using InstaConnect.Identity.Domain.Helpers;

namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

internal class UserCommandService : IUserCommandService
{
    private readonly IUserFactory _factory;
    private readonly IApplicationMapper _mapper;
    private readonly IImageHandler _imageHandler;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserCommandRepository _repository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserIncludeBuilderFactory _includeBuilderFactory;
    private readonly IEmailConfirmationTokenFactory _emailConfirmationTokenFactory;
    private readonly IEmailConfirmationTokenCommandRepository _emailConfirmationTokenRepository;

    public UserCommandService(
        IUserFactory factory,
        IApplicationMapper mapper,
        IImageHandler imageHandler,
        IPasswordHasher passwordHasher,
        IEventPublisher eventPublisher,
        IUserCommandRepository repository,
        IDateTimeProvider dateTimeProvider,
        IUserIncludeBuilderFactory includeBuilderFactory,
        IEmailConfirmationTokenFactory emailConfirmationTokenFactory,
        IEmailConfirmationTokenCommandRepository emailConfirmationTokenRepository)
    {
        _factory = factory;
        _mapper = mapper;
        _imageHandler = imageHandler;
        _passwordHasher = passwordHasher;
        _eventPublisher = eventPublisher;
        _repository = repository;
        _dateTimeProvider = dateTimeProvider;
        _includeBuilderFactory = includeBuilderFactory;
        _emailConfirmationTokenFactory = emailConfirmationTokenFactory;
        _emailConfirmationTokenRepository = emailConfirmationTokenRepository;
    }

    public async Task<UserId> AddAsync(AddUserCommand command, CancellationToken cancellationToken)
    {
        var userByEmail = await _repository.GetByEmailAsync(command.Email, cancellationToken);

        if (userByEmail != null)
        {
            throw new UserEmailAlreadyTakenException(command.Email);
        }

        var userByName = await _repository.GetByNameAsync(command.Name, cancellationToken);

        if (userByName != null)
        {
            throw new UserNameAlreadyTakenException(command.Name);
        }

        var passwordHash = _passwordHasher.Hash(command.Password);
        var newUser = _factory.Create(
            command.Name, command.FirstName, command.LastName, command.Email, passwordHash);

        if (command.ProfileImage != null)
        {
            newUser.UpdateProfileImage(await _imageHandler.UploadAsync(command.ProfileImage, cancellationToken));
        }

        await _repository.AddAsync(newUser, cancellationToken);

        await _eventPublisher.PublishAsync(
            _mapper.Map<UserAddedEventRequest>(newUser), cancellationToken);

        var newEmailConfirmationToken = _emailConfirmationTokenFactory.Create(newUser.Id);
        await _emailConfirmationTokenRepository.AddAsync(newEmailConfirmationToken, cancellationToken);

        await _eventPublisher.PublishAsync(
            _mapper.Map<EmailConfirmationTokenAddedEventRequest>(newEmailConfirmationToken.AddUser(newUser)), cancellationToken);

        return newUser.Id;
    }

    public async Task<UserId> UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithEmailConfirmationTokens().Build();
        var user = await _repository.GetByIdAsync(command.Id, include, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(command.Id);
        }

        var userByEmail = await _repository.GetByEmailAsync(command.Email, cancellationToken);

        if (user.DoesNotHaveEmail(command.Email) && userByEmail != null)
        {
            throw new UserEmailAlreadyTakenException(command.Email);
        }

        if (user.DoesNotHaveEmail(command.Email))
        {
            await _emailConfirmationTokenRepository.DeleteRangeAsync(user.EmailConfirmationTokens, cancellationToken);

            user.UpdateEmail(command.Email);
        }

        var userByName = await _repository.GetByNameAsync(command.Name, cancellationToken);

        if (user.DoesNotHaveName(command.Name) && userByName != null)
        {
            throw new UserNameAlreadyTakenException(command.Name);
        }

        if (command.ProfileImage != null)
        {
            user.UpdateProfileImage(await _imageHandler.UploadAsync(command.ProfileImage, cancellationToken));
        }

        user.Update(command.FirstName, command.LastName, command.Name, _dateTimeProvider.GetOffsetUtcNow());

        await _eventPublisher.PublishAsync(
            _mapper.Map<UserUpdatedEventRequest>(user), cancellationToken);

        return user.Id;
    }

    public async Task DeleteAsync(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(command.Id);
        }

        await _repository.DeleteAsync(user, cancellationToken);

        await _eventPublisher.PublishAsync(
            _mapper.Map<UserDeletedEventRequest>(user), cancellationToken);
    }
}
