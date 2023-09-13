using AutoMapper;
using InstaConnect.Business.Abstraction.Factories;
using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.DTOs.Account;
using InstaConnect.Business.Models.Results;
using InstaConnect.Business.Models.Utilities;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Data.Models.Utilities;
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
        private readonly IEmailHandler _emailHandler;

        public AccountService(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IResultFactory resultFactory,
            IMapper mapper,
            IEmailHandler emailHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _resultFactory = resultFactory;
            _mapper = mapper;
            _emailHandler = emailHandler;
        }

        public async Task<IResult<string>> LoginAsync(AccountLoginDTO accountLoginDTO)
        {
            var existingUser = await _userManager.FindByEmailAsync(accountLoginDTO.Email);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountInvalidLogin);

                return badRequestResult;
            }

            var passwordSignInResult = await _signInManager.PasswordSignInAsync(existingUser, accountLoginDTO.Password, false, false);

            if (!passwordSignInResult.Succeeded)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountInvalidLogin);

                return badRequestResult;
            }

            var IsUserEmailConfirmed = await _userManager.IsEmailConfirmedAsync(existingUser);

            if (!IsUserEmailConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountEmailNotConfirmed);

                return badRequestResult;
            }

            var userId = await _userManager.GetUserIdAsync(existingUser);
            var okResult = _resultFactory.GetOkResult(userId);

            return okResult;
        }

        public async Task<IResult<string>> SignUpAsync(AccountRegistrationDTO accountRegistrationDTO)
        {
            var existingUser = await _userManager.FindByEmailAsync(accountRegistrationDTO.Email);

            if (existingUser != null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountAlreadyExists);

                return badRequestResult;
            }

            var user = _mapper.Map<User>(accountRegistrationDTO);
            var createUserResult = await _userManager.CreateAsync(user, accountRegistrationDTO.Password);

            if (!createUserResult.Succeeded)
            {
                var errors = createUserResult.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<string>(errors);

                return badRequestResult;
            }

            var addUserRoleResult = await _userManager.AddToRoleAsync(user, InstaConnectDataConstants.UserRole);

            if (!addUserRoleResult.Succeeded)
            {
                var errors = addUserRoleResult.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<string>(errors);

                return badRequestResult;
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var okResult = _resultFactory.GetOkResult(userId);

            return okResult;
        }

        public async Task<IResult<string>> SendEmailConfirmationTokenAsync(string email)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser == null)
            {
                var badRequest = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountEmailDoesNotExist);

                return badRequest;
            }

            var IsUserEmailConfirmed = await _userManager.IsEmailConfirmedAsync(existingUser);

            if (IsUserEmailConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountEmailAlreadyConfirmed);

                return badRequestResult;
            }

            var userEmail = await _userManager.GetEmailAsync(existingUser);
            var userId = await _userManager.GetUserIdAsync(existingUser);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(existingUser);

            await _emailHandler.SendEmailConfirmationAsync(userEmail, userId, token);

            var okResult = _resultFactory.GetOkResult(token);

            return okResult;
        }

        public async Task<IResult<string>> ConfirmEmailWithTokenAsync(string userId, string encodedToken)
        {
            var existingUser = await _userManager.FindByIdAsync(userId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            var IsUserEmailConfirmed = await _userManager.IsEmailConfirmedAsync(existingUser);

            if (IsUserEmailConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountEmailAlreadyConfirmed);

                return badRequestResult;
            }

            var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(encodedToken));
            var confirmEmailResult = await _userManager.ConfirmEmailAsync(existingUser, decodedToken);

            if (!confirmEmailResult.Succeeded)
            {
                var errors = confirmEmailResult.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<string>(errors);

                return badRequestResult;
            }

            var okResult = _resultFactory.GetOkResult(encodedToken);

            return okResult;
        }

        public async Task<IResult<string>> SendPasswordResetTokenByEmailAsync(string email)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountEmailDoesNotExist);

                return badRequestResult;
            }

            var userEmail = await _userManager.GetEmailAsync(existingUser);
            var userId = await _userManager.GetUserIdAsync(existingUser);
            var token = await _userManager.GeneratePasswordResetTokenAsync(existingUser);

            await _emailHandler.SendPasswordResetAsync(userEmail, userId, token);

            var okResult = _resultFactory.GetOkResult(token);

            return okResult;
        }

        public async Task<IResult<string>> ResetPasswordWithTokenAsync(string userId, string encodedToken, AccountResetPasswordDTO accountResetPasswordDTO)
        {
            var existingUser = await _userManager.FindByIdAsync(userId);

            if (existingUser == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(encodedToken));
            var resetPasswordResult = await _userManager.ResetPasswordAsync(existingUser, decodedToken, accountResetPasswordDTO.Password);

            if (!resetPasswordResult.Succeeded)
            {
                var errors = resetPasswordResult.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<string>(errors);

                return badRequestResult;
            }

            var okResult = _resultFactory.GetOkResult(decodedToken);

            return okResult;
        }
    }
}
