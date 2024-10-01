using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Messages.Web.Features.Messages.Models.Binding;
using InstaConnect.Messages.Web.Features.Messages.Models.Responses;
using InstaConnect.Messages.Web.FunctionalTests.Features.Messages.Utilities;
using InstaConnect.Messages.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Web.FunctionalTests.Features.Messages.Controllers.v1;

public class UpdateMessageFunctionalTests : BaseMessageFunctionalTest
{
    public UpdateMessageFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel(MessageTestUtilities.ValidUpdateContent);

        // Act
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingMessageId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel(MessageTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(SharedTestUtilities.GetString(length)),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel(null!);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingMessageId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel(SharedTestUtilities.GetString(length));

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingMessageId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel(MessageTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingMessageId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel(MessageTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetString(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingMessageId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var request = new UpdateMessageBindingModel(MessageTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(MessageTestUtilities.InvalidId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnTheMessageIdInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingMessageSenderId = await CreateUserAsync(CancellationToken);
        var existingMessageReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingMessageSenderId, existingMessageReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel(MessageTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingMessageId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel(MessageTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingMessageId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel(MessageTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingMessageId),
            request,
            CancellationToken);

        // Assert
        var messageViewResponse = await response
            .Content
            .ReadFromJsonAsync<MessageCommandViewResponse>();

        messageViewResponse
            .Should()
            .Match<MessageCommandViewResponse>(m => m.Id == existingMessageId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateMessage_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel(MessageTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingMessageId),
            request,
            CancellationToken);

        var message = await MessageWriteRepository.GetByIdAsync(existingMessageId, CancellationToken);

        message
            .Should()
            .Match<Message>(m => m.Id == existingMessageId &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId &&
                                 m.Content == MessageTestUtilities.ValidUpdateContent);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateMessage_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var request = new UpdateMessageBindingModel(MessageTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(SharedTestUtilities.GetNonCaseMatchingString(existingMessageId)),
            request,
            CancellationToken);

        var message = await MessageWriteRepository.GetByIdAsync(existingMessageId, CancellationToken);

        message
            .Should()
            .Match<Message>(m => m.Id == existingMessageId &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId &&
                                 m.Content == MessageTestUtilities.ValidUpdateContent);
    }
}
