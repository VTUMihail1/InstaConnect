using System.Net;
using FluentAssertions;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Read.Web.Controllers.v1;
using InstaConnect.Messages.Read.Web.Models.Requests.Messages;
using InstaConnect.Messages.Read.Web.Models.Responses;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Messages.Write.Web.UnitTests.Tests.Controllers;
public class MessageControllerUnitTests : BaseMessageUnitTest
{
    private readonly MessageController _messageController;

    public MessageControllerUnitTests()
    {
        _messageController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFilteredMessagesRequest()
        {
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = ValidSortOrderName,
            SortPropertyName = ValidSortPropertyName,
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
        };

        // Act
        var response = await _messageController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFilteredMessagesRequest()
        {
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = ValidSortOrderName,
            SortPropertyName = ValidSortPropertyName,
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
        };

        // Act
        var response = await _messageController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<ICollection<MessageViewResponse>>(mc => mc.Any(m =>
                m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                m.SenderName == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_NAME &&
                m.SenderProfileImage == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_PROFILE_IMAGE &&
                m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                m.ReceiverName == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_NAME &&
                m.ReceiverProfileImage == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_PROFILE_IMAGE &&
                m.Content == MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT
            ));
        ;
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetAllFilteredMessagesRequest()
        {
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = ValidSortOrderName,
            SortPropertyName = ValidSortPropertyName,
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
        };

        // Act
        var response = await _messageController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllFilteredMessagesQuery>(m =>
                  m.CurrentUserId == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
                  m.ReceiverId == ValidReceiverId &&
                  m.ReceiverName == ValidReceiverName &&
                  m.SortOrder == ValidSortOrderName &&
                  m.SortPropertyName == ValidSortPropertyName &&
                  m.Offset == ValidOffsetValue &&
                  m.Limit == ValidLimitValue), CancellationToken);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        var request = new GetAllFilteredMessagesRequest()
        {
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidReceiverName,
            SortOrder = ValidSortOrderName,
            SortPropertyName = ValidSortPropertyName,
            Offset = ValidOffsetValue,
            Limit = ValidLimitValue,
        };

        // Act
        await _messageController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetMessageByIdRequest()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID
        };

        // Act
        var response = await _messageController.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetMessageByIdRequest()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID
        };

        // Act
        var response = await _messageController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<MessageViewResponse>(m =>
                m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                m.SenderName == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_NAME &&
                m.SenderProfileImage == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_PROFILE_IMAGE &&
                m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                m.ReceiverName == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_NAME &&
                m.ReceiverProfileImage == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_PROFILE_IMAGE &&
                m.Content == MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT
            );
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetMessageByIdRequest()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID
        };

        // Act
        await _messageController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetMessageByIdQuery>(m =>
                  m.CurrentUserId == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
                  m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        var request = new GetMessageByIdRequest()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID
        };

        // Act
        await _messageController.GetByIdAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }
}
