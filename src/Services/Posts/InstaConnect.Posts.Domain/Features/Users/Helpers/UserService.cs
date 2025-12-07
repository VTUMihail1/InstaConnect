using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.Users.Helpers;
internal class UserService : IUserService
{
    private readonly IUserFactory _userFactory;
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserFactory userFactory,
        IUserRepository userRepository)
    {
        _userFactory = userFactory;
        _userRepository = userRepository;
    }
    public async Task<User> AddAsync(AddUserCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNotNull())
        {
            throw new UserAlreadyExistsException(command.Id);
        }

        var existingUserByEmail = await _userRepository.GetByEmailAsync(command.Email, cancellationToken);

        if (existingUserByEmail.IsNotNull())
        {
            throw new UserEmailAlreadyExistsException(command.Email);
        }

        var existingUserByName = await _userRepository.GetByNameAsync(command.Name, cancellationToken);

        if (existingUserByName.IsNotNull())
        {
            throw new UserNameAlreadyExistsException(command.Name);
        }

        var user = _userFactory.Create(
            command.Id,
            command.FirstName,
            command.LastName,
            command.Name,
            command.Email,
            command.ProfileImage,
            command.CreatedAtUtc,
            command.UpdatedAtUtc);

        await _userRepository.AddAsync(user, cancellationToken);

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

        if (existingUser!.Email.IsNot(command.Email) && existingUserByEmail.IsNotNull())
        {
            throw new UserEmailAlreadyExistsException(command.Email);
        }

        var existingUserByName = await _userRepository.GetByNameAsync(command.Name, cancellationToken);

        if (existingUser!.Name.IsNot(command.Name) && existingUserByName.IsNotNull())
        {
            throw new UserNameAlreadyExistsException(command.Name);
        }

        existingUser!.Update(
            command.Email,
            command.FirstName,
            command.LastName,
            command.Name,
            command.ProfileImage,
            command.UpdatedAtUtc);
        await _userRepository.UpdateAsync(existingUser, cancellationToken);

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
    }
}
