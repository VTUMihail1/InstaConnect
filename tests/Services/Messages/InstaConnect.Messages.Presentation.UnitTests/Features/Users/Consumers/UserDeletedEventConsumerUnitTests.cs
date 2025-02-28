using InstaConnect.Messages.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Messages.Presentation.UnitTests.Features.Users.Consumers;

public class UserDeletedEventConsumerUnitTests : BaseUserUnitTest
{
    private readonly UserDeletedEventConsumer _userDeletedEventConsumer;
    private readonly ConsumeContext<UserDeletedEvent> _userDeletedEventConsumeContext;

    public UserDeletedEventConsumerUnitTests()
    {
        _userDeletedEventConsumer = new(
            UnitOfWork,
            UserWriteRepository);

        _userDeletedEventConsumeContext = Substitute.For<ConsumeContext<UserDeletedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetUserByIdAsyncMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent(UserTestUtilities.InvalidId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.InvalidId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotDeleteMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent(UserTestUtilities.InvalidId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(0)
            .Delete(Arg.Any<User>());
    }

    [Fact]
    public async Task Consume_ShouldNotCallSaveChangesAsync_WhenUserIdIsInvalid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent(UserTestUtilities.InvalidId);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(0)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldGetUserById_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userDeletedEvent = new UserDeletedEvent(existingUser.Id);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(existingUser.Id, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldAddUserToRepository_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userDeletedEvent = new UserDeletedEvent(existingUser.Id);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(1)
            .Delete(Arg.Is<User>(m => m.Id == existingUser.Id &&
                                   m.UserName == existingUser.UserName &&
                                   m.FirstName == existingUser.FirstName &&
                                   m.LastName == existingUser.LastName &&
                                   m.Email == existingUser.Email &&
                                   m.ProfileImage == existingUser.ProfileImage));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var userDeletedEvent = new UserDeletedEvent(existingUser.Id);

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
