using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.Account.ConfirmAccountEmail
{
    public class ConfirmAccountEmailCommandHandler : ICommandHandler<ConfirmAccountEmailCommand>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IAccountManager _accountManager;

        public ConfirmAccountEmailCommandHandler(
            ITokenService tokenService,
            IUserRepository userRepository,
            IAccountManager accountManager)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _accountManager = accountManager;
        }

        public async Task Handle(ConfirmAccountEmailCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (existingUser == null)
            {
                throw new UserNotFoundException();
            }

            var emailIsConfirmed = await _accountManager.IsEmailConfirmedAsync(existingUser);

            if (emailIsConfirmed)
            {
                throw new AccountEmailAlreadyConfirmedException();
            }

            await _tokenService.DeleteAsync(request.Token, cancellationToken);
            await _accountManager.ConfirmEmailAsync(existingUser);
        }
    }
}
