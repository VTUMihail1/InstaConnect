using FluentAssertions;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Business.UnitTests.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Shared.Common.Exceptions.Message;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Features.Messages.Queries.GetMessageById;

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
        var query = new GetMessageByIdQuery(
            MessageTestUtilities.InvalidId,
            MessageTestUtilities.ValidMessageCurrentUserId
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
        var query = new GetMessageByIdQuery(
            MessageTestUtilities.ValidId,
            MessageTestUtilities.ValidCurrentUserId
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
        var query = new GetMessageByIdQuery(
            MessageTestUtilities.ValidId,
            MessageTestUtilities.ValidMessageCurrentUserId
        );

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await MessageReadRepository
            .Received(1)
            .GetByIdAsync(MessageTestUtilities.ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetMessageByIdQuery(
            MessageTestUtilities.ValidId,
            MessageTestUtilities.ValidMessageCurrentUserId
        );

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageQueryViewModel>(m => m.Id == MessageTestUtilities.ValidId &&
                                          m.SenderId == MessageTestUtilities.ValidMessageCurrentUserId &&
                                          m.SenderName == MessageTestUtilities.ValidUserName &&
                                          m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                          m.ReceiverId == MessageTestUtilities.ValidMessageReceiverId &&
                                          m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                          m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage);
    }
}
