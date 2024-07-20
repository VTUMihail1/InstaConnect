using System.Drawing.Printing;
using System.Net;
using FluentAssertions;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Web.Controllers.v1;
using InstaConnect.Messages.Web.Models.Binding;
using InstaConnect.Messages.Web.Models.Requests.Messages;
using InstaConnect.Messages.Web.Models.Responses;
using InstaConnect.Messages.Web.UnitTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Messages.Web.UnitTests.Tests.Controllers;
public class MessageControllerUnitTests : BaseMessageUnitTest
{
    private readonly MessageController _messageController;

    public MessageControllerUnitTests()
    {
        _messageController = new(
            InstaConnectSender,
            InstaConnectMapper,
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
            Page = ValidOffsetValue,
            PageSize = ValidLimitValue,
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
            Page = ValidOffsetValue,
            PageSize = ValidLimitValue,
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
            .Match<MessagePaginationCollectionResponse>(mc => mc.Items.Any(m =>
                                                                 m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                                                 m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                                                 m.SenderName == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_NAME &&
                                                                 m.SenderProfileImage == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_PROFILE_IMAGE &&
                                                                 m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                                                 m.ReceiverName == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_NAME &&
                                                                 m.ReceiverProfileImage == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_PROFILE_IMAGE &&
                                                                 m.Content == MessageUnitTestConfigurations.EXISTING_MESSAGE_CONTENT) &&
                                                              mc.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                              mc.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                              mc.TotalCount == MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
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
            Page = ValidOffsetValue,
            PageSize = ValidLimitValue,
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
                  m.Page == ValidOffsetValue &&
                  m.PageSize == ValidLimitValue), CancellationToken);
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
            Page = ValidOffsetValue,
            PageSize = ValidLimitValue,
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
            .Match<MessageReadViewResponse>(m =>
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

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenMessageIsValid()
    {
        // Arrange
        var request = new AddMessageRequest()
        {
            AddMessageBindingModel = new AddMessageBindingModel
            {
                ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
                Content = AddContent,
            }
        };

        // Act
        var response = await _messageController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task AddAsync_ShouldReturnMessageViewModel_WhenMessageIsValid()
    {
        // Arrange
        var request = new AddMessageRequest()
        {
            AddMessageBindingModel = new AddMessageBindingModel
            {
                ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
                Content = AddContent,
            }
        };

        // Act
        var response = await _messageController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<MessageWriteViewResponse>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var request = new AddMessageRequest()
        {
            AddMessageBindingModel = new AddMessageBindingModel
            {
                ReceiverId = MessageUnitTestConfigurations.EXISTING_RECEIVER_ID,
                Content = AddContent,
            }
        };

        // Act
        await _messageController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddMessageCommand>(m => m.CurrentUserId == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
                                                 m.ReceiverId == MessageUnitTestConfigurations.EXISTING_RECEIVER_ID &&
                                                 m.Content == AddContent),
                                                 CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenMessageIsValid()
    {
        // Arrange
        var request = new AddMessageRequest()
        {
            AddMessageBindingModel = new AddMessageBindingModel
            {
                ReceiverId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
                Content = AddContent,
            }
        };

        // Act
        await _messageController.AddAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnOkStatusCode_WhenMessageIsValid()
    {
        // Arrange
        var request = new UpdateMessageRequest()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            UpdateMessageBindingModel = new UpdateMessageBindingModel
            {
                Content = UpdateContent,
            }
        };

        // Act
        var response = await _messageController.UpdateAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnMessageViewModel_WhenMessageIsValid()
    {
        // Arrange
        var request = new UpdateMessageRequest()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            UpdateMessageBindingModel = new UpdateMessageBindingModel
            {
                Content = UpdateContent,
            }
        };

        // Act
        var response = await _messageController.UpdateAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<MessageWriteViewResponse>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var request = new UpdateMessageRequest()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            UpdateMessageBindingModel = new UpdateMessageBindingModel
            {
                Content = UpdateContent,
            }
        };

        // Act
        await _messageController.UpdateAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<UpdateMessageCommand>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                                    m.CurrentUserId == MessageUnitTestConfigurations.EXISTING_SENDER_ID &&
                                                    m.Content == UpdateContent),
                                                    CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheCurrentUserContext_WhenMessageIsValid()
    {
        // Arrange
        var request = new UpdateMessageRequest()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            UpdateMessageBindingModel = new UpdateMessageBindingModel
            {
                Content = UpdateContent,
            }
        };

        // Act
        await _messageController.UpdateAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenMessageIsValid()
    {
        // Arrange
        var request = new DeleteMessageRequest()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID
        };

        // Act
        var response = await _messageController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var request = new DeleteMessageRequest()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID
        };

        // Act
        await _messageController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeleteMessageCommand>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                                    m.CurrentUserId == MessageUnitTestConfigurations.EXISTING_SENDER_ID),
                                                    CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheCurrentUserContext_WhenMessageIsValid()
    {
        // Arrange
        var request = new DeleteMessageRequest()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID
        };

        // Act
        await _messageController.DeleteAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }
}
