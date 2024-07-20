using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Messages.Web.FunctionalTests.Utilities;
using InstaConnect.Messages.Web.Models.Binding;
using InstaConnect.Messages.Web.Models.Responses;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Tests.Commands;

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
        var request = new AddMessageBindingModel
        {
            ReceiverId = existingReceiverId,
            Content = ValidAddContent
        };

        // Act
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenReceiverIdIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel()
        {
            ReceiverId = null!,
            Content = ValidAddContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

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
        var request = new AddMessageBindingModel()
        {
            ReceiverId = Faker.Random.AlphaNumeric(length),
            Content = ValidAddContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel()
        {
            ReceiverId = ValidReceiverId,
            Content = null!
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

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
        var request = new AddMessageBindingModel()
        {
            ReceiverId = existingReceiverId,
            Content = Faker.Random.AlphaNumeric(length)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel()
        {
            ReceiverId = existingReceiverId,
            Content = ValidAddContent,
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

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
        var request = new AddMessageBindingModel()
        {
            ReceiverId = existingReceiverId,
            Content = ValidAddContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = Faker.Random.AlphaNumeric(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIsInvalid()
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel()
        {
            ReceiverId = existingReceiverId,
            Content = ValidAddContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = MessageFunctionalTestConfigurations.NON_EXISTING_USER_ID;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenReceiverIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel()
        {
            ReceiverId = MessageFunctionalTestConfigurations.NON_EXISTING_USER_ID,
            Content = ValidAddContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel
        {
            ReceiverId = existingReceiverId,
            Content = ValidAddContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddMessage_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var request = new AddMessageBindingModel
        {
            ReceiverId = existingReceiverId,
            Content = ValidAddContent
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE, request, CancellationToken);

        var messageViewResponse = await response
            .Content
            .ReadFromJsonAsync<MessageWriteViewResponse>();

        var message = await MessageWriteRepository.GetByIdAsync(messageViewResponse!.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Message>(m => m.Id == messageViewResponse.Id &&
                                 m.Content == ValidAddContent &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId);
    }
}
