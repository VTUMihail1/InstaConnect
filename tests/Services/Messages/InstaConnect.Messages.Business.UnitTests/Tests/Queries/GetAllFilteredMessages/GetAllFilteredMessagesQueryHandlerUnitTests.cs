﻿using System.Linq.Expressions;
using FluentAssertions;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.UnitTests.Utilities;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Messages.Data.Models.Filters;
using InstaConnect.Shared.Data.Models.Pagination;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Tests.Queries.GetAllFilteredMessages;

public class GetAllFilteredMessagesQueryHandlerUnitTests : BaseMessageUnitTest
{
    private readonly GetAllFilteredMessagesQueryHandler _queryHandler;

    public GetAllFilteredMessagesQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            MessageReadRepository);
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetAllMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery(
            ValidCurrentUserId,
            ValidReceiverId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await MessageReadRepository
            .Received(1)
            .GetAllFilteredAsync(Arg.Is<MessageFilteredCollectionReadQuery>(m =>
                                                                        m.Page == ValidPageValue &&
                                                                        m.PageSize == ValidPageSizeValue &&
                                                                        m.SortOrder == ValidSortOrderProperty &&
                                                                        m.SortPropertyName == ValidSortPropertyName), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetAllFilteredMessagesQuery(
            ValidCurrentUserId,
            ValidReceiverId,
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
            .Match<MessagePaginationCollectionModel>(mc => mc.Items.Any(m => m.Id == ValidId &&
                                                           m.SenderId == ValidCurrentUserId &&
                                                           m.SenderName == ValidUserName &&
                                                           m.SenderProfileImage == ValidUserProfileImage &&
                                                           m.ReceiverId == ValidReceiverId &&
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
