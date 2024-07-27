using InstaConnect.Messages.Business.UnitTests.Utilities;
using InstaConnect.Messages.Business.Consumers.Users;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Tests.Consumers.Users;

public class UserUpdatedEventConsumerUnitTests : BaseMessageUnitTest
{
    private readonly UserUpdatedEventConsumer _userUpdatedEventConsumer;
    private readonly ConsumeContext<UserUpdatedEvent> _userUpdatedEventConsumeContext;

    public UserUpdatedEventConsumerUnitTests()
    {
        _userUpdatedEventConsumer = new(
            UnitOfWork,
            UserReadRepository,
            InstaConnectMapper);

        _userUpdatedEventConsumeContext = Substitute.For<ConsumeContext<UserUpdatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetUserByIdAsyncMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userUpdatedEvent = new UserUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UserReadRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.NON_EXISTING_USER_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotAddMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userUpdatedEvent = new UserUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

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
        var userUpdatedEvent = new UserUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(0)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldGetUserById_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userUpdatedEvent = new UserUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UserReadRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.EXISTING_SENDER_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldAddUserToRepository_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userUpdatedEvent = new UserUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(1)
            .Update(Arg.Is<User>(m => m.Id == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
                                   m.FirstName == MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME &&
                                   m.LastName == MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME &&
                                   m.UserName == MessageUnitTestConfigurations.EXISTING_SENDER_NAME &&
                                   m.Email == MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL &&
                                   m.ProfileImage == MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userUpdatedEvent = new UserUpdatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userUpdatedEventConsumeContext.Message.Returns(userUpdatedEvent);

        // Act
        await _userUpdatedEventConsumer.Consume(_userUpdatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
