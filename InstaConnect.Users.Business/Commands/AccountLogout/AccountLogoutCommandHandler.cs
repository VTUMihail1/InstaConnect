using EGames.Business.Services;
using InstaConnect.Shared.Messaging;
using InstaConnect.Users.Business.Commands.Account.AccountLogout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _tokenService.DeleteAsync(request.Value);
        }
    }
}
