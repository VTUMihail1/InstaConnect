using AutoMapper;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.Account.EditAccount;

public class EditAccountCommandHandler : ICommandHandler<EditAccountCommand>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public EditAccountCommandHandler(
        IMapper mapper,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task Handle(EditAccountCommand request, CancellationToken cancellationToken)
    {
        var existingUserById = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (existingUserById == null)
        {
            throw new UserNotFoundException();
        }

        var existingUserByName = await _userRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingUserById.UserName != request.UserName && existingUserByName != null)
        {
            throw new AccountUsernameAlreadyTakenException();
        }

        _mapper.Map(request, existingUserById);
        await _userRepository.UpdateAsync(existingUserById, cancellationToken);
    }
}
