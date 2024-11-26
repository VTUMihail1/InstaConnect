using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Users.Models.Entities;
using InstaConnect.Follows.Presentation.Features.Users.Consumers;
using InstaConnect.Follows.Presentation.UnitTests.Features.Users.Utilities;
using InstaConnect.Shared.Application.Contracts.Users;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Users.Consumers;

public class UserCreatedEventConsumerUnitTests : BaseUserUnitTest
{
    private readonly UserCreatedEventConsumer _userCreatedEventConsumer;
    private readonly ConsumeContext<UserCreatedEvent> _userCreatedEventConsumeContext;

    public UserCreatedEventConsumerUnitTests()
    {
        _userCreatedEventConsumer = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository);

        _userCreatedEventConsumeContext = Substitute.For<ConsumeContext<UserCreatedEvent>>();
    }

    [Fact]
    public async Task Consume_ShouldCallGetByIdAsyncMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUserId = CreateUser();
        var userCreatedEvent = new UserCreatedEvent(
            existingUserId,
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(existingUserId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldNotAddMethod_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUserId = CreateUser();
        var userCreatedEvent = new UserCreatedEvent(
            existingUserId,
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(0)
            .Add(Arg.Any<User>());
    }

    [Fact]
    public async Task Consume_ShouldNotCallSaveChangesAsync_WhenUserIdIsInvalid()
    {
        // Arrange
        var existingUserId = CreateUser();
        var userCreatedEvent = new UserCreatedEvent(
            existingUserId,
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddProfileImage);

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
        var existingUserId = CreateUser();
        var userCreatedEvent = new UserCreatedEvent(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        await UserWriteRepository
            .Received(1)
            .GetByIdAsync(UserTestUtilities.InvalidId, CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldAddUserToRepository_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingUserId = CreateUser();
        var userCreatedEvent = new UserCreatedEvent(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        UserWriteRepository
            .Received(1)
            .Add(Arg.Is<User>(m => m.Id == UserTestUtilities.InvalidId &&
                                   m.UserName == UserTestUtilities.ValidAddName &&
                                   m.FirstName == UserTestUtilities.ValidAddFirstName &&
                                   m.LastName == UserTestUtilities.ValidAddLastName &&
                                   m.Email == UserTestUtilities.ValidAddEmail &&
                                   m.ProfileImage == UserTestUtilities.ValidAddProfileImage));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var existingUserId = CreateUser();
        var userCreatedEvent = new UserCreatedEvent(
            UserTestUtilities.InvalidId,
            UserTestUtilities.ValidAddName,
            UserTestUtilities.ValidAddEmail,
            UserTestUtilities.ValidAddFirstName,
            UserTestUtilities.ValidAddLastName,
            UserTestUtilities.ValidAddProfileImage);

        _userCreatedEventConsumeContext.Message.Returns(userCreatedEvent);

        // Act
        await _userCreatedEventConsumer.Consume(_userCreatedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
