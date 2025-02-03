﻿using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;
using InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Utilities;
using InstaConnect.Messages.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Controllers.v1;

public class GetAllMessagesFunctionalTests : BaseMessageFunctionalTest
{
    public GetAllMessagesFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            null!,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenReceiverNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenMessageDoesNotContainProperty()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.InvalidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.SortPropertyMinLength - 1)]
    [InlineData(SharedConfigurations.SortPropertyMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            value,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }



    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            value
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == UserTestUtilities.ValidName &&
                                                               m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == UserTestUtilities.ValidName &&
                                                               m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndCurrentUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.SenderId),
            existingMessage.ReceiverId,
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );
        
        // Act
        var response = await MessagesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == UserTestUtilities.ValidName &&
                                                               m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == UserTestUtilities.ValidName &&
                                                               m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndReceiverIdCaseDoesNotMatch()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.ReceiverId),
            UserTestUtilities.ValidName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == UserTestUtilities.ValidName &&
                                                               m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == UserTestUtilities.ValidName &&
                                                               m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndReceiverNameCaseDoesNotMatch()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == UserTestUtilities.ValidName &&
                                                               m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == UserTestUtilities.ValidName &&
                                                               m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndReceiverNameIsNotFull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await MessagesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == UserTestUtilities.ValidName &&
                                                               m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == UserTestUtilities.ValidName &&
                                                               m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);

        // Act
        var response = await MessagesClient.GetAllAsync(existingMessage.SenderId, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessage.Id &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingMessage.SenderId &&
                                                               m.SenderName == UserTestUtilities.ValidName &&
                                                               m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.ReceiverId == existingMessage.ReceiverId &&
                                                               m.ReceiverName == UserTestUtilities.ValidName &&
                                                               m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                               mc.Page == MessageTestUtilities.ValidPageValue &&
                                                               mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }
}
