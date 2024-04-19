using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.Account.SendAccountPasswordReset
{
    public class SendAccountPasswordResetCommandHandler : ICommandHandler<SendAccountPasswordResetCommand>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public SendAccountPasswordResetCommandHandler(
            ITokenService tokenService,
            IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task Handle(SendAccountPasswordResetCommand request, CancellationToken cancellationToken)
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
