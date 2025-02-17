using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Application.Models;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.Add;

public class AddUserCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly AddUserCommandHandler _commandHandler;

    public AddUserCommandHandlerUnitTests()
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
        var existingUser = CreateUser();
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            existingUser.Email,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
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
        var existingUser = CreateUser();
        var command = new AddUserCommand(
            existingUser.UserName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
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
        var existingUser = CreateUser();
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            null
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
        var existingUser = CreateUser();
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ImageHandler
            .Received(1)
            .UploadAsync(Arg.Is<ImageUploadModel>(u => u.FormFile == UserTestUtilities.ValidAddFormFile), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallThePasswordHasher_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        PasswordHasher
            .Received(1)
            .Hash(UserTestUtilities.ValidAddPassword);
    }

    [Fact]
    public async Task Handle_ShouldAddTheUserToTheRepository_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        UserWriteRepository
            .Received(1)
            .Add(Arg.Is<User>(u => !string.IsNullOrEmpty(u.Id) &&
                                   u.FirstName == UserTestUtilities.ValidAddFirstName &&
                                   u.LastName == UserTestUtilities.ValidAddLastName &&
                                   u.UserName == UserTestUtilities.ValidAddName &&
                                   u.Email == UserTestUtilities.ValidAddEmail &&
                                   u.ProfileImage == UserTestUtilities.ValidAddProfileImage));
    }

    [Fact]
    public async Task Handle_ShouldPublishUserCreatedEvent_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EventPublisher
            .Received(1)
            .PublishAsync(Arg.Is<UserCreatedEvent>(u => !string.IsNullOrEmpty(u.Id) &&
                                   u.FirstName == UserTestUtilities.ValidAddFirstName &&
                                   u.LastName == UserTestUtilities.ValidAddLastName &&
                                   u.UserName == UserTestUtilities.ValidAddName &&
                                   u.Email == UserTestUtilities.ValidAddEmail &&
                                   u.ProfileImage == UserTestUtilities.ValidAddProfileImage), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldPublishEmailConfirmationToken_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EmailConfirmationTokenPublisher
            .Received(1)
            .PublishEmailConfirmationTokenAsync(Arg.Is<CreateEmailConfirmationTokenModel>(u =>
                                   !string.IsNullOrEmpty(u.UserId) &&
                                   u.Email == UserTestUtilities.ValidAddEmail), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallUnitOfWorkCommit_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
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
        var existingUser = CreateUser();
        var command = new AddUserCommand(
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddPassword,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddFormFile
        );

        // Act
        var result = await _commandHandler.Handle(command, CancellationToken);

        // Assert
        result
            .Should()
            .Match<UserCommandViewModel>(a => !string.IsNullOrEmpty(a.Id));
    }
}
