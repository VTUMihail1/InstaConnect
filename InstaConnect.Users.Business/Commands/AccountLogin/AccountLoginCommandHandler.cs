using AutoMapper;
using EGames.Business.Services;
using InstaConnect.Shared.Exceptions.Account;
using InstaConnect.Shared.Messaging;
using InstaConnect.Shared.Models.Enum;
using InstaConnect.Users.Business.Commands.Account;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Users.Business.Commands.AccountLogin
{
    public class AccountLoginCommandHandler : ICommandHandler<AccountLoginCommand, AccountViewDTO>
    {
        private const string INVALID_DETAILS = "Email or password are invalid";

        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccountLoginCommandHandler(
            IMapper mapper, 
            IAccountManager accountManager, 
            IUserRepository userRepository, 
            ITokenService tokenService)
        {
            _mapper = mapper;
            _accountManager = accountManager;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<AccountViewDTO> Handle(AccountLoginCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);

            if (existingUser == null)
            {
                throw new AccountException(INVALID_DETAILS, InstaConnectStatusCode.BadRequest);
            }

            var validPassword = await _accountManager.CheckPasswordAsync(existingUser, request.Password);

            if (!validPassword)
            {
                throw new AccountException(INVALID_DETAILS, InstaConnectStatusCode.BadRequest);
            }

            var tokenViewModel = await _tokenService.GenerateAccessTokenAsync(existingUser.Id);
            var accountResultDTO = _mapper.Map<AccountViewDTO>(tokenViewModel);

            return accountResultDTO;
        }
    }
}
