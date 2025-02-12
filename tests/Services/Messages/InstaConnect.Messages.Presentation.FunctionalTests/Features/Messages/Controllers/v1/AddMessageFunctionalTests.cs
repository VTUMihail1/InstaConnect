using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Common.Features.Users.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Binding;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;
using InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Utilities;
using InstaConnect.Messages.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Controllers.v1;

public class AddMessageFunctionalTests : BaseMessageFunctionalTest
{
    public AddMessageFunctionalTests(MessagesWebApplicationFactory messagesWebApplicationFactory) : base(messagesWebApplicationFactory)
    {

    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingSender = await CreateUserAsync(CancellationToken);
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var request = new AddMessageRequest(
            existingSender.Id,
            new(existingReceiver.Id, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await MessagesClient.AddStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenReceiverIdIsNull()
    {
        // Arrange
        var existingSender = await CreateUserAsync(CancellationToken);
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var request = new AddMessageRequest(
            existingSender.Id,
            new(null, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await MessagesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingSender = await CreateUserAsync(CancellationToken);
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var request = new AddMessageRequest(
            existingSender.Id,
            new(SharedTestUtilities.GetString(length), MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await MessagesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingSender = await CreateUserAsync(CancellationToken);
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var request = new AddMessageRequest(
            existingSender.Id,
            new(existingReceiver.Id, null)
        );

        // Act
        var response = await MessagesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageConfigurations.ContentMinLength - 1)]
    [InlineData(MessageConfigurations.ContentMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingSender = await CreateUserAsync(CancellationToken);
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var request = new AddMessageRequest(
            existingSender.Id,
            new(existingReceiver.Id, SharedTestUtilities.GetString(length))
        );

        // Act
        var response = await MessagesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var existingSender = await CreateUserAsync(CancellationToken);
        var request = new AddMessageRequest(
            null,
            new(existingReceiver.Id, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await MessagesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var existingSender = await CreateUserAsync(CancellationToken);
        var request = new AddMessageRequest(
            SharedTestUtilities.GetString(length),
            new(existingReceiver.Id, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await MessagesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIsInvalid()
    {
        // Arrange
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var existingSender = await CreateUserAsync(CancellationToken);
        var request = new AddMessageRequest(
            UserTestUtilities.InvalidId,
            new(existingReceiver.Id, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await MessagesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenReceiverIsInvalid()
    {
        // Arrange
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var existingSender = await CreateUserAsync(CancellationToken);
        var request = new AddMessageRequest(
            existingSender.Id,
            new(UserTestUtilities.InvalidId, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await MessagesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingSender = await CreateUserAsync(CancellationToken);
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var request = new AddMessageRequest(
            existingSender.Id,
            new(existingReceiver.Id, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await MessagesClient.AddStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddMessage_WhenRequestIsValid()
    {
        // Arrange
        var existingSender = await CreateUserAsync(CancellationToken);
        var existingReceiver = await CreateUserAsync(CancellationToken);
        var request = new AddMessageRequest(
            existingSender.Id,
            new(existingReceiver.Id, MessageTestUtilities.ValidAddContent)
        );

        // Act
        var response = await MessagesClient.AddAsync(request, CancellationToken);
        var message = await MessageWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Message>(m => m.Id == response.Id &&
                                 m.Content == MessageTestUtilities.ValidAddContent &&
                                 m.SenderId == existingSender.Id &&
                                 m.ReceiverId == existingReceiver.Id);
    }
}
