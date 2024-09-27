using FluentAssertions;
using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Business.Features.Messages.Queries.GetMessageById;
using InstaConnect.Messages.Business.Features.Messages.Utilities;
using InstaConnect.Messages.Business.IntegrationTests.Features.Messages.Utilities;
using InstaConnect.Messages.Business.IntegrationTests.Utilities;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Business.Exceptions.User;

namespace InstaConnect.Messages.Business.IntegrationTests.Features.Messages.Queries;

public class GetMessageByIdQueryHandlerIntegrationTests : BaseMessageIntegrationTest
{
    public GetMessageByIdQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetMessageByIdQuery(
            null!,
            existingSenderId
        );

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
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetMessageByIdQuery(
            Faker.Random.AlphaNumeric(length),
            existingSenderId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetMessageByIdQuery(
            existingMessageId,
            null!
        );

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
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetMessageByIdQuery(
            existingMessageId,
            Faker.Random.AlphaNumeric(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowMessageNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetMessageByIdQuery(
            InvalidId,
            existingSenderId
        );

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
        var existingMessageSenderId = await CreateUserAsync(CancellationToken);
        var existingMessageReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingMessageSenderId, existingMessageReceiverId, CancellationToken);
        var query = new GetMessageByIdQuery(
            existingMessageId,
            existingSenderId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetMessageByIdQuery(
            existingMessageId,
            existingSenderId
        );

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageQueryViewModel>(m => m.Id == existingMessageId &&
                                          m.SenderId == existingSenderId &&
                                          m.SenderName == ValidUserName &&
                                          m.SenderProfileImage == ValidUserProfileImage &&
                                          m.ReceiverId == existingReceiverId &&
                                          m.ReceiverName == ValidUserName &&
                                          m.ReceiverProfileImage == ValidUserProfileImage &&
                                          m.Content == ValidContent);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnMessageViewModelCollection_WhenQueryIsValidAndIdCaseDoesntMatch()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var query = new GetMessageByIdQuery(
            GetNonCaseMatchingString(existingMessageId),
            existingSenderId
        );

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<MessageQueryViewModel>(m => m.Id == existingMessageId &&
                                          m.SenderId == existingSenderId &&
                                          m.SenderName == ValidUserName &&
                                          m.SenderProfileImage == ValidUserProfileImage &&
                                          m.ReceiverId == existingReceiverId &&
                                          m.ReceiverName == ValidUserName &&
                                          m.ReceiverProfileImage == ValidUserProfileImage &&
                                          m.Content == ValidContent);
    }
}
