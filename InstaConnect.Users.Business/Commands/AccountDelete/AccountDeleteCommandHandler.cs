using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.AccountDelete
{
    public class AccountDeleteCommandHandler : ICommandHandler<AccountDeleteCommand>
    {
        private readonly IUserRepository _userRepository;

        public AccountDeleteCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(AccountDeleteCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (existingUser == null)
            {
                throw new UserNotFoundException();
            }

            await _userRepository.DeleteAsync(existingUser, cancellationToken);
        }
    }
}
