using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.Account.DeleteAccount;

public class DeleteAccountCommandHandler : ICommandHandler<DeleteAccountCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteAccountCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        await _userRepository.DeleteAsync(existingUser, cancellationToken);
    }
}
