using FluentAssertions;
using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Application.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Application.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Message;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Queries.GetMessageById;

public class GetMessageByIdQueryHandlerUnitTests : BaseMessageUnitTest
{
    private readonly GetMessageByIdQueryHandler _queryHandler;

    public GetMessageByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            MessageReadRepository,
            InstaConnectMapper);
    }

    [Fact]
    public async Task Handle_ShouldThrowMessageNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var query = new GetMessageByIdQuery(
            MessageTestUtilities.InvalidId,
            existingMessage.SenderId
        );

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<MessageNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenCurrentUserIdDoesNotOwnTheMessage()
    {
        // Arrange
        var existingUser = CreateUser();
        var existingMessage = CreateMessage();
        var query = new GetMessageByIdQuery(
            existingMessage.Id,
            existingUser.Id
        );

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var query = new GetMessageByIdQuery(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await MessageReadRepository
            .Received(1)
            .GetByIdAsync(existingMessage.Id, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingMessage = CreateMessage();
        var query = new GetMessageByIdQuery(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageQueryViewModel>(m => m.Id == existingMessage.Id &&
                                          m.SenderId == existingMessage.SenderId &&
                                          m.SenderName == UserTestUtilities.ValidName &&
                                          m.SenderProfileImage == UserTestUtilities.ValidProfileImage &&
                                          m.ReceiverId == existingMessage.ReceiverId &&
                                          m.ReceiverName == UserTestUtilities.ValidName &&
                                          m.ReceiverProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
