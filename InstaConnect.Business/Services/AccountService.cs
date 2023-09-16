using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Abstraction.Helpers;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Models.Utilities;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace InstaConnect.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IEmailManager _emailManager;
        private readonly ITokenManager _tokenManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(
            IMapper mapper,
            IResultFactory resultFactory,
            IEmailManager emailManager,
            ITokenManager tokenManager,
            UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _emailManager = emailManager;
            _tokenManager = tokenManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IResult<AccountResultDTO>> LoginAsync(AccountLoginDTO accountLoginDTO)
        {
            var existingUser = await _userManager.FindByEmailAsync(accountLoginDTO.Email);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidLogin);

                return badRequestResult;
            }

            var passwordSignInResult = await _signInManager.PasswordSignInAsync(existingUser, accountLoginDTO.Password, false, false);

            if (!passwordSignInResult.Succeeded)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidLogin);

                return badRequestResult;
            }

            var IsUserEmailConfirmed = await _userManager.IsEmailConfirmedAsync(existingUser);

            if (!IsUserEmailConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountEmailNotConfirmed);

                return badRequestResult;
            }

            var value = _tokenManager.GenerateAccessToken(existingUser.Id);
            await _tokenManager.AddAccessTokenAsync(existingUser.Id, value);

            var accessToken = await _tokenManager.GetByValueAsync(value);
            var accountResultDTO = _mapper.Map<AccountResultDTO>(accessToken);
            var okResult = _resultFactory.GetOkResult(accountResultDTO);

            return okResult;
        }

        public async Task<IResult<AccountResultDTO>> LogoutAsync(string value)
        {
            await _tokenManager.RemoveAsync(value);

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
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
            var createUserResult = await _userManager.CreateAsync(user, accountRegistrationDTO.Password);

            if (!createUserResult.Succeeded)
            {
                var errors = createUserResult.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(errors);

                return badRequestResult;
            }

            var addUserRoleResult = await _userManager.AddToRoleAsync(user, InstaConnectConstants.UserRole);

            if (!addUserRoleResult.Succeeded)
            {
                var errors = addUserRoleResult.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(errors);

                return badRequestResult;
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var emailWasSendSuccesfully = await _emailManager.SendEmailConfirmationAsync(user.Email, user.Id, token);

            if (!emailWasSendSuccesfully)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountSendEmailFailed);

                return badRequestResult;
            }

            await _tokenManager.AddEmailConfirmationTokenAsync(user.Id, token);

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountResultDTO>> ResendEmailConfirmationTokenAsync(string email)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser == null)
            {
                var badRequest = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountEmailDoesNotExist);

                return badRequest;
            }

            var IsUserEmailConfirmed = await _userManager.IsEmailConfirmedAsync(existingUser);

            if (IsUserEmailConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountEmailAlreadyConfirmed);

                return badRequestResult;
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(existingUser);
            var emailWasSendSuccesfully = await _emailManager.SendEmailConfirmationAsync(existingUser.Email, existingUser.Id, token);

            if (!emailWasSendSuccesfully)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountSendEmailFailed);

                return badRequestResult;
            }

            await _tokenManager.AddEmailConfirmationTokenAsync(existingUser.Id, token);

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountResultDTO>> ConfirmEmailWithTokenAsync(string userId, string encodedToken)
        {
            var existingUser = await _userManager.FindByIdAsync(userId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            var IsUserEmailConfirmed = await _userManager.IsEmailConfirmedAsync(existingUser);

            if (IsUserEmailConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountEmailAlreadyConfirmed);

                return badRequestResult;
            }

            var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(encodedToken));
            var confirmEmailResult = await _userManager.ConfirmEmailAsync(existingUser, decodedToken);

            if (!confirmEmailResult.Succeeded)
            {
                var errors = confirmEmailResult.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(errors);

                return badRequestResult;
            }

            await _tokenManager.RemoveAsync(decodedToken);

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountResultDTO>> SendPasswordResetTokenByEmailAsync(string email)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountEmailDoesNotExist);

                return badRequestResult;
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(existingUser);

            var emailWasSendSuccesfully = await _emailManager.SendPasswordResetAsync(existingUser.Email, existingUser.Id, token);

            if (!emailWasSendSuccesfully)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountSendEmailFailed);

                return badRequestResult;
            }

            await _tokenManager.AddForgotPasswordTokenAsync(existingUser.Id, token);

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountResultDTO>> ResetPasswordWithTokenAsync(string userId, string encodedToken, AccountResetPasswordDTO accountResetPasswordDTO)
        {
            var existingUser = await _userManager.FindByIdAsync(userId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(encodedToken));
            var resetPasswordResult = await _userManager.ResetPasswordAsync(existingUser, decodedToken, accountResetPasswordDTO.Password);

            if (!resetPasswordResult.Succeeded)
            {
                var errors = resetPasswordResult.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(errors);

                return badRequestResult;
            }

            await _tokenManager.RemoveAsync(decodedToken);

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }
    }
}
