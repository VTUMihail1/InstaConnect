﻿using AutoMapper;
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
            var user = await _userManager.FindByEmailAsync(accountLoginDTO.Email);

            if (user == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountInvalidLogin);

                return badRequestResult;
            }

            var result = await _signInManager.PasswordSignInAsync(user, accountLoginDTO.Password, false, false);

            if (!result.Succeeded)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountInvalidLogin);

                return badRequestResult;
            }

            var emailIsConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            if (!emailIsConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountEmailNotConfirmed);

                return badRequestResult;
            }

            var userId = await _userManager.GetUserIdAsync(user);
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
            var userResult = await _userManager.CreateAsync(user, accountRegistrationDTO.Password);

            if (!userResult.Succeeded)
            {
                var errors = userResult.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<string>(errors);

                return badRequestResult;
            }

            var roleResult = await _userManager.AddToRoleAsync(user, InstaConnectDataConstants.UserRole);

            if (!roleResult.Succeeded)
            {
                var errors = roleResult.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<string>(errors);

                return badRequestResult;
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var okResult = _resultFactory.GetOkResult(userId);

            return okResult;
        }

        public async Task<IResult<string>> SendAccountConfirmEmailTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                var badRequest = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountEmailDoesNotExist);

                return badRequest;
            }

            var emailIsConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            if (emailIsConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountEmailAlreadyConfirmed);

                return badRequestResult;
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            await _emailHandler.SendEmailConfirmationAsync(user.Email, user.Id, token);

            var okResult = _resultFactory.GetOkResult(token);

            return okResult;
        }

        public async Task<IResult<string>> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            var emailIsConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            if (emailIsConfirmed)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountEmailAlreadyConfirmed);

                return badRequestResult;
            }

            var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (!result.Succeeded)
            {
                var errors = result.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<string>(errors);

                return badRequestResult;
            }

            var okResult = _resultFactory.GetOkResult(token);

            return okResult;
        }

        public async Task<IResult<string>> SendAccountResetPasswordTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountEmailDoesNotExist);

                return badRequestResult;
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _emailHandler.SendPasswordResetAsync(user.Email, user.Id, token);

            var okResult = _resultFactory.GetOkResult(token);

            return okResult;
        }

        public async Task<IResult<string>> ResetPasswordAsync(string userId, string token, AccountResetPasswordDTO accountResetPasswordDTO)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<string>(InstaConnectBusinessErrorMessages.AccountInvalidToken);

                return badRequestResult;
            }

            var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var result = await _userManager.ResetPasswordAsync(user, decodedToken, accountResetPasswordDTO.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors
                    .Select(x => x.Description)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<string>(errors);

                return badRequestResult;
            }

            var okResult = _resultFactory.GetOkResult(token);

            return okResult;
        }
    }
}
