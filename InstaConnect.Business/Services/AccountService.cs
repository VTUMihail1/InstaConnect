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

namespace InstaConnect.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IResultFactory _resultFactory;
        private readonly IEmailManager _emailManager;
        private readonly ITokenManager _tokenManager;
        private readonly IInstaConnectUserManager _instaConnectUserManager;

        public AccountService(
            IMapper mapper,
            IResultFactory resultFactory,
            IEmailManager emailManager,
            ITokenManager tokenManager,
            IInstaConnectUserManager instaConnectUserManager)
        {
            _mapper = mapper;
            _resultFactory = resultFactory;
            _emailManager = emailManager;
            _tokenManager = tokenManager;
            _instaConnectUserManager = instaConnectUserManager;
        }

        public async Task<IResult<AccountResultDTO>> LoginAsync(AccountLoginDTO accountLoginDTO)
        {
            var existingUser = await _instaConnectUserManager.FindByEmailAsync(accountLoginDTO.Email);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidLogin);

                return badRequestResult;
            }

            var passwordIsValid = await _instaConnectUserManager.CheckPasswordAsync(existingUser, accountLoginDTO.Password);

            if (!passwordIsValid)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidLogin);

                return badRequestResult;
            }

            var emailIsConfirmed = await _instaConnectUserManager.IsEmailConfirmedAsync(existingUser);

            if (!emailIsConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountEmailNotConfirmed);

                return badRequestResult;
            }

            var token = _tokenManager.GenerateAccessToken(existingUser.Id);

            var accountResultDTO = _mapper.Map<AccountResultDTO>(token);
            var okResult = _resultFactory.GetOkResult(accountResultDTO);

            return okResult;
        }

        public async Task<IResult<AccountResultDTO>> LogoutAsync(string value)
        {
            var tokenWasDeleted = await _tokenManager.RemoveAsync(value);

            if (!tokenWasDeleted)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountResultDTO>> SignUpAsync(AccountRegisterDTO accountRegisterDTO)
        {
            var existingUserWithThatEmail = await _instaConnectUserManager.FindByEmailAsync(accountRegisterDTO.Email);

            if (existingUserWithThatEmail != null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>();

                return badRequestResult;
            }

            var existingUserWithThatUsername = await _instaConnectUserManager.FindByNameAsync(accountRegisterDTO.Username);

            if (existingUserWithThatUsername != null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>();

                return badRequestResult;
            }

            var user = _mapper.Map<User>(accountRegisterDTO);

            await _instaConnectUserManager.CreateAsync(user, accountRegisterDTO.Password);
            await _instaConnectUserManager.AddToRoleAsync(user, InstaConnectConstants.UserRole);

            var token = await _tokenManager.GenerateEmailConfirmationTokenAsync(user.Id);

            var emailWasSendSuccesfully = await _emailManager.SendEmailConfirmationAsync(user.Email, user.Id, token.Value);

            if (!emailWasSendSuccesfully)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountSendEmailFailed);

                return badRequestResult;
            }

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountResultDTO>> ResendEmailConfirmationTokenAsync(string email)
        {
            var existingUser = await _instaConnectUserManager.FindByEmailAsync(email);

            if (existingUser == null)
            {
                var badRequest = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountEmailDoesNotExist);

                return badRequest;
            }

            var emailIsConfirmed = await _instaConnectUserManager.IsEmailConfirmedAsync(existingUser);

            if (emailIsConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountEmailAlreadyConfirmed);

                return badRequestResult;
            }

            var token = await _tokenManager.GenerateEmailConfirmationTokenAsync(existingUser.Id);

            var emailWasSendSuccesfully = await _emailManager.SendEmailConfirmationAsync(existingUser.Email, existingUser.Id, token.Value);

            if (!emailWasSendSuccesfully)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountSendEmailFailed);

                return badRequestResult;
            }

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountResultDTO>> ConfirmEmailWithTokenAsync(string userId, string token)
        {
            var existingUser = await _instaConnectUserManager.FindByIdAsync(userId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            var emailIsConfirmed = await _instaConnectUserManager.IsEmailConfirmedAsync(existingUser);

            if (emailIsConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountEmailAlreadyConfirmed);

                return badRequestResult;
            }

            var tokenWasDeleted = await _tokenManager.RemoveAsync(token);

            if (!tokenWasDeleted)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            await _instaConnectUserManager.ConfirmEmailAsync(existingUser);

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountResultDTO>> SendPasswordResetTokenByEmailAsync(string email)
        {
            var existingUser = await _instaConnectUserManager.FindByEmailAsync(email);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountEmailDoesNotExist);

                return badRequestResult;
            }

            var token = await _tokenManager.GeneratePasswordResetToken(existingUser.Id);

            var emailWasSendSuccesfully = await _emailManager.SendPasswordResetAsync(existingUser.Email, existingUser.Id, token.Value);

            if (!emailWasSendSuccesfully)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountSendEmailFailed);

                return badRequestResult;
            }

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountResultDTO>> ResetPasswordWithTokenAsync(string userId, string token, AccountResetPasswordDTO accountResetPasswordDTO)
        {
            var existingUser = await _instaConnectUserManager.FindByIdAsync(userId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            var tokenWasDeleted = await _tokenManager.RemoveAsync(token);

            if (!tokenWasDeleted)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            await _instaConnectUserManager.ResetPasswordAsync(existingUser, accountResetPasswordDTO.Password);

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountResultDTO>> EditAsync(string id, AccountEditDTO accountEditDTO)
        {
            var existingUserById = await _instaConnectUserManager.FindByIdAsync(id);

            if (existingUserById == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<AccountResultDTO>();

                return notFoundResult;
            }

            var existingUserByName = await _instaConnectUserManager.FindByNameAsync(accountEditDTO.UserName);

            if (existingUserById.UserName != accountEditDTO.UserName && existingUserByName != null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AccountResultDTO>(InstaConnectErrorMessages.AccountUsernameAlreadyExists);

                return badRequestResult;
            }

            _mapper.Map(accountEditDTO, existingUserById);
            await _instaConnectUserManager.UpdateAsync(existingUserById);

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }

        public async Task<IResult<AccountResultDTO>> DeleteAsync(string id)
        {
            var existingUser = await _instaConnectUserManager.FindByIdAsync(id);

            if (existingUser == null)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<AccountResultDTO>();

                return notFoundResult;
            }

            await _instaConnectUserManager.DeleteAsync(existingUser);

            var noContentResult = _resultFactory.GetNoContentResult<AccountResultDTO>();

            return noContentResult;
        }
    }
}
