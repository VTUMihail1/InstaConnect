﻿using System.Net;
using FluentAssertions;
using InstaConnect.Messages.Application.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Application.Features.Messages.Commands.DeleteMessage;
using InstaConnect.Messages.Application.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Presentation.Features.Messages.Controllers.v1;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Binding;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;
using InstaConnect.Messages.Presentation.UnitTests.Features.Messages.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Messages.Presentation.UnitTests.Features.Messages.Controllers.v1;

public class GetAllMessageUnitTests : BaseMessageUnitTest
{
    private readonly MessageController _messageController;

    public GetAllMessageUnitTests()
    {
        _messageController = new(
            InstaConnectSender,
            InstaConnectMapper);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _messageController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _messageController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<MessagePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == existingMessage.Id &&
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
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new GetAllMessagesRequest(
            existingMessage.SenderId,
            existingMessage.ReceiverId,
            existingMessage.Receiver.UserName,
            MessageTestUtilities.ValidSortOrderProperty,
            MessageTestUtilities.ValidSortPropertyName,
            MessageTestUtilities.ValidPageValue,
            MessageTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _messageController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllMessagesQuery>(m =>
                  m.CurrentUserId == existingMessage.SenderId &&
                  m.ReceiverId == existingMessage.ReceiverId &&
                  m.ReceiverName == existingMessage.Receiver.UserName &&
                  m.SortOrder == MessageTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == MessageTestUtilities.ValidSortPropertyName &&
                  m.Page == MessageTestUtilities.ValidPageValue &&
                  m.PageSize == MessageTestUtilities.ValidPageSizeValue), CancellationToken);
    }
}
