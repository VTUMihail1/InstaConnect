using FluentAssertions;
using InstaConnect.Identity.Business.Features.Accounts.Commands.RegisterAccount;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Models;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.RegisterAccount;

public class RegisterAccountCommandHandlerUnitTests : BaseAccountUnitTest
{
    private readonly RegisterAccountCommandHandler _commandHandler;

    public RegisterAccountCommandHandlerUnitTests()
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
    public async Task Handle_ShouldThrowAccountEmailAlreadyTakenException_WhenEmailIsInvalid()
    {
        // Arrange
        var command = new RegisterAccountCommand(
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
        await action.Should().ThrowAsync<AccountEmailAlreadyTakenException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountUserNameAlreadyTakenException_WhenUserNameIsInvalid()
    {
        // Arrange
        var command = new RegisterAccountCommand(
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
        await action.Should().ThrowAsync<AccountNameAlreadyTakenException>();
    }

    [Fact]
    public async Task Handle_ShouldNotCallTheImageHandler_WhenRequestIsValidAndProfileImageIsNull()
    {
        // Arrange
        var command = new RegisterAccountCommand(
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
        var command = new RegisterAccountCommand(
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
        var command = new RegisterAccountCommand(
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
        var command = new RegisterAccountCommand(
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
        var command = new RegisterAccountCommand(
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
        var command = new RegisterAccountCommand(
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
        var command = new RegisterAccountCommand(
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
    public async Task Handle_ShouldReturnAccountCommandViewModel_WhenRequestIsValid()
    {
        // Arrange
        var command = new RegisterAccountCommand(
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
            .Match<AccountCommandViewModel>(a => !string.IsNullOrEmpty(a.Id));
    }
}
