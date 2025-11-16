using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.Users.Helpers;
internal class UserService : IUserService
{
    private readonly IUserFactory _factory;
    private readonly IUserRepository _repository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UserService(
        IUserFactory factory,
        IUserRepository repository,
        IDateTimeProvider dateTimeProvider)
    {
        _factory = factory;
        _repository = repository;
        _dateTimeProvider = dateTimeProvider;
    }
    public async Task<User> AddAsync(AddUserCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNotNull())
        {
            throw new UserAlreadyExistsException(command.Id);
        }

        var existingUserByEmail = await _repository.GetByEmailAsync(command.Email, cancellationToken);

        if (existingUserByEmail.IsNotNull())
        {
            throw new UserEmailAlreadyExistsException(command.Email);
        }

        var existingUserByName = await _repository.GetByNameAsync(command.Name, cancellationToken);

        if (existingUserByName.IsNotNull())
        {
            throw new UserNameAlreadyExistsException(command.Name);
        }

        var user = _factory.Create(
            command.Id,
            command.FirstName,
            command.LastName,
            command.Name,
            command.Email,
            command.ProfileImage);

        await _repository.AddAsync(user, cancellationToken);

        return user;
    }

    public async Task<User> UpdateAsync(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id);
        }

        var existingUserByEmail = await _repository.GetByEmailAsync(command.Email, cancellationToken);

        if (existingUser!.Email.IsNot(command.Email) && existingUserByEmail.IsNotNull())
        {
            throw new UserEmailAlreadyExistsException(command.Email);
        }

        var existingUserByName = await _repository.GetByNameAsync(command.Name, cancellationToken);

        if (existingUser!.Name.IsNot(command.Name) && existingUserByName.IsNotNull())
        {
            throw new UserNameAlreadyExistsException(command.Name);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        existingUser!.Update(
            command.Email,
            command.FirstName,
            command.LastName,
            command.Name,
            command.ProfileImage,
           utcNow);
        await _repository.UpdateAsync(existingUser, cancellationToken);

        return existingUser;
    }

    public async Task DeleteAsync(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id);
        }

        await _repository.DeleteAsync(existingUser!, cancellationToken);
    }
}
