using AutoMapper;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.Account.LoginAccount
{
    public class LoginAccountCommandHandler : ICommandHandler<LoginAccountCommand, AccountViewDTO>
    {
        private readonly IMapper _mapper;
        private readonly IAccountManager _accountManager;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginAccountCommandHandler(
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

        public async Task<AccountViewDTO> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

            if (existingUser == null)
            {
                throw new AccountInvalidDetailsException();
            }

            var validPassword = await _accountManager.CheckPasswordAsync(existingUser, request.Password);

            if (!validPassword)
            {
                throw new AccountInvalidDetailsException();
            }

            var tokenViewDTO = await _tokenService.GenerateAccessTokenAsync(existingUser.Id, cancellationToken);
            var accountViewDTO = _mapper.Map<AccountViewDTO>(tokenViewDTO);

            return accountViewDTO;
        }
    }
}
