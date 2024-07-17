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
        "page={4}&" +
        "pageSize={5}";

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
            ValidPageValue,
            ValidPageSizeValue);

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
            ValidPageValue,
            ValidPageSizeValue);

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
            ValidPageValue,
            ValidPageSizeValue);

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
            ValidPageValue,
            ValidPageSizeValue);

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
            ValidPageValue,
            ValidPageSizeValue);

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
            ValidPageValue,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(MessageBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public async Task GetAllFilteredAsync_ShouldReturnBadRequestResponse_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var route = string.Format(
            RouteTemplate,
            ValidReceiverId,
            ValidReceiverName,
            MessageFunctionalTestConfigurations.SORT_ORDER_NAME,
            MessageFunctionalTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            value,
            ValidPageSizeValue
            );

        

        ValidJwtConfig[ClaimTypes.NameIdentifier] = ValidCurrentUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }



    [Theory]
    [InlineData(MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE - 1)]
    [InlineData(MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE + 1)]
    public async Task GetAllFilteredAsync_ShouldReturnBadRequestResponse_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var route = string.Format(
            RouteTemplate,
            ValidReceiverId,
            ValidReceiverName,
            MessageFunctionalTestConfigurations.SORT_ORDER_NAME,
            MessageFunctionalTestConfigurations.SORT_PROPERTY_ORDER_VALUE,
            ValidPageValue,
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
            MessageBusinessConfigurations.PAGE_MIN_VALUE,
            MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValid()
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
            MessageBusinessConfigurations.PAGE_MIN_VALUE,
            MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var messagePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<MessagePaginationCollectionResponse>();

        // Assert
        messagePaginationCollectionResponse
            .Should()
            .Match<MessagePaginationCollectionResponse>(mc => mc.Items.Any(m => 
                                                              m.Id == existingMessageId &&
                                                              m.Content == MessageFunctionalTestConfigurations.EXISTING_MESSAGE_CONTENT &&
                                                              m.SenderId == existingSenderId &&
                                                              m.ReceiverId == existingReceiverId) &&
                                                              mc.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                              mc.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                              mc.TotalCount == MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE &&
                                                              !mc.HasPreviousPage &&
                                                              !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllFilteredAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRouteHasNoParameters()
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

        var messagePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<MessagePaginationCollectionResponse>();

        // Assert
        messagePaginationCollectionResponse
            .Should()
            .Match<MessagePaginationCollectionResponse>(mc => mc.Items.Any(m =>
                                                               m.Id == existingMessageId &&
                                                               m.Content == MessageFunctionalTestConfigurations.EXISTING_MESSAGE_CONTENT &&
                                                               m.SenderId == existingSenderId &&
                                                               m.ReceiverId == existingReceiverId) &&
                                                               mc.Page == MessageBusinessConfigurations.PAGE_MIN_VALUE &&
                                                               mc.PageSize == MessageBusinessConfigurations.PAGE_SIZE_MAX_VALUE &&
                                                               mc.TotalCount == MessageBusinessConfigurations.PAGE_SIZE_MIN_VALUE &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }
}
