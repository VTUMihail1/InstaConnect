using System.Net;
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

public class AddMessageUnitTests : BaseMessageUnitTest
{
    private readonly MessageController _messageController;

    public AddMessageUnitTests()
    {
        _messageController = new(
            InstaConnectSender,
            InstaConnectMapper);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new AddMessageRequest(
            existingMessage.SenderId,
            new(existingMessage.ReceiverId, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await _messageController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnMessageViewModel_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new AddMessageRequest(
            existingMessage.SenderId,
            new(existingMessage.ReceiverId, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await _messageController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<MessageCommandResponse>(m => m.Id == existingMessage.Id);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenMessageIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var request = new AddMessageRequest(
            existingMessage.SenderId,
            new(existingMessage.ReceiverId, MessageTestUtilities.ValidAddContent)
        );

        // Act
        await _messageController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddMessageCommand>(m => m.CurrentUserId == existingMessage.SenderId &&
                                                 m.ReceiverId == existingMessage.ReceiverId &&
                                                 m.Content == MessageTestUtilities.ValidAddContent),
                                                 CancellationToken);
    }
}
