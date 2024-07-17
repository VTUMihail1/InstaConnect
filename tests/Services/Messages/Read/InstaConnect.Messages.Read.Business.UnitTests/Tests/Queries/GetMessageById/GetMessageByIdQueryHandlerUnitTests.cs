using FluentAssertions;
using InstaConnect.Messages.Read.Business.Models;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Read.Data.Models.Filters;
using InstaConnect.Messages.Write.Business.UnitTests.Utilities;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Messages.Write.Business.UnitTests.Tests.Commands.AddMessage;

public class GetMessageByIdQueryHandlerUnitTests : BaseMessageUnitTest
{
    private readonly GetMessageByIdQueryHandler _queryHandler;

    public GetMessageByIdQueryHandlerUnitTests()
    {
        _queryHandler = new(
            MessageRepository,
            InstaConnectMapper);
    }

    [Fact]
    public async Task Handle_ShouldThrowMessageNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetMessageByIdQuery()
        {
            Id = MessageUnitTestConfigurations.NON_EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
        };

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<MessageNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowAccountForbiddenException_WhenCurrentUserIdDoesNotOwnTheMessage()
    {
        // Arrange
        var query = new GetMessageByIdQuery()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_SENDER_ID,
        };

        // Act
        var action = async () => await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task Handle_ShouldCallRepositoryWithGetByIdMethod_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetMessageByIdQuery()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
        };

        // Act
        await _queryHandler.Handle(query, CancellationToken);

        // Assert
        await MessageRepository
            .Received(1)
            .GetByIdAsync(MessageUnitTestConfigurations.EXISTING_MESSAGE_ID, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var query = new GetMessageByIdQuery()
        {
            Id = MessageUnitTestConfigurations.EXISTING_MESSAGE_ID,
            CurrentUserId = MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID,
        };

        // Act
        var response = await _queryHandler.Handle(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageViewModel>(m => m.Id == MessageUnitTestConfigurations.EXISTING_MESSAGE_ID &&
                                          m.SenderId == MessageUnitTestConfigurations.EXISTING_MESSAGE_SENDER_ID &&
                                                           m.SenderName == MessageUnitTestConfigurations.EXISTING_SENDER_NAME &&
                                                           m.SenderProfileImage == MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE &&
                                                           m.ReceiverId == MessageUnitTestConfigurations.EXISTING_MESSAGE_RECEIVER_ID &&
                                                           m.ReceiverName == MessageUnitTestConfigurations.EXISTING_RECEIVER_NAME &&
                                                           m.ReceiverProfileImage == MessageUnitTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE);
    }
}
