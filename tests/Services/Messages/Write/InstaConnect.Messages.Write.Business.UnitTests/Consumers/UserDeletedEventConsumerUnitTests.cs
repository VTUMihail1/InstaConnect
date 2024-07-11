using InstaConnect.Messages.Write.Business.Consumers;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Messages.Write.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Users;
using NSubstitute;

namespace InstaConnect.Messages.Write.Business.UnitTests.Consumers;

public class UserDeletedEventConsumerUnitTests : BaseMessageUnitTest
{
    private readonly UserDeletedEventConsumer _userDeletedEventConsumer;

    public UserDeletedEventConsumerUnitTests()
    {
        _userDeletedEventConsumer = new(
            UnitOfWork,
            MessageRepository,
            InstaConnectMapper);
    }

    [Fact]
    public async Task Consume_Should_When()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
        };

        UserDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(UserDeletedEventConsumeContext);

        // Assert
        await MessageRepository
            .Received(1)
            .GetAllFilteredAsync(Arg.Is<MessageFilteredCollectionQuery>(m =>
                                                                        m.Expression.Compile().ToString() == ExpectedUserDeletedEventExpression.Compile().ToString() &&
                                                                        m.Limit == MessageUnitTestConfigurations.LIMIT_VALUE &&
                                                                        m.Offset == MessageUnitTestConfigurations.OFFSER_VALUE &&
                                                                        m.SortOrder == MessageUnitTestConfigurations.SORT_ORDER_VALUE &&
                                                                        m.SortPropertyName == MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE),
                                 CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldDeleteRangeOfMessages_WhenUserDeletedEventIsValid()
    {
        // Arrange

        var existingMessage = new Message
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            SenderId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        var messages = new List<Message> { existingMessage };

        UserDeletedEventConsumeContext.Message.Returns(new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
        });

        MessageRepository.GetAllFilteredAsync(Arg.Is<MessageFilteredCollectionQuery>(m =>
                                                                        m.Expression.Compile().ToString() == ExpectedUserDeletedEventExpression.Compile().ToString() &&
                                                                        m.Limit == MessageUnitTestConfigurations.LIMIT_VALUE &&
                                                                        m.Offset == MessageUnitTestConfigurations.OFFSER_VALUE &&
                                                                        m.SortOrder == MessageUnitTestConfigurations.SORT_ORDER_VALUE &&
                                                                        m.SortPropertyName == MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE),
                                                                        CancellationToken)
                          .Returns(messages);

        // Act
        await _userDeletedEventConsumer.Consume(UserDeletedEventConsumeContext);

        // Assert
        MessageRepository
            .Received(1)
            .DeleteRange(messages);
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        UserDeletedEventConsumeContext.Message.Returns(new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
        });

        // Act
        await _userDeletedEventConsumer.Consume(UserDeletedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
