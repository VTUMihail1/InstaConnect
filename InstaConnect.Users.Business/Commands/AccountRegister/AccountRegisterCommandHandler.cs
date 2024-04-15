using AutoMapper;
using EGames.Business.Services;
using InstaConnect.Shared.Exceptions.Account;
using InstaConnect.Shared.Messaging;
using InstaConnect.Shared.Models.Enum;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;
using InstaConnect.Users.Data.Models.Entities;

namespace InstaConnect.Users.Business.Commands.AccountRegister
{
    public class AccountRegisterCommandHandler : ICommandHandler<AccountRegisterCommand>
    {
        private const string NAME_ALREADY_EXISTS = "User with that name already exists";
        private const string EMAIL_ALREADY_EXISTS = "User with that email already exists";

        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccountRegisterCommandHandler(
            IMapper mapper,
            IUserRepository userRepository,
            IAccountManager accountManager,
            ITokenService tokenService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _accountManager = accountManager;
            _tokenService = tokenService;
        }

        public async Task Handle(AccountRegisterCommand request, CancellationToken cancellationToken)
        {
            var existingEmailUser = await _userRepository.GetByEmailAsync(request.Email);

            if (existingEmailUser != null)
            {
                throw new AccountException(EMAIL_ALREADY_EXISTS, InstaConnectStatusCode.BadRequest);
            }

            var existingNameUser = await _userRepository.GetByNameAsync(request.UserName);

            if (existingNameUser != null)
            {
                throw new AccountException(NAME_ALREADY_EXISTS, InstaConnectStatusCode.BadRequest);
            }

            var user = _mapper.Map<User>(request);
            await _accountManager.RegisterUserAsync(user, request.Password);

            var tokenViewDTO = await _tokenService.GenerateAccessTokenAsync(user.Id);
        }
    }
}
