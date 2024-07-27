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
            MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
            MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
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
            MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            MessageUnitTestConfigurations.EXISTING_SENDER_ID
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
            MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        );

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await MessageReadRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.EXISTING_MESSAGE_ID, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetMessageByIdQuery(
            MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID
        );

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageQueryViewModel>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                          m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                          m.SenderName == MessageUnitTestConfigurations.EXISTING_SENDER_NAME &&
                                          m.SenderProfileImage == MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE &&
                                          m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                          m.ReceiverName == MessageUnitTestConfigurations.EXISTING_RECEIVER_NAME &&
                                          m.ReceiverProfileImage == MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE);
    }
}
