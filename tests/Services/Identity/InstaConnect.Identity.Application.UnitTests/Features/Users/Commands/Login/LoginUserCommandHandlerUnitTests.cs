using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.LoginUser;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Filters;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.LoginUser;

public class LoginUserCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly LoginUserCommandHandler _commandHandler;

    public LoginUserCommandHandlerUnitTests()
    {
        _commandHandler = new(
            PasswordHasher,
            InstaConnectMapper,
            UserWriteRepository,
            AccessTokenGenerator,
            UserClaimWriteRepository);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserInvalidDetailsException_WhenEmailIsInvalid()
    {
        // Arrange
        var command = new LoginUserCommand(
            UserTestUtilities.InvalidEmail,
            UserTestUtilities.ValidPassword
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserInvalidDetailsException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserInvalidDetailsException_WhenPasswordIsInvalid()
    {
        // Arrange
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
            UserTestUtilities.InvalidPassword
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserInvalidDetailsException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserEmailNotConfirmedException_WhenEmailIsNotConfirmed()
    {
        // Arrange
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmailWithUnconfirmedEmail,
            UserTestUtilities.ValidPassword
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserEmailNotConfirmedException>();
    }

    [Fact]
    public async Task Handle_ShouldCallTheUserClaimsRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserClaimWriteRepository
            .Received(1)
            .GetAllAsync(Arg.Is<UserClaimCollectionWriteQuery>(uc => uc.UserId == UserTestUtilities.ValidId), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheAccessTokenGenerator_WhenRequestIsValid()
    {
        // Arrange
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        AccessTokenGenerator
            .Received(1)
            .GenerateAccessToken(Arg.Is<CreateAccessTokenModel>(at => at.UserId == UserTestUtilities.ValidId &&
                                                                      at.Email == UserTestUtilities.ValidEmail &&
                                                                      at.FirstName == UserTestUtilities.ValidFirstName &&
                                                                      at.LastName == UserTestUtilities.ValidLastName &&
                                                                      at.UserName == UserTestUtilities.ValidName &&
                                                                      at.UserClaims.All(uc => uc.UserId == UserTestUtilities.ValidId &&
                                                                                              uc.Claim == AppClaims.Admin &&
                                                                                              uc.Value == AppClaims.Admin)));
    }

    [Fact]
    public async Task Handle_ShouldReturnUserTokenCommandViewModel_WhenRequestIsValid()
    {
        // Arrange
        var command = new LoginUserCommand(
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserTokenCommandViewModel>(at => at.Value == UserTestUtilities.ValidAccessTokenValue &&
                                                       at.ValidUntil == UserTestUtilities.ValidUntil);
    }
}
