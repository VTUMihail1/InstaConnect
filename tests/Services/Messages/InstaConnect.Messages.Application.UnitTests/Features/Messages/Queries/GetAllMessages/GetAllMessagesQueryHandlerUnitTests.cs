using FluentAssertions;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Business.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Data.Features.Messages.Models.Filters;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Features.Messages.Queries.GetAllMessages;

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
            MessageTestUtilities.ValidMessageCurrentUserId,
            MessageTestUtilities.ValidMessageReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await MessageReadRepository
            .Received(1)
            .GetAllAsync(Arg.Is<MessageCollectionReadQuery>(m =>
                                                                        m.CurrentUserId == MessageTestUtilities.ValidMessageCurrentUserId &&
                                                                        m.ReceiverId == MessageTestUtilities.ValidMessageReceiverId &&
                                                                        m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                        m.Page == MessageTestUtilities.ValidPageValue &&
                                                                        m.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == MessageTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == MessageTestUtilities.ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllMessagesQuery(
            MessageTestUtilities.ValidMessageCurrentUserId,
            MessageTestUtilities.ValidMessageReceiverId,
            MessageTestUtilities.ValidUserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == MessageTestUtilities.ValidId &&
                                                           m.SenderId == MessageTestUtilities.ValidMessageCurrentUserId &&
                                                           m.SenderName == MessageTestUtilities.ValidUserName &&
                                                           m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                           m.ReceiverId == MessageTestUtilities.ValidMessageReceiverId &&
                                                           m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                           m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                           m.Content == MessageTestUtilities.ValidContent) &&
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
