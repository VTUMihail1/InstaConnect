using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace InstaConnect.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IResultFactory _resultFactory;
        private readonly IMapper _mapper;

        public AccountService(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IResultFactory resultFactory,
            IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _resultFactory = resultFactory;
            _mapper = mapper;
        }

        public async Task<IResult<AccountResultDTO>> LoginAsync(AccountLoginDTO accountLoginDTO)
        {
            var user = await _userManager.FindByEmailAsync(accountLoginDTO.Email);

            if (user == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidLogin);

                return badRequestResult;
            }

            var result = await _signInManager.PasswordSignInAsync(user, accountLoginDTO.Password, false, false);

            if (!result.Succeeded)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidLogin);

                return badRequestResult;
            }

            var emailIsConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            if (!emailIsConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountEmailNotConfirmed);

                return badRequestResult;
            }

            var accountResultDTO = _mapper.Map<AccountResultDTO>(user);
            var okResult = _resultFactory.GetOkResult(accountResultDTO);

            return okResult;
        }

        public async Task<IResult<AccountResultDTO>> SignUpAsync(AccountRegistrationDTO accountRegistrationDTO)
        {
            var existingUser = await _userManager.FindByEmailAsync(accountRegistrationDTO.Email);

            if (existingUser != null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountAlreadyExists);

                return badRequestResult;
            }

            var user = _mapper.Map<User>(accountRegistrationDTO);
            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                var errors = result.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(errors);

                return badRequestResult;
            }

            var accountResultDTO = _mapper.Map<AccountResultDTO>(user);
            var okResult = _resultFactory.GetOkResult(accountResultDTO);

            return okResult;
        }

        public async Task<IResult<AccountEmailRequestDTO>> GenerateConfirmEmailTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                var badRequest = _resultFactory.GetBadRequestResult<AccountEmailRequestDTO>(InstaConnectErrorMessages.AccountEmailDoesNotExist);

                return badRequest;
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var accountEmailRequestDTO = new AccountEmailRequestDTO()
            {
                UserId = userId,
                Token = token
            };

            var okResult = _resultFactory.GetOkResult(accountEmailRequestDTO);

            return okResult;
        }

        public async Task<IResult<AccountResultDTO>> ConfirmEmailAsync(string userId, string token)
        {
            var decodedUserId = Encoding.UTF8.GetString(Convert.FromBase64String(userId));
            var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (!result.Succeeded)
            {
                var errors = result.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(errors);

                return badRequestResult;
            }

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountEmailRequestDTO>> GenerateResetPasswordTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountEmailRequestDTO>(InstaConnectErrorMessages.AccountEmailDoesNotExist);

                return badRequestResult;
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var accountEmailRequestDTO = new AccountEmailRequestDTO()
            {
                UserId = userId,
                Token = token
            };

            var okResult = _resultFactory.GetOkResult(accountEmailRequestDTO);

            return okResult;
        }

        public async Task<IResult<AccountResultDTO>> ResetPasswordAsync(string userId, string token, AccountResetPasswordDTO accountResetPasswordDTO)
        {
            var decodedUserId = Encoding.UTF8.GetString(Convert.FromBase64String(userId));
            var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            var result = await _userManager.ResetPasswordAsync(user, decodedToken, accountResetPasswordDTO.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(errors);

                return badRequestResult;
            }

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }
    }
}
