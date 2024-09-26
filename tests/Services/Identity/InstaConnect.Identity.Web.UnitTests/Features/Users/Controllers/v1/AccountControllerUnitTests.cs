using System.Net;
using FluentAssertions;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ConfirmAccountEmail;
using InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteAccountById;
using InstaConnect.Identity.Business.Features.Accounts.Commands.DeleteCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.EditCurrentAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.LoginAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.RegisterAccount;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ResendAccountEmailConfirmation;
using InstaConnect.Identity.Business.Features.Accounts.Commands.ResetAccountPassword;
using InstaConnect.Identity.Business.Features.Accounts.Commands.SendAccountPasswordReset;
using InstaConnect.Identity.Web.Features.Accounts.Controllers.v1;
using InstaConnect.Identity.Web.Features.Accounts.Models.Requests;
using InstaConnect.Identity.Web.Features.Accounts.Models.Responses;
using InstaConnect.Identity.Web.UnitTests.Features.Users.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Identity.Web.UnitTests.Features.Users.Controllers.v1;
public class AccountControllerUnitTests : BaseUserUnitTest
{
    private readonly AccountController _accountController;

    public AccountControllerUnitTests()
    {
        _accountController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new RegisterAccountRequest()
        {
            RegisterAccountBindingModel = new(
                ValidName,
                ValidEmail,
                ValidPassword,
                ValidPassword,
                ValidFirstName,
                ValidLastName,
                ValidFormFile)
        };

        // Act
        var response = await _accountController.RegisterAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new RegisterAccountRequest()
        {
            RegisterAccountBindingModel = new(
                ValidName,
                ValidEmail,
                ValidPassword,
                ValidPassword,
                ValidFirstName,
                ValidLastName,
                ValidFormFile)
        };

        // Act
        var response = await _accountController.RegisterAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<AccountCommandResponse>(m => m.Id == ValidId);
    }

    [Fact]
    public async Task RegisterAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new RegisterAccountRequest()
        {
            RegisterAccountBindingModel = new(
                ValidName,
                ValidEmail,
                ValidPassword,
                ValidPassword,
                ValidFirstName,
                ValidLastName,
                ValidFormFile)
        };

        // Act
        await _accountController.RegisterAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<RegisterAccountCommand>(m => m.Email == ValidEmail &&
                                                                m.Password == ValidPassword &&
                                                                m.ConfirmPassword == ValidPassword &&
                                                                m.UserName == ValidName &&
                                                                m.FirstName == ValidFirstName &&
                                                                m.LastName == ValidLastName &&
                                                                m.ProfileImage == ValidFormFile), CancellationToken);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new EditCurrentAccountRequest()
        {
            EditCurrentAccountBindingModel = new(ValidName, ValidFirstName, ValidLastName, ValidFormFile)
        };

        // Act
        var response = await _accountController.EditCurrentAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new EditCurrentAccountRequest()
        {
            EditCurrentAccountBindingModel = new(ValidName, ValidFirstName, ValidLastName, ValidFormFile)
        };

        // Act
        var response = await _accountController.EditCurrentAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<AccountCommandResponse>(m => m.Id == ValidId);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new EditCurrentAccountRequest()
        {
            EditCurrentAccountBindingModel = new(ValidName, ValidFirstName, ValidLastName, ValidFormFile)
        };

        // Act
        await _accountController.EditCurrentAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<EditCurrentAccountCommand>(m => m.CurrentUserId == ValidId &&
                                                                m.UserName == ValidName &&
                                                                m.FirstName == ValidFirstName &&
                                                                m.LastName == ValidLastName &&
                                                                m.ProfileImage == ValidFormFile), CancellationToken);
    }

    [Fact]
    public async Task EditCurrentAsync_ShouldCallTheCurrentAccountContext_WhenRequestIsValid()
    {
        // Arrange
        var request = new EditCurrentAccountRequest()
        {
            EditCurrentAccountBindingModel = new(ValidName, ValidFirstName, ValidLastName, ValidFormFile)
        };

        // Act
        await _accountController.EditCurrentAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new LoginAccountRequest()
        {
            LoginAccountBindingModel = new(ValidEmail, ValidPassword)
        };

        // Act
        var response = await _accountController.LoginAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new LoginAccountRequest()
        {
            LoginAccountBindingModel = new(ValidEmail, ValidPassword)
        };

        // Act
        var response = await _accountController.LoginAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<AccountTokenCommandResponse>(m => m.Value == ValidAccessToken &&
                                                     m.ValidUntil == ValidUntil);
    }

    [Fact]
    public async Task LoginAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new LoginAccountRequest()
        {
            LoginAccountBindingModel = new(ValidEmail, ValidPassword)
        };

        // Act
        await _accountController.LoginAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<LoginAccountCommand>(m => m.Email == ValidEmail &&
                                                          m.Password == ValidPassword), CancellationToken);
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeleteAccountByIdRequest()
        {
            Id = ValidId
        };

        // Act
        var response = await _accountController.DeleteByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new DeleteAccountByIdRequest()
        {
            Id = ValidId
        };

        // Act
        var response = await _accountController.DeleteByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<DeleteAccountByIdCommand>(m => m.Id == ValidId), CancellationToken);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _accountController.DeleteCurrentAsync(CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Act
        var response = await _accountController.DeleteCurrentAsync(CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<DeleteCurrentAccountCommand>(m => m.CurrentUserId == ValidId), CancellationToken);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldCallTheCurrentAccountContext_WhenRequestIsValid()
    {
        // Act
        var response = await _accountController.DeleteCurrentAsync(CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task ConfirmEmailAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new ConfirmAccountEmailRequest()
        {
            Token = ValidEmailConfirmationToken,
            UserId = ValidId
        };

        // Act
        var response = await _accountController.ConfirmEmailAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task ConfirmEmailAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new ConfirmAccountEmailRequest()
        {
            Token = ValidEmailConfirmationToken,
            UserId = ValidId
        };

        // Act
        var response = await _accountController.ConfirmEmailAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<ConfirmAccountEmailCommand>(m => m.Token == ValidEmailConfirmationToken &&
                                                                 m.UserId == ValidId), CancellationToken);
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new ResetAccountPasswordRequest()
        {
            Token = ValidEmailConfirmationToken,
            UserId = ValidId
        };

        // Act
        var response = await _accountController.ResetPasswordAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task ResetPasswordAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new ResetAccountPasswordRequest()
        {
            Token = ValidEmailConfirmationToken,
            UserId = ValidId,
            ResetAccountPasswordBindingModel = new(ValidPassword, ValidPassword)
        };

        // Act
        var response = await _accountController.ResetPasswordAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<ResetAccountPasswordCommand>(m => m.Token == ValidEmailConfirmationToken &&
                                                                 m.UserId == ValidId &&
                                                                 m.Password == ValidPassword &&
                                                                 m.ConfirmPassword == ValidPassword), CancellationToken);
    }

    [Fact]
    public async Task ResendConfirmEmailAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new ResendAccountConfirmEmailRequest()
        {
            Email = ValidEmail
        };

        // Act
        var response = await _accountController.ResendConfirmEmailAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task ResendConfirmEmailAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new ResendAccountConfirmEmailRequest()
        {
            Email = ValidEmail
        };

        // Act
        var response = await _accountController.ResendConfirmEmailAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<ResendAccountEmailConfirmationCommand>(m => m.Email == ValidEmail), CancellationToken);
    }

    [Fact]
    public async Task SendResetPasswordAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new SendAccountPasswordResetRequest()
        {
            Email = ValidEmail
        };

        // Act
        var response = await _accountController.SendResetPasswordAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task SendResetPasswordAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new SendAccountPasswordResetRequest()
        {
            Email = ValidEmail
        };

        // Act
        var response = await _accountController.SendResetPasswordAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<SendAccountPasswordResetCommand>(m => m.Email == ValidEmail), CancellationToken);
    }
}
