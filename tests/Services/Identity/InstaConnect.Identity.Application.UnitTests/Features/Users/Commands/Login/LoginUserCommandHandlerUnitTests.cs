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
        var existingUser = CreateUser();
        var command = new LoginUserCommand(
            UserTestUtilities.ValidAddEmail,
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
        var existingUser = CreateUser();
        var command = new LoginUserCommand(
            existingUser.Email,
            UserTestUtilities.ValidAddPassword
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
        var existingUser = CreateUserWithUnconfirmedEmail();
        var command = new LoginUserCommand(
            existingUser.Email,
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
        var existingUser = CreateUser();
        var command = new LoginUserCommand(
            existingUser.Email,
            UserTestUtilities.ValidPassword
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserClaimWriteRepository
            .Received(1)
            .GetAllAsync(Arg.Is<UserClaimCollectionWriteQuery>(uc => uc.UserId == existingUser.Id), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheAccessTokenGenerator_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new LoginUserCommand(
            existingUser.Email,
            UserTestUtilities.ValidPassword
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        AccessTokenGenerator
            .Received(1)
            .GenerateAccessToken(Arg.Is<CreateAccessTokenModel>(at => at.UserId == existingUser.Id &&
                                                                      at.Email == existingUser.Email &&
                                                                      at.FirstName == existingUser.FirstName &&
                                                                      at.LastName == existingUser.LastName &&
                                                                      at.UserName == existingUser.UserName &&
                                                                      at.UserClaims.All(uc => uc.UserId == existingUser.Id &&
                                                                                              uc.Claim == AppClaims.Admin &&
                                                                                              uc.Value == AppClaims.Admin)));
    }

    [Fact]
    public async Task Handle_ShouldReturnUserTokenCommandViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new LoginUserCommand(
            existingUser.Email,
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
