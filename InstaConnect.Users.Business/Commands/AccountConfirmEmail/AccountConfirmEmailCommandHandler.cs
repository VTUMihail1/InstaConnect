using EGames.Business.Services;
using InstaConnect.Shared.Exceptions.Account;
using InstaConnect.Shared.Messaging;
using InstaConnect.Shared.Models.Enum;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Users.Business.Commands.AccountConfirmEmail
{
    public class AccountConfirmEmailCommandHandler : ICommandHandler<AccountConfirmEmailCommand>
    {
        private const string INVALID_USER = "Invalid user";
        private const string EMAIL_ALREADY_CONFIRMED = "Email is already confirmed";

        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IAccountManager _accountManager;

        public AccountConfirmEmailCommandHandler(
            ITokenService tokenService, 
            IUserRepository userRepository, 
            IAccountManager accountManager)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _accountManager = accountManager;
        }

        public async Task Handle(AccountConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.UserId);

            if (existingUser == null)
            {
                throw new AccountException(INVALID_USER, InstaConnectStatusCode.BadRequest);
            }

            var emailIsConfirmed = await _accountManager.IsEmailConfirmedAsync(existingUser);

            if (emailIsConfirmed)
            {
                throw new AccountException(EMAIL_ALREADY_CONFIRMED, InstaConnectStatusCode.BadRequest);
            }

            await _tokenService.DeleteAsync(request.Token);
            await _accountManager.ConfirmEmailAsync(existingUser);
        }
    }
}
