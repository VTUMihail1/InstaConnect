using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Binding;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Responses;
using InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Utilities;
using InstaConnect.Messages.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Controllers.v1;

public class AddMessageFunctionalTests : BaseMessageFunctionalTest
{
    public AddMessageFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel(existingReceiverId, MessageTestUtilities.ValidAddContent);

        // Act
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenReceiverIdIsNull()
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel(null!, MessageTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel(SharedTestUtilities.GetString(length), MessageTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel(existingReceiverId, null!);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel(existingReceiverId, SharedTestUtilities.GetString(length));

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel(existingReceiverId, MessageTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel(existingReceiverId, MessageTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetString(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIsInvalid()
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel(existingReceiverId, MessageTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = MessageTestUtilities.InvalidUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenReceiverIsInvalid()
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel(MessageTestUtilities.InvalidUserId, MessageTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel(existingReceiverId, MessageTestUtilities.ValidAddContent);


        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddMessage_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel(existingReceiverId, MessageTestUtilities.ValidAddContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        var messageViewResponse = await response
            .Content
            .ReadFromJsonAsync<MessageCommandViewResponse>();

        var message = await MessageWriteRepository.GetByIdAsync(messageViewResponse!.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Message>(m => m.Id == messageViewResponse.Id &&
                                 m.Content == MessageTestUtilities.ValidAddContent &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId);
    }
}
