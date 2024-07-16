using FluentAssertions;
using InstaConnect.Messages.Read.Business.Consumers.Users;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Messages.Read.Business.UnitTests.Tests.Consumers.Users;

public class UserDeletedEventConsumerUnitTests : BaseMessageUnitTest
{
    private readonly UserDeletedEventConsumer _userDeletedEventConsumer;
    private readonly ConsumeContext<UserDeletedEvent> _userDeletedEventConsumeContext;

    public UserDeletedEventConsumerUnitTests()
    {
        _userDeletedEventConsumer = new(
            UnitOfWork,
            UserRepository);

        _userDeletedEventConsumeContext = Substitute.For<ConsumeContext<UserDeletedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetUserByIdAsyncMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
        };

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UserRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.NON_EXISTING_USER_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotAddMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
        };

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        UserRepository
            .Received(0)
            .Delete(Arg.Any<User>());
    }

    [Fact]
    public async Task Consume_ShouldNotCallSaveChangesAsync_WhenUserIdIsInvalid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_USER_ID,
        };

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
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
        };

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UserRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.EXISTING_SENDER_ID, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldAddUserToRepository_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
        };

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        UserRepository
            .Received(1)
            .Delete(Arg.Is<User>(m => m.Id == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
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
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
        };

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
