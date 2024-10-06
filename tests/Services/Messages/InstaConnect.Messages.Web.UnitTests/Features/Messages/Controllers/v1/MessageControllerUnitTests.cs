using System.Net;
using FluentAssertions;
using InstaConnect.Messages.Business.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Business.Features.Messages.Commands.DeleteMessage;
using InstaConnect.Messages.Business.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetAllMessages;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Web.Features.Messages.Controllers.v1;
using InstaConnect.Messages.Web.Features.Messages.Models.Binding;
using InstaConnect.Messages.Web.Features.Messages.Models.Requests;
using InstaConnect.Messages.Web.Features.Messages.Models.Responses;
using InstaConnect.Messages.Web.UnitTests.Features.Messages.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Messages.Web.UnitTests.Features.Messages.Controllers.v1;
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
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllMessagesRequest()
        {
            ReceiverId = MessageTestUtilities.ValidReceiverId,
            ReceiverName = MessageTestUtilities.ValidUserName,
            SortOrder = MessageTestUtilities.ValidSortOrderProperty,
            SortPropertyName = MessageTestUtilities.ValidSortPropertyName,
            Page = MessageTestUtilities.ValidPageValue,
            PageSize = MessageTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _messageController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllMessagesRequest()
        {
            ReceiverId = MessageTestUtilities.ValidReceiverId,
            ReceiverName = MessageTestUtilities.ValidUserName,
            SortOrder = MessageTestUtilities.ValidSortOrderProperty,
            SortPropertyName = MessageTestUtilities.ValidSortPropertyName,
            Page = MessageTestUtilities.ValidPageValue,
            PageSize = MessageTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _messageController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<MessagePaginationCollectionQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == MessageTestUtilities.ValidId &&
                                                                 m.SenderId == MessageTestUtilities.ValidCurrentUserId &&
                                                                 m.SenderName == MessageTestUtilities.ValidUserName &&
                                                                 m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                 m.ReceiverId == MessageTestUtilities.ValidReceiverId &&
                                                                 m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                                 m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                                 m.Content == MessageTestUtilities.ValidContent) &&
                                                              mc.Page == MessageTestUtilities.ValidPageValue &&
                                                              mc.PageSize == MessageTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == MessageTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetAllMessagesRequest()
        {
            ReceiverId = MessageTestUtilities.ValidReceiverId,
            ReceiverName = MessageTestUtilities.ValidUserName,
            SortOrder = MessageTestUtilities.ValidSortOrderProperty,
            SortPropertyName = MessageTestUtilities.ValidSortPropertyName,
            Page = MessageTestUtilities.ValidPageValue,
            PageSize = MessageTestUtilities.ValidPageSizeValue,
        };

        // Act
        var response = await _messageController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllMessagesQuery>(m =>
                  m.CurrentUserId == MessageTestUtilities.ValidCurrentUserId &&
                  m.ReceiverId == MessageTestUtilities.ValidReceiverId &&
                  m.ReceiverName == MessageTestUtilities.ValidUserName &&
                  m.SortOrder == MessageTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == MessageTestUtilities.ValidSortPropertyName &&
                  m.Page == MessageTestUtilities.ValidPageValue &&
                  m.PageSize == MessageTestUtilities.ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        var request = new GetAllMessagesRequest()
        {
            ReceiverId = MessageTestUtilities.ValidReceiverId,
            ReceiverName = MessageTestUtilities.ValidUserName,
            SortOrder = MessageTestUtilities.ValidSortOrderProperty,
            SortPropertyName = MessageTestUtilities.ValidSortPropertyName,
            Page = MessageTestUtilities.ValidPageValue,
            PageSize = MessageTestUtilities.ValidPageSizeValue,
        };

        // Act
        await _messageController.GetAllAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetMessageByIdRequest()
        {
            Id = MessageTestUtilities.ValidId
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
            Id = MessageTestUtilities.ValidId
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
            .Match<MessageQueryViewResponse>(m => m.Id == MessageTestUtilities.ValidId &&
                                                 m.SenderId == MessageTestUtilities.ValidCurrentUserId &&
                                                 m.SenderName == MessageTestUtilities.ValidUserName &&
                                                 m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                 m.ReceiverId == MessageTestUtilities.ValidReceiverId &&
                                                 m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                 m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                 m.Content == MessageTestUtilities.ValidContent);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetMessageByIdRequest()
        {
            Id = MessageTestUtilities.ValidId
        };

        // Act
        await _messageController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetMessageByIdQuery>(m => m.Id == MessageTestUtilities.ValidId &&
                                                          m.CurrentUserId == MessageTestUtilities.ValidCurrentUserId), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        var request = new GetMessageByIdRequest()
        {
            Id = MessageTestUtilities.ValidId
        };

        // Act
        await _messageController.GetByIdAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenMessageIsValid()
    {
        // Arrange
        var request = new AddMessageRequest()
        {
            AddMessageBindingModel = new AddMessageBindingModel(MessageTestUtilities.ValidReceiverId, MessageTestUtilities.ValidContent)
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
            AddMessageBindingModel = new AddMessageBindingModel(MessageTestUtilities.ValidReceiverId, MessageTestUtilities.ValidContent)
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
            .Match<MessageCommandViewResponse>(m => m.Id == MessageTestUtilities.ValidId);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var request = new AddMessageRequest()
        {
            AddMessageBindingModel = new AddMessageBindingModel(MessageTestUtilities.ValidReceiverId, MessageTestUtilities.ValidContent)
        };

        // Act
        await _messageController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddMessageCommand>(m => m.CurrentUserId == MessageTestUtilities.ValidCurrentUserId &&
                                                 m.ReceiverId == MessageTestUtilities.ValidReceiverId &&
                                                 m.Content == MessageTestUtilities.ValidContent),
                                                 CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenMessageIsValid()
    {
        // Arrange
        var request = new AddMessageRequest()
        {
            AddMessageBindingModel = new AddMessageBindingModel(MessageTestUtilities.ValidReceiverId, MessageTestUtilities.ValidContent)
        };

        // Act
        await _messageController.AddAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnOkStatusCode_WhenMessageIsValid()
    {
        // Arrange
        var request = new UpdateMessageRequest()
        {
            Id = MessageTestUtilities.ValidId,
            UpdateMessageBindingModel = new UpdateMessageBindingModel(MessageTestUtilities.ValidContent)
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
            Id = MessageTestUtilities.ValidId,
            UpdateMessageBindingModel = new UpdateMessageBindingModel(MessageTestUtilities.ValidContent)
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
            .Match<MessageCommandViewResponse>(m => m.Id == MessageTestUtilities.ValidId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var request = new UpdateMessageRequest()
        {
            Id = MessageTestUtilities.ValidId,
            UpdateMessageBindingModel = new UpdateMessageBindingModel(MessageTestUtilities.ValidContent)
        };

        // Act
        await _messageController.UpdateAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<UpdateMessageCommand>(m => m.Id == MessageTestUtilities.ValidId &&
                                                    m.CurrentUserId == MessageTestUtilities.ValidCurrentUserId &&
                                                    m.Content == MessageTestUtilities.ValidContent),
                                                    CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheCurrentUserContext_WhenMessageIsValid()
    {
        // Arrange
        var request = new UpdateMessageRequest()
        {
            Id = MessageTestUtilities.ValidId,
            UpdateMessageBindingModel = new UpdateMessageBindingModel(MessageTestUtilities.ValidContent)
        };

        // Act
        await _messageController.UpdateAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenMessageIsValid()
    {
        // Arrange
        var request = new DeleteMessageRequest()
        {
            Id = MessageTestUtilities.ValidId
        };

        // Act
        var response = await _messageController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.NoContent));
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var request = new DeleteMessageRequest()
        {
            Id = MessageTestUtilities.ValidId
        };

        // Act
        await _messageController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeleteMessageCommand>(m => m.Id == MessageTestUtilities.ValidId &&
                                                    m.CurrentUserId == MessageTestUtilities.ValidCurrentUserId),
                                                    CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheCurrentUserContext_WhenMessageIsValid()
    {
        // Arrange
        var request = new DeleteMessageRequest()
        {
            Id = MessageTestUtilities.ValidId
        };

        // Act
        await _messageController.DeleteAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }
}
