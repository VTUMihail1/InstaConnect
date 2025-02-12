using FluentAssertions;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAll;
using InstaConnect.Messages.Application.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Filters;
using NSubstitute;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Queries.GetAll;

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
        var existingMessage = CreateMessage();
        var query = new GetAllMessagesQuery(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
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
                                                                        m.CurrentUserId == existingMessage.SenderId &&
                                                                        m.ReceiverId == existingMessage.ReceiverId &&
                                                                        m.ReceiverName == existingMessage.Receiver.UserName &&
                                                                        m.Page == MessageTestUtilities.ValidPageValue &&
                                                                        m.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                                        m.SortOrder == MessageTestUtilities.ValidSortOrderProperty &&
                                                                        m.SortPropertyName == MessageTestUtilities.ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var query = new GetAllMessagesQuery(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue);

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingMessage.Id &&
                                                           m.SenderId == existingMessage.SenderId &&
                                                           m.SenderName == existingMessage.Sender.UserName &&
                                                           m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                                           m.ReceiverId == existingMessage.ReceiverId &&
                                                           m.ReceiverName == existingMessage.Receiver.UserName &&
                                                           m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage &&
                                                           m.Content == existingMessage.Content) &&
                                                           mc.Page == MessageTestUtilities.ValidPageValue &&
                                                           mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
