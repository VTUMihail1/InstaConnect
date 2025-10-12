namespace InstaConnect.Messages.Presentation.UnitTests.Features.Users.Consumers;

public class UserUpdatedEventConsumerUnitTests : BaseUserUnitTest
{
    private readonly UserUpdatedEventConsumer _userUpdatedEventConsumer;
    private readonly ConsumeContext<UserUpdatedEventRequest> _userUpdatedEventConsumeContext;

    public UserUpdatedEventConsumerUnitTests()
    {
        _userUpdatedEventConsumer = new(
            UnitOfWork,
            ApplicationMapper,
            UserWriteRepository);

        _userUpdatedEventConsumeContext = Substitute.For<ConsumeContext<UserUpdatedEventRequest>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetUserByIdAsyncMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userUpdatedEvent = new UserUpdatedEventRequest(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidUpdateName,
            existingUser.Email,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.InvalidId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotAddMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userUpdatedEvent = new UserUpdatedEventRequest(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidUpdateName,
            existingUser.Email,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(0)
            .Add(Arg.Any<User>());
    }

    [Fact]
    public async Task Consume_ShouldNotCallSaveChangesAsync_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userUpdatedEvent = new UserUpdatedEventRequest(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidUpdateName,
            existingUser.Email,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(0)
            .CommitAsync(CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldGetUserById_WhenUserUpdatedEventIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userUpdatedEvent = new UserUpdatedEventRequest(
            existingUser.Id,
            UserTestUtilities.ValidUpdateName,
            existingUser.Email,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(existingUser.Id, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldUpdateUserToRepository_WhenUserUpdatedEventIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userUpdatedEvent = new UserUpdatedEventRequest(
            existingUser.Id,
            UserTestUtilities.ValidUpdateName,
            existingUser.Email,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(1)
            .Update(Arg.Is<User>(m => m.Id == existingUser.Id &&
                                   m.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                                   m.LastName == UserTestUtilities.ValidUpdateLastName &&
                                   m.UserName == UserTestUtilities.ValidUpdateName &&
                                   m.Email == existingUser.Email &&
                                   m.ProfileImage == UserTestUtilities.ValidUpdateProfileImage));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userUpdatedEvent = new UserUpdatedEventRequest(
            existingUser.Id,
            UserTestUtilities.ValidUpdateName,
            existingUser.Email,
            UserTestUtilities.ValidUpdateFirstName,
            UserTestUtilities.ValidUpdateLastName,
            UserTestUtilities.ValidUpdateProfileImage);

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .CommitAsync(CancellationToken);
    }
}
