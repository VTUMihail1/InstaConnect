using System.Linq.Expressions;
using FluentAssertions;
using InstaConnect.Messages.Read.Business.Models;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Read.Data.Models.Filters;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Messages.Write.Business.UnitTests.Tests.Commands.AddMessage;

public class GetAllFilteredMessagesQueryHandlerUnitTests : BaseMessageUnitTest
{
    private readonly GetAllFilteredMessagesQueryHandler _queryHandler;
    private readonly Expression<Func<Message, bool>> _expectedExpression;

    public GetAllFilteredMessagesQueryHandlerUnitTests()
    {
        _queryHandler = new(
            MessageRepository,
            InstaConnectMapper);

        _expectedExpression = p => p.Id == MessageUnitTestConfigurations.EXISTING_SENDER_ID;

        var existingMessage = new Message()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            SenderId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID,
            Content = MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT,
        };

        MessageRepository
            .GetAllFilteredAsync(Arg.Is<MessageFilteredCollectionQuery>(m =>
                                                                        m.Expression.Compile().ToString() == _expectedExpression.Compile().ToString() &&
                                                                        m.Limit == ValidLimitValue &&
                                                                        m.Offset == ValidOffsetValue &&
                                                                        m.SortOrder == MessageUnitTestConfigurations.SORT_ORDER_VALUE &&
                                                                        m.SortPropertyName == MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE), CancellationToken)
            .Returns([existingMessage]);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery()
        {
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Limit = ValidLimitValue,
            Offset = ValidOffsetValue,
        };

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await MessageRepository
            .Received(1)
            .GetAllFilteredAsync(Arg.Is<MessageFilteredCollectionQuery>(m =>
                                                                        m.Expression.Compile().ToString() == _expectedExpression.Compile().ToString() &&
                                                                        m.Limit == ValidLimitValue &&
                                                                        m.Offset == ValidOffsetValue &&
                                                                        m.SortOrder == MessageUnitTestConfigurations.SORT_ORDER_VALUE &&
                                                                        m.SortPropertyName == MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery()
        {
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
            ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
            ReceiverName = ValidReceiverName,
            SortOrder = MessageUnitTestConfigurations.SORT_ORDER_NAME,
            SortPropertyName = MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            Limit = ValidLimitValue,
            Offset = ValidOffsetValue,
        };

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<ICollection<MessageViewModel>>(mc => mc.Any(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                                           m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                                           m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                                           m.Content == MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT));
    }
}
