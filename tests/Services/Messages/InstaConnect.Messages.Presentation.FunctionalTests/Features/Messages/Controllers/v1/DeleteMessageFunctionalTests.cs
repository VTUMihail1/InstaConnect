using InstaConnect.Messages.Common.Tests.Features.Messages.Utilities;

namespace InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Controllers.v1;

public class DeleteMessageFunctionalTests : BaseMessageFunctionalTest
{
    public DeleteMessageFunctionalTests(MessagesWebApplicationFactory messagesWebApplicationFactory) : base(messagesWebApplicationFactory)
    {

    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new DeleteMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        var response = await MessagesClient.DeleteStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(MessageConfigurations.IdMinLength - 1)]
    [InlineData(MessageConfigurations.IdMaxLength + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new DeleteMessageRequest(
            SharedTestUtilities.GetString(length),
            existingMessage.SenderId
        );

        // Act
        var response = await MessagesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new DeleteMessageRequest(
            existingMessage.Id,
            null
        );

        // Act
        var response = await MessagesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new DeleteMessageRequest(
            existingMessage.Id,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await MessagesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new DeleteMessageRequest(
            MessageTestUtilities.InvalidId,
            existingMessage.SenderId
        );

        // Act
        var response = await MessagesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnTheMessageIdInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new DeleteMessageRequest(
            existingMessage.Id,
            existingUser.Id
        );

        // Act
        var response = await MessagesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new DeleteMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        var response = await MessagesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteMessage_WhenRequestIsValid()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new DeleteMessageRequest(
            existingMessage.Id,
            existingMessage.SenderId
        );

        // Act
        await MessagesClient.DeleteAsync(request, CancellationToken);

        var message = await MessageWriteRepository.GetByIdAsync(existingMessage.Id, CancellationToken);

        // Assert
        message
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteMessage_WhenRequestIsValidAndIdDoesNotMatchCase()
    {
        // Arrange
        var existingMessage = await CreateMessageAsync(CancellationToken);
        var request = new DeleteMessageRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingMessage.Id),
            existingMessage.SenderId
        );

        // Act
        await MessagesClient.DeleteAsync(request, CancellationToken);

        var message = await MessageWriteRepository.GetByIdAsync(existingMessage.Id, CancellationToken);

        // Assert
        message
            .Should()
            .BeNull();
    }
}
