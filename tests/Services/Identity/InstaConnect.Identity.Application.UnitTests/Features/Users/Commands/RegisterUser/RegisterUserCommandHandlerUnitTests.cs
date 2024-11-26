using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Application.Models;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.RegisterUser;

public class RegisterUserCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly RegisterUserCommandHandler _commandHandler;

    public RegisterUserCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            ImageHandler,
            PasswordHasher,
            EventPublisher,
            InstaConnectMapper,
            UserWriteRepository,
            EmailConfirmationTokenPublisher);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsInvalid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            UserTestUtilities.InvalidName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserEmailAlreadyTakenException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserUserNameAlreadyTakenException_WhenUserNameIsInvalid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            UserTestUtilities.ValidName,
            UserTestUtilities.InvalidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNameAlreadyTakenException>();
    }

    [Fact]
    public async Task Handle_ShouldNotCallTheImageHandler_WhenRequestIsValidAndProfileImageIsNull()
    {
        // Arrange
        var command = new RegisterUserCommand(
            UserTestUtilities.InvalidName,
            UserTestUtilities.InvalidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            null!
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ImageHandler
            .Received(0)
            .UploadAsync(Arg.Any<ImageUploadModel>(), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheImageHandler_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            UserTestUtilities.InvalidName,
            UserTestUtilities.InvalidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ImageHandler
            .Received(1)
            .UploadAsync(Arg.Is<ImageUploadModel>(u => u.FormFile == UserTestUtilities.ValidFormFile), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallThePasswordHasher_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            UserTestUtilities.InvalidName,
            UserTestUtilities.InvalidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PasswordHasher
            .Received(1)
            .Hash(UserTestUtilities.ValidPassword);
    }

    [Fact]
    public async Task Handle_ShouldAddTheUserToTheRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            UserTestUtilities.InvalidName,
            UserTestUtilities.InvalidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        UserWriteRepository
            .Received(1)
            .Add(Arg.Is<User>(u => !string.IsNullOrEmpty(u.Id) &&
                                   u.FirstName == UserTestUtilities.ValidFirstName &&
                                   u.LastName == UserTestUtilities.ValidLastName &&
                                   u.UserName == UserTestUtilities.InvalidName &&
                                   u.Email == UserTestUtilities.InvalidEmail &&
                                   u.ProfileImage == UserTestUtilities.ValidProfileImage));
    }

    [Fact]
    public async Task Handle_ShouldPublishUserCreatedEvent_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            UserTestUtilities.InvalidName,
            UserTestUtilities.InvalidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .PublishAsync(Arg.Is<UserCreatedEvent>(u => !string.IsNullOrEmpty(UserTestUtilities.ValidId) &&
                                   u.FirstName == UserTestUtilities.ValidFirstName &&
                                   u.LastName == UserTestUtilities.ValidLastName &&
                                   u.UserName == UserTestUtilities.InvalidName &&
                                   u.Email == UserTestUtilities.InvalidEmail &&
                                   u.ProfileImage == UserTestUtilities.ValidProfileImage), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldPublishEmailConfirmationToken_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            UserTestUtilities.InvalidName,
            UserTestUtilities.InvalidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EmailConfirmationTokenPublisher
            .Received(1)
            .PublishEmailConfirmationTokenAsync(Arg.Is<CreateEmailConfirmationTokenModel>(u =>
                                   !string.IsNullOrEmpty(u.UserId) &&
                                   u.Email == UserTestUtilities.InvalidEmail), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallUnitOfWorkCommit_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            UserTestUtilities.InvalidName,
            UserTestUtilities.InvalidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnUserCommandViewModel_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            UserTestUtilities.InvalidName,
            UserTestUtilities.InvalidEmail,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidPassword,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidFormFile
        );

        // Act
        var result = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        result
            .Should()
            .Match<UserCommandViewModel>(a => !string.IsNullOrEmpty(a.Id));
    }
}
