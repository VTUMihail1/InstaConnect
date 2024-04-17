using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.AccountResetPassword
{
    public class AccountResetPasswordCommandHandler : ICommandHandler<AccountResetPasswordCommand>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IAccountManager _accountManager;

        public AccountResetPasswordCommandHandler(
            ITokenService tokenService,
            IUserRepository userRepository,
            IAccountManager accountManager)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _accountManager = accountManager;
        }

        public async Task Handle(AccountResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (existingUser == null)
            {
                throw new UserNotFoundException();
            }

            await _tokenService.DeleteAsync(request.Token, cancellationToken);
            await _accountManager.ResetPasswordAsync(existingUser, request.Password);
        }
    }
}
