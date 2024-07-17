using System.Linq.Expressions;
using FluentAssertions;
using InstaConnect.Messages.Read.Business.Models;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Business.Utilities;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Messages.Read.Data.Models.Filters;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Models.Pagination;
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
            Sender = new User()
            {
                Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
                UserName = MessageUnitTestConfigurations.EXISTING_SENDER_NAME,
                ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE
            },
            Receiver = new User()
            {
                Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID,
                UserName = MessageUnitTestConfigurations.EXISTING_RECEIVER_NAME,
                ProfileImage = MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE
            },
        };

        MessageRepository
            .GetAllFilteredAsync(Arg.Is<MessageFilteredCollectionQuery>(m =>
                                                                        m.Expression.Compile().ToString() == _expectedExpression.Compile().ToString() &&
                                                                        m.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                                        m.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                                        m.SortOrder == MessageUnitTestConfigurations.SORT_ORDER_VALUE &&
                                                                        m.SortPropertyName == MessageUnitTestConfigurations.SORT_PROPERTY_ORDER_VALUE), CancellationToken)
            .Returns(new PaginationList<Message>()
            {
                Items = [existingMessage],
                Page = MessageBusinessConfigurations.PAGE_MIN_VALUE,
                PageSize = MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE,
                TotalCount = MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE,
            });
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
            Page = MessageBusinessConfigurations.PAGE_MIN_VALUE,
            PageSize = MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE,
        };

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await MessageRepository
            .Received(1)
            .GetAllFilteredAsync(Arg.Is<MessageFilteredCollectionQuery>(m =>
                                                                        m.Expression.Compile().ToString() == _expectedExpression.Compile().ToString() &&
                                                                        m.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                                        m.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
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
            Page = MessageBusinessConfigurations.PAGE_MIN_VALUE,
            PageSize = MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE,
        };

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationCollectionModel>(mc => mc.Items.Any(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                                           m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                                           m.SenderName == MessageUnitTestConfigurations.EXISTING_SENDER_NAME &&
                                                           m.SenderProfileImage == MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE &&
                                                           m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                                           m.ReceiverName == MessageUnitTestConfigurations.EXISTING_RECEIVER_NAME &&
                                                           m.ReceiverProfileImage == MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE &&
                                                           m.Content == MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT) &&
                                                           mc.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                           mc.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                           mc.TotalCount == MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
