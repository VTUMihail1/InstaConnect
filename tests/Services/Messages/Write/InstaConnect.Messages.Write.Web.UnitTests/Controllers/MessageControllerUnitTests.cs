using System.Net;
using FluentAssertions;
using InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Write.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Write.Business.Models;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Messages.Write.Web.Controllers.v1;
using InstaConnect.Messages.Write.Web.Models.Binding;
using InstaConnect.Messages.Write.Web.Models.Requests.Messages;
using InstaConnect.Messages.Write.Web.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Messages.Write.Web.UnitTests.Controllers;
public class MessageControllerUnitTests : BaseMessageUnitTest
{
    private readonly MessageController _messageController;

    public MessageControllerUnitTests()
    {
        _messageController = new (
            InstaConnectSender, 
            InstaConnectMapper, 
            CurrentUserContext);
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
            .Match<MessageViewResponse>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID);
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
            .Send(Arg.Is<AddMessageCommand>(m => m.CurrentUserId == MessageUnitTestConfigurations.EXISTING_SENDER_ID && 
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
            .Match<MessageViewResponse>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID);
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
            .Send(Arg.Is<UpdateMessageCommand>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
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
            .Send(Arg.Is<DeleteMessageCommand>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
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
