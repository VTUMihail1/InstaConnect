using System.Linq.Expressions;
using FluentAssertions;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetAllFilteredMessages;
using InstaConnect.Messages.Business.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Messages.Data.Features.Messages.Models.Filters;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Features.Messages.Queries.GetAllFilteredMessages;

public class GetAllMessagesQueryHandlerUnitTests : BaseMessageUnitTest
{
    private readonly GetAllMessagesQueryHandler _queryHandler;

    public GetAllMessagesQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            MessageReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            ValidMessageCurrentUserId,
            ValidMessageReceiverId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        Expression<Func<Message, bool>> expectedExpression = m =>
                                       (string.IsNullOrEmpty(ValidMessageCurrentUserId) || m.SenderId.Equals(ValidMessageCurrentUserId)) &&
                                       (string.IsNullOrEmpty(ValidMessageReceiverId) || m.ReceiverId.Equals(ValidMessageReceiverId)) &&
                                       (string.IsNullOrEmpty(ValidUserName) || m.Receiver!.UserName.Equals(ValidUserName));

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await MessageReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<MessageFilteredCollectionReadQuery>(m =>
                                                                        m.Expression.Compile().ToString() == expectedExpression.Compile().ToString() &&
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            ValidMessageCurrentUserId,
            ValidMessageReceiverId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == ValidId &&
                                                           m.SenderId == ValidMessageCurrentUserId &&
                                                           m.SenderName == ValidUserName &&
                                                           m.SenderProfileImage == ValidUserProfileImage &&
                                                           m.ReceiverId == ValidMessageReceiverId &&
                                                           m.ReceiverName == ValidUserName &&
                                                           m.ReceiverProfileImage == ValidUserProfileImage &&
                                                           m.Content == ValidContent) &&
                                                           mc.Page == ValidPageValue &&
                                                           mc.PageSize == ValidPageSizeValue &&
                                                           mc.TotalCount == ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
