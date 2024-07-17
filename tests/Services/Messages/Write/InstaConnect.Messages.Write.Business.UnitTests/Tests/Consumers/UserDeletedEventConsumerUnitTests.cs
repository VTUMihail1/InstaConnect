using System.Linq.Expressions;
using InstaConnect.Messages.Write.Business.Consumers;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Messages.Write.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Users;
using MassTransit;
using NSubstitute;

namespace InstaConnect.Messages.Write.Business.UnitTests.Tests.Consumers;

public class UserDeletedEventConsumerUnitTests : BaseMessageUnitTest
{
    private readonly UserDeletedEventConsumer _userDeletedEventConsumer;
    private readonly ConsumeContext<UserDeletedEvent> _userDeletedEventConsumeContext;
    private readonly Expression<Func<Message, bool>> _expectedExpression;

    public UserDeletedEventConsumerUnitTests()
    {
        _userDeletedEventConsumer = new(
            UnitOfWork,
            MessageRepository,
            InstaConnectMapper);

        _userDeletedEventConsumeContext = Substitute.For<ConsumeContext<UserDeletedEvent>>();

        _expectedExpression = p => p.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID;

        var existingMessage = new Message()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            SenderId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID,
            Content = ValidContent,
        };

        MessageRepository.GetAllFilteredAsync(Arg.Is<MessageFilteredCollectionQuery>(m => 
                              m.Expression.Compile().ToString() == _expectedExpression.Compile().ToString()), CancellationToken)
            .Returns([existingMessage]);
    }

    [Fact]
    public async Task Consume_ShouldSearchFilteredMessages_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
        };

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await MessageRepository
            .Received(1)
            .GetAllFilteredAsync(Arg.Is<MessageFilteredCollectionQuery>(m => m.Expression.Compile().ToString() == _expectedExpression.Compile().ToString()), 
                                                                             CancellationToken);
    }

    [Fact]
    public async Task Consume_ShouldDeleteRangeOfMessages_WhenUserDeletedEventIsValid()
    {
        // Arrange
        var userDeletedEvent = new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
        };

        _userDeletedEventConsumeContext.Message.Returns(userDeletedEvent);

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        MessageRepository
              .Received(1)
              .DeleteRange(Arg.Is<ICollection<Message>>(mc =>
                                                        mc.Any(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                                                    m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                                                    m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID && 
                                                                    m.Content == ValidContent)));
    }

    [Fact]
    public async Task Consume_ShouldCallSaveChangesAsync_WhenUserDeletedEventIsValid()
    {
        // Arrange
        _userDeletedEventConsumeContext.Message.Returns(new UserDeletedEvent()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
        });

        // Act
        await _userDeletedEventConsumer.Consume(_userDeletedEventConsumeContext);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
