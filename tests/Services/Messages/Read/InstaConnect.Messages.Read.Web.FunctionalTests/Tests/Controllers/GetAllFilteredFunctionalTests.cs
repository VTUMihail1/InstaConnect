using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Read.Business.Utilities;
using InstaConnect.Messages.Read.Web.Models.Responses;
using InstaConnect.Messages.Write.Web.FunctionalTests.Utilities;
using MassTransit.Testing;

namespace InstaConnect.Messages.Write.Web.FunctionalTests.Tests.Commands;

public class GetAllFilteredFunctionalTests : BaseMessageFunctionalTest
{
    private static readonly string RouteTemplate = $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/filtered?" +
        "receiverId={0}&" +
        "receiverName={1}&" +
        "sortOrder={2}&" +
        "sortPropertyName={3}&" +
        "offset={4}&" +
        "limit={5}";

    public GetAllFilteredFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var route = string.Format(
            RouteTemplate,
            ValidReceiverId,
            ValidReceiverName,
            MessageFunctionalTestConfigurations.SORT_ORDER_NAME,
            MessageFunctionalTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            ValidOffsetValue,
            ValidLimitValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIsNull()
    {
        // Arrange
        var route = string.Format(
            RouteTemplate,
            ValidReceiverId,
            ValidReceiverName,
            MessageFunctionalTestConfigurations.SORT_ORDER_NAME,
            MessageFunctionalTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            ValidOffsetValue,
            ValidLimitValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + 1)]
    public async Task GetAllFilteredAsync_ShouldReturnBadRequestResponse_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var route = string.Format(
            RouteTemplate,
            Faker.Random.AlphaNumeric(length),
            ValidReceiverName,
            MessageFunctionalTestConfigurations.SORT_ORDER_NAME,
            MessageFunctionalTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            ValidOffsetValue,
            ValidLimitValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH + 1)]
    public async Task GetAllFilteredAsync_ShouldReturnBadRequestResponse_WhenReceiverNameLengthIsInvalid(int length)
    {
        // Arrange
        var route = string.Format(
            RouteTemplate,
            ValidReceiverId,
            Faker.Random.AlphaNumeric(length),
            MessageFunctionalTestConfigurations.SORT_ORDER_NAME,
            MessageFunctionalTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            ValidOffsetValue,
            ValidLimitValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.SORT_ORDER_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.SORT_ORDER_MAX_LENGTH + 1)]
    public async Task GetAllFilteredAsync_ShouldReturnBadRequestResponse_WhenSortOrderLengthIsInvalid(int length)
    {
        // Arrange
        var route = string.Format(
            RouteTemplate,
            ValidReceiverId,
            ValidReceiverName,
            Faker.Random.AlphaNumeric(length),
            MessageFunctionalTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            ValidOffsetValue,
            ValidLimitValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH + 1)]
    public async Task GetAllFilteredAsync_ShouldReturnBadRequestResponse_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var route = string.Format(
            RouteTemplate,
            ValidReceiverId,
            ValidReceiverName,
            MessageFunctionalTestConfigurations.SORT_ORDER_NAME,
            Faker.Random.AlphaNumeric(length),
            ValidOffsetValue,
            ValidLimitValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.OFFSET_MIN_VALUE - 1)]
    [InlineData(MessageBusinessConfigurations.OFFSET_MAX_VALUE + 1)]
    public async Task GetAllFilteredAsync_ShouldReturnBadRequestResponse_WhenOffsetValueIsInvalid(int value)
    {
        // Arrange
        var route = string.Format(
            RouteTemplate,
            ValidReceiverId,
            ValidReceiverName,
            MessageFunctionalTestConfigurations.SORT_ORDER_NAME,
            MessageFunctionalTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            value,
            ValidLimitValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.LIMIT_MIN_VALUE - 1)]
    [InlineData(MessageBusinessConfigurations.LIMIT_MAX_VALUE + 1)]
    public async Task GetAllFilteredAsync_ShouldReturnBadRequestResponse_WhenLimitValueIsInvalid(int value)
    {
        // Arrange
        var route = string.Format(
            RouteTemplate,
            ValidReceiverId,
            ValidReceiverName,
            MessageFunctionalTestConfigurations.SORT_ORDER_NAME,
            MessageFunctionalTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            ValidOffsetValue,
            value);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = string.Format(
            RouteTemplate,
            existingReceiverId,
            MessageFunctionalTestConfigurations.EXISTING_SENDER_NAME,
            MessageFunctionalTestConfigurations.SORT_ORDER_NAME,
            MessageFunctionalTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            MessageBusinessConfigurations.OFFSET_MIN_VALUE,
            MessageBusinessConfigurations.LIMIT_MAX_VALUE);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnMessageViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = string.Format(
            RouteTemplate,
            existingReceiverId,
            MessageFunctionalTestConfigurations.EXISTING_SENDER_NAME,
            MessageFunctionalTestConfigurations.SORT_ORDER_NAME,
            MessageFunctionalTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            MessageBusinessConfigurations.OFFSET_MIN_VALUE,
            MessageBusinessConfigurations.LIMIT_MAX_VALUE);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var messageViewResponse = await response
            .Content
            .ReadFromJsonAsync<List<MessageViewResponse>>();

        // Assert
        messageViewResponse
            .Should()
            .Match<ICollection<MessageViewResponse>>(mc => mc.Any(m => 
                                 m.Id == existingMessageId &&
                                 m.Content == MessageFunctionalTestConfigurations.EXISTING_MESSAGE_CONTENT &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId));
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnMessageViewResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = $"{MessageFunctionalTestConfigurations.MESSAGES_API_ROUTE}/filtered";
        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var messageViewResponse = await response
            .Content
            .ReadFromJsonAsync<List<MessageViewResponse>>();

        // Assert
        messageViewResponse
            .Should()
            .Match<ICollection<MessageViewResponse>>(mc => mc.Any(m =>
                                 m.Id == existingMessageId &&
                                 m.Content == MessageFunctionalTestConfigurations.EXISTING_MESSAGE_CONTENT &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId));
    }
}
