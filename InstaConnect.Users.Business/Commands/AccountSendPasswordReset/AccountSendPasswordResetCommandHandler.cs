using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.AccountSendPasswordReset
{
    public class AccountSendPasswordResetCommandHandler : ICommandHandler<AccountSendPasswordResetCommand>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public AccountSendPasswordResetCommandHandler(
            ITokenService tokenService,
            IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task Handle(AccountSendPasswordResetCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

            if (existingUser == null)
            {
                throw new UserNotFoundException();
            }

            var tokenResult = await _tokenService.GeneratePasswordResetTokenAsync(existingUser.Id, cancellationToken);
        }
    }
}
