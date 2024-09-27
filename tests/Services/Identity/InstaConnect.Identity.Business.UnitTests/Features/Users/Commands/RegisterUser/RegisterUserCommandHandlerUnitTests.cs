using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.RegisterUser;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Models;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.RegisterUser;

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
            InvalidName,
            ValidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
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
            ValidName,
            InvalidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
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
            InvalidName,
            InvalidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
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
            InvalidName,
            InvalidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ImageHandler
            .Received(1)
            .UploadAsync(Arg.Is<ImageUploadModel>(u => u.FormFile == ValidFormFile), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallThePasswordHasher_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            InvalidName,
            InvalidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PasswordHasher
            .Received(1)
            .Hash(ValidPassword);
    }

    [Fact]
    public async Task Handle_ShouldAddTheUserToTheRepository_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            InvalidName,
            InvalidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        UserWriteRepository
            .Received(1)
            .Add(Arg.Is<User>(u => !string.IsNullOrEmpty(u.Id) &&
                                   u.FirstName == ValidFirstName &&
                                   u.LastName == ValidLastName &&
                                   u.UserName == InvalidName &&
                                   u.Email == InvalidEmail &&
                                   u.ProfileImage == ValidProfileImage));
    }

    [Fact]
    public async Task Handle_ShouldPublishUserCreatedEvent_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            InvalidName,
            InvalidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .PublishAsync(Arg.Is<UserCreatedEvent>(u => !string.IsNullOrEmpty(ValidId) &&
                                   u.FirstName == ValidFirstName &&
                                   u.LastName == ValidLastName &&
                                   u.UserName == InvalidName &&
                                   u.Email == InvalidEmail &&
                                   u.ProfileImage == ValidProfileImage), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldPublishEmailConfirmationToken_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            InvalidName,
            InvalidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EmailConfirmationTokenPublisher
            .Received(1)
            .PublishEmailConfirmationTokenAsync(Arg.Is<CreateEmailConfirmationTokenModel>(u =>
                                   !string.IsNullOrEmpty(u.UserId) &&
                                   u.Email == InvalidEmail), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallUnitOfWorkCommit_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterUserCommand(
            InvalidName,
            InvalidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
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
            InvalidName,
            InvalidEmail,
            ValidPassword,
            ValidPassword,
            ValidFirstName,
            ValidLastName,
            ValidFormFile
        );

        // Act
        var result = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        result
            .Should()
            .Match<UserCommandViewModel>(a => !string.IsNullOrEmpty(a.Id));
    }
}
