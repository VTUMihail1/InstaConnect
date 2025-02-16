using FluentAssertions;

using InstaConnect.Identity.Application.Features.Users.Commands.Login;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Filters;
using InstaConnect.Identity.Domain.Features.Users.Exceptions;
using InstaConnect.Shared.Common.Utilities;

using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.Login;

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
        var existingUserClaim = CreateUserClaim();
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
        var existingUserClaim = CreateUserClaim();
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
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
        var existingUserClaim = CreateUserClaimWithUnconfirmedUserEmail();
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
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
        var existingUserClaim = CreateUserClaim();
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
            UserTestUtilities.ValidPassword
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UserClaimWriteRepository
            .Received(1)
            .GetAllAsync(Arg.Is<UserClaimCollectionWriteQuery>(uc => uc.UserId == existingUserClaim.User.Id), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheAccessTokenGenerator_WhenRequestIsValid()
    {
        // Arrange
        var existingUserClaim = CreateUserClaim();
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
            UserTestUtilities.ValidPassword
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        AccessTokenGenerator
            .Received(1)
            .GenerateAccessToken(Arg.Is<CreateAccessTokenModel>(at => at.UserId == existingUserClaim.User.Id &&
                                                                      at.Email == existingUserClaim.User.Email &&
                                                                      at.FirstName == existingUserClaim.User.FirstName &&
                                                                      at.LastName == existingUserClaim.User.LastName &&
                                                                      at.UserName == existingUserClaim.User.UserName &&
                                                                      at.UserClaims.All(uc => uc.UserId == existingUserClaim.User.Id &&
                                                                                              uc.Claim == AppClaims.Admin &&
                                                                                              uc.Value == AppClaims.Admin)));
    }

    [Fact]
    public async Task Handle_ShouldReturnUserTokenCommandViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingUserClaim = CreateUserClaim();
        var command = new LoginUserCommand(
            existingUserClaim.User.Email,
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
