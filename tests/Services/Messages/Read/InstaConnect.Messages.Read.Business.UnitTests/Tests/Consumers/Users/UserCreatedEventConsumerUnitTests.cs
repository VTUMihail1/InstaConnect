using InstaConnect.Messages.Read.Business.Consumers.Users;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Messages.Read.Business.UnitTests.Tests.Consumers.Users;

public class UserCreatedEventConsumerUnitTests : BaseMessageUnitTest
{
    private readonly UserCreatedEventConsumer _userCreatedEventConsumer;
    private readonly ConsumeContext<UserCreatedEvent> _userCreatedEventConsumeContext;

    public UserCreatedEventConsumerUnitTests()
    {
        _userCreatedEventConsumer = new(
            UnitOfWork,
            UserRepository,
            InstaConnectMapper);

        _userCreatedEventConsumeContext = Substitute.For<ConsumeContext<UserCreatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetByIdAsyncMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        await UserRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.EXISTING_SENDER_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotAddMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        UserRepository
            .Received(0)
            .Add(Arg.Any<User>());
    }

    [Fact]
    public async Task Consume_ShouldNotCallSaveChangesAsync_WhenUserIdIsInvalid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(0)
            .SaveChangesAsync(CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldGetById_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        await UserRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.NON_EXISTING_USER_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldAddUserToRepository_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        UserRepository
            .Received(1)
            .Add(Arg.Is<User>(m => m.Id == MessageUnitTestConfigurations.NON_EXISTING_USER_ID &&
                                   m.UserName == MessageUnitTestConfigurations.EXISTING_SENDER_NAME &&
                                   m.FirstName == MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME &&
                                   m.LastName == MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME &&
                                   m.Email == MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL &&
                                   m.ProfileImage == MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userCreatedEvent = new UserCreatedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
            FirstName = MessageUnitTestConfigurations.EXISTING_SENDER_FIRST_NAME,
            LastName = MessageUnitTestConfigurations.EXISTING_SENDER_LAST_NAME,
            UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
            Email = MessageUnitTestConfigurations.EXISTING_SENDER_EMAIL,
            ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE,
        };

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
