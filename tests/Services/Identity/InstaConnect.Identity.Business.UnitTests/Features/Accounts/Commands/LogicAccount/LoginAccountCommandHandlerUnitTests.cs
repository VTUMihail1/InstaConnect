using FluentAssertions;
using InstaConnect.Identity.Business.Features.Accounts.Commands.LoginAccount;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Filters;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Data.Utilities;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.LogicAccount;

public class LoginAccountCommandHandlerUnitTests : BaseAccountUnitTest
{
    private readonly LoginAccountCommandHandler _commandHandler;

    public LoginAccountCommandHandlerUnitTests()
    {
        _commandHandler = new(
            PasswordHasher,
            InstaConnectMapper,
            UserWriteRepository,
            AccessTokenGenerator,
            UserClaimWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountInvalidDetailsException_WhenEmailIsInvalid()
    {
        // Arrange
        var command = new LoginAccountCommand(
            InvalidEmail,
            ValidPassword
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountInvalidDetailsException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountInvalidDetailsException_WhenPasswordIsInvalid()
    {
        // Arrange
        var command = new LoginAccountCommand(
            ValidEmail,
            InvalidPassword
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountInvalidDetailsException>();
    }

    [Fact]
    public async Task Handle_ShouldCallTheUserClaimsRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new LoginAccountCommand(
            ValidEmail,
            ValidPassword
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserClaimWriteRepository
            .Received(1)
            .GetAllAsync(Arg.Is<UserClaimCollectionWriteQuery>(uc => uc.UserId == ValidId), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheAccessTokenGenerator_WhenRequestIsValid()
    {
        // Arrange
        var command = new LoginAccountCommand(
            ValidEmail,
            ValidPassword
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        AccessTokenGenerator
            .Received(1)
            .GenerateAccessToken(Arg.Is<CreateAccessTokenModel>(at => at.UserId == ValidId &&
                                                                      at.Email == ValidEmail &&
                                                                      at.FirstName == ValidFirstName &&
                                                                      at.LastName == ValidLastName &&
                                                                      at.UserName == ValidName &&
                                                                      at.UserClaims.All(uc => uc.UserId == ValidId &&
                                                                                              uc.Claim == AppClaims.Admin &&
                                                                                              uc.Value == AppClaims.Admin)));
    }

    [Fact]
    public async Task Handle_ShouldReturnAccountTokenCommandViewModel_WhenRequestIsValid()
    {
        // Arrange
        var command = new LoginAccountCommand(
            ValidEmail,
            ValidPassword
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<AccountTokenCommandViewModel>(at => at.Value == ValidAccessTokenValue &&
                                                       at.ValidUntil == ValidUntil);
    }
}
