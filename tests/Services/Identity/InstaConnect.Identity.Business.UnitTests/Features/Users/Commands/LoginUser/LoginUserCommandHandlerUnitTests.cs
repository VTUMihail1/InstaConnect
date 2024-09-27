using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.LoginUser;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Filters;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Utilities;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.LoginUser;

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
            InvalidEmail,
            ValidPassword
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
            ValidEmail,
            InvalidPassword
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserInvalidDetailsException>();
    }

    [Fact]
    public async Task Handle_ShouldCallTheUserClaimsRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new LoginUserCommand(
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
        var command = new LoginUserCommand(
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
    public async Task Handle_ShouldReturnUserTokenCommandViewModel_WhenRequestIsValid()
    {
        // Arrange
        var command = new LoginUserCommand(
            ValidEmail,
            ValidPassword
        );

        // Act
        var response = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserTokenCommandViewModel>(at => at.Value == ValidAccessTokenValue &&
                                                       at.ValidUntil == ValidUntil);
    }
}
