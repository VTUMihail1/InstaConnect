using InstaConnect.Messages.Application.Features.Messages.Queries.GetById;

namespace InstaConnect.Messages.Application.UnitTests.Features.Messages.Queries.GetById;

public class GetMessageByIdQueryHandlerUnitTests : BaseMessageUnitTest
{
    private readonly GetMessageByIdQueryHandler _queryHandler;

    public GetMessageByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            InstaConnectMapper,
            MessageReadRepository);
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
                                          m.SenderName == existingMessage.Sender.UserName &&
                                          m.SenderProfileImage == existingMessage.Sender.ProfileImage &&
                                          m.ReceiverId == existingMessage.ReceiverId &&
                                          m.ReceiverName == existingMessage.Receiver.UserName &&
                                          m.ReceiverProfileImage == existingMessage.Receiver.ProfileImage);
    }
}
