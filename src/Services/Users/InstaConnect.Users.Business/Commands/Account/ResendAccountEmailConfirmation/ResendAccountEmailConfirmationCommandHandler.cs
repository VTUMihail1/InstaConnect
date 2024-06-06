using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.Account.ResendAccountEmailConfirmation;

public class ResendAccountEmailConfirmationCommandHandler : ICommandHandler<ResendAccountEmailConfirmationCommand>
{
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepository;
    private readonly IAccountManager _accountManager;

    public ResendAccountEmailConfirmationCommandHandler(
        ITokenService tokenService,
        IUserRepository userRepository,
        IAccountManager accountManager)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
        _accountManager = accountManager;
    }

    public async Task Handle(ResendAccountEmailConfirmationCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var emailIsConfirmed = await _accountManager.IsEmailConfirmedAsync(existingUser);

        if (emailIsConfirmed)
        {
            throw new AccountEmailAlreadyConfirmedException();
        }

        var tokenResult = await _tokenService.GenerateEmailConfirmationTokenAsync(existingUser.Id, cancellationToken);
    }
}
