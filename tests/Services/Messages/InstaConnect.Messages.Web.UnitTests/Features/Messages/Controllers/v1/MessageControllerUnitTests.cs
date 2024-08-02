using System.Net;
using FluentAssertions;
using InstaConnect.Messages.Business.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Business.Features.Messages.Commands.DeleteMessage;
using InstaConnect.Messages.Business.Features.Messages.Commands.UpdateMessage;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetAllFilteredMessages;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Web.Features.Messages.Controllers.v1;
using InstaConnect.Messages.Web.Features.Messages.Models.Binding;
using InstaConnect.Messages.Web.Features.Messages.Models.Requests;
using InstaConnect.Messages.Web.Features.Messages.Models.Responses;
using InstaConnect.Messages.Web.UnitTests.Utilities;
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
    public async Task GetAllFilteredAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllFilteredMessagesRequest()
        {
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidUserName,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
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
            ReceiverName = ValidUserName,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
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
            .Match<MessagePaginationCollectionQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == ValidId &&
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
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetAllFilteredMessagesRequest()
        {
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidUserName,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _messageController.GetAllFilteredAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllFilteredMessagesQuery>(m =>
                  m.CurrentUserId == ValidCurrentUserId &&
                  m.ReceiverId == ValidReceiverId &&
                  m.ReceiverName == ValidUserName &&
                  m.SortOrder == ValidSortOrderProperty &&
                  m.SortPropertyName == ValidSortPropertyName &&
                  m.Page == ValidPageValue &&
                  m.PageSize == ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        var request = new GetAllFilteredMessagesRequest()
        {
            ReceiverId = ValidReceiverId,
            ReceiverName = ValidUserName,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
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
            Id = ValidId
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
            Id = ValidId
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
            .Match<MessageQueryViewResponse>(m => m.Id == ValidId &&
                                                 m.SenderId == ValidCurrentUserId &&
                                                 m.SenderName == ValidUserName &&
                                                 m.SenderProfileImage == ValidUserProfileImage &&
                                                 m.ReceiverId == ValidReceiverId &&
                                                 m.ReceiverName == ValidUserName &&
                                                 m.ReceiverProfileImage == ValidUserProfileImage &&
                                                 m.Content == ValidContent);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        var request = new GetMessageByIdRequest()
        {
            Id = ValidId
        };

        // Act
        await _messageController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetMessageByIdQuery>(m => m.Id == ValidId &&
                                                          m.CurrentUserId == ValidCurrentUserId), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        var request = new GetMessageByIdRequest()
        {
            Id = ValidId
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
            AddMessageBindingModel = new AddMessageBindingModel(ValidReceiverId, ValidContent)
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
            AddMessageBindingModel = new AddMessageBindingModel(ValidReceiverId, ValidContent)
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
            .Match<MessageCommandViewResponse>(m => m.Id == ValidId);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var request = new AddMessageRequest()
        {
            AddMessageBindingModel = new AddMessageBindingModel(ValidReceiverId, ValidContent)
        };

        // Act
        await _messageController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddMessageCommand>(m => m.CurrentUserId == ValidCurrentUserId &&
                                                 m.ReceiverId == ValidReceiverId &&
                                                 m.Content == ValidContent),
                                                 CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenMessageIsValid()
    {
        // Arrange
        var request = new AddMessageRequest()
        {
            AddMessageBindingModel = new AddMessageBindingModel(ValidReceiverId, ValidContent)
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
            Id = ValidId,
            UpdateMessageBindingModel = new UpdateMessageBindingModel(ValidContent)
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
            Id = ValidId,
            UpdateMessageBindingModel = new UpdateMessageBindingModel(ValidContent)
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
            .Match<MessageCommandViewResponse>(m => m.Id == ValidId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var request = new UpdateMessageRequest()
        {
            Id = ValidId,
            UpdateMessageBindingModel = new UpdateMessageBindingModel(ValidContent)
        };

        // Act
        await _messageController.UpdateAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<UpdateMessageCommand>(m => m.Id == ValidId &&
                                                    m.CurrentUserId == ValidCurrentUserId &&
                                                    m.Content == ValidContent),
                                                    CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallTheCurrentUserContext_WhenMessageIsValid()
    {
        // Arrange
        var request = new UpdateMessageRequest()
        {
            Id = ValidId,
            UpdateMessageBindingModel = new UpdateMessageBindingModel(ValidContent)
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
            Id = ValidId
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
            Id = ValidId
        };

        // Act
        await _messageController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeleteMessageCommand>(m => m.Id == ValidId &&
                                                    m.CurrentUserId == ValidCurrentUserId),
                                                    CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheCurrentUserContext_WhenMessageIsValid()
    {
        // Arrange
        var request = new DeleteMessageRequest()
        {
            Id = ValidId
        };

        // Act
        await _messageController.DeleteAsync(request, CancellationToken);

        // Assert
        CurrentUserContext.Received(1);
    }
}
