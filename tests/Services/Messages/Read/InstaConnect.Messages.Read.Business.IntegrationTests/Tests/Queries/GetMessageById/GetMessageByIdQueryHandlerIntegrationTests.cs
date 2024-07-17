using FluentAssertions;
using InstaConnect.Messages.Read.Business.Models;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetMessageById;
using InstaConnect.Messages.Read.Business.Utilities;
using InstaConnect.Messages.Write.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.Message;

namespace InstaConnect.Messages.Write.Business.UnitTests.Tests.Commands.AddMessage;

public class GetMessageByIdQueryHandlerIntegrationTests : BaseMessageIntegrationTest
{
    public GetMessageByIdQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var query = new GetMessageByIdQuery
        {
            Id = null!,
            CurrentUserId = ValidCurrentUserId,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetMessageByIdQuery
        {
            Id = Faker.Random.AlphaNumeric(length),
            CurrentUserId = ValidCurrentUserId,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var query = new GetMessageByIdQuery
        {
            Id = ValidId,
            CurrentUserId = null!,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetMessageByIdQuery
        {
            Id = ValidId,
            CurrentUserId = Faker.Random.AlphaNumeric(length),
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowMessageNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetMessageByIdQuery
        {
            Id = MessageIntegrationTestConfigurations.NON_EXISTING_MESSAGE_ID,
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_SENDER_ID,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<MessageNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowAccountForbiddenException_WhenSenderIdDoesNotOwnMessage()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetMessageByIdQuery
        {
            Id = existingMessageId,
            CurrentUserId = MessageIntegrationTestConfigurations.EXISTING_SENDER_ID,
        };

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AccountForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetMessageByIdQuery
        {
            Id = existingMessageId,
            CurrentUserId = existingSenderId,
        };

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageViewModel>(m => m.Id == existingMessageId &&
                                          m.SenderId == existingSenderId &&
                                          m.SenderName == MessageIntegrationTestConfigurations.EXISTING_SENDER_NAME &&
                                          m.SenderProfileImage == MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE &&
                                          m.ReceiverId == existingReceiverId &&
                                          m.ReceiverName == MessageIntegrationTestConfigurations.EXISTING_SENDER_NAME &&
                                          m.ReceiverProfileImage == MessageIntegrationTestConfigurations.EXISTING_SENDER_PROFILE_IMAGE &&
                                          m.Content == MessageIntegrationTestConfigurations.EXISTING_MESSAGE_CONTENT);
    }
}
