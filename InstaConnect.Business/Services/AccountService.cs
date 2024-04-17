using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Abstraction.Repositories;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IUserRepository _userRepository;
        private readonly IAccountManager _accountManager;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;

        public AccountService(
            IMapper mapper,
            IResultFactory resultFactory,
            IEmailService emailService,
            ITokenService tokenService,
            IUserRepository userRepository,
            IAccountManager accountManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _emailService = emailService;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _accountManager = accountManager;
        }

        public async Task<IResult<AccountResultDTO>> DeleteAsync(string id)
        {
            var existingUser = await _userRepository.FindEntityAsync(u => u.Id == id);

            if (existingUser == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<AccountResultDTO>();

                return notFoundResult;
            }

            await _userRepository.DeleteAsync(existingUser);

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }
    }
}
