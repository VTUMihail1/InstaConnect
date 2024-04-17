using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Abstractions;

namespace InstaConnect.Users.Business.Commands.AccountLogout
{
    public class AccountLogoutCommandHandler : ICommandHandler<AccountLogoutCommand>
    {
        private readonly ITokenService _tokenService;

        public AccountLogoutCommandHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task Handle(AccountLogoutCommand request, CancellationToken cancellationToken)
        {
            await _tokenService.DeleteAsync(request.Value, cancellationToken);
        }
    }
}
