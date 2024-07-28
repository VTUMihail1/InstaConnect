using FluentAssertions;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Business.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Business.UnitTests.Utilities;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using NSubstitute;

namespace InstaConnect.Messages.Business.UnitTests.Tests.Queries.GetMessageById;

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
            InvalidId,
            ValidMessageCurrentUserId
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
            ValidId,
            ValidCurrentUserId
        );

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetMessageByIdQuery(
            ValidId,
            ValidMessageCurrentUserId
        );

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await MessageReadRepository
            .Received(1)
            .GetByIdAsync(ValidId, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetMessageByIdQuery(
            ValidId,
            ValidMessageCurrentUserId
        );

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageQueryViewModel>(m => m.Id == ValidId &&
                                          m.SenderId == ValidCurrentUserId &&
                                          m.SenderName == ValidUserName &&
                                          m.SenderProfileImage == ValidUserProfileImage &&
                                          m.ReceiverId == ValidReceiverId &&
                                          m.ReceiverName == ValidUserName &&
                                          m.ReceiverProfileImage == ValidUserProfileImage);
    }
}
