using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Common.Features.Messages.Utilities;
using InstaConnect.Messages.Web.Features.Messages.Models.Responses;
using InstaConnect.Messages.Web.FunctionalTests.Features.Messages.Utilities;
using InstaConnect.Messages.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Messages.Web.FunctionalTests.Features.Messages.Controllers.v1;

public class GetAllMessagesFunctionalTests : BaseMessageFunctionalTest
{
    public GetAllMessagesFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
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
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetString(length),
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(MessageBusinessConfigurations.RECEIVER_NAME_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenReceiverNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            SharedTestUtilities.GetString(length),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenMessageDoesNotContainProperty()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            InvalidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.SORT_PROPERTY_NAME_MIN_LENGTH - 1)]
    [InlineData(SharedBusinessConfigurations.SORT_PROPERTY_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            ValidPageValue,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            value,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }



    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MAX_VALUE + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            value);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var messagePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<MessagePaginationCollectionQueryResponse>();

        // Assert
        messagePaginationCollectionResponse
            .Should()
            .Match<MessagePaginationCollectionQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessageId &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingSenderId &&
                                                               m.SenderName == MessageTestUtilities.ValidUserName &&
                                                               m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                               m.ReceiverId == existingReceiverId &&
                                                               m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                               m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndCurrentUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetNonCaseMatchingString(existingSenderId);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var messagePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<MessagePaginationCollectionQueryResponse>();

        // Assert
        messagePaginationCollectionResponse
            .Should()
            .Match<MessagePaginationCollectionQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessageId &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingSenderId &&
                                                               m.SenderName == MessageTestUtilities.ValidUserName &&
                                                               m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                               m.ReceiverId == existingReceiverId &&
                                                               m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                               m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndReceiverIdCaseDoesNotMatch()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetNonCaseMatchingString(existingReceiverId),
            MessageTestUtilities.ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var messagePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<MessagePaginationCollectionQueryResponse>();

        // Assert
        messagePaginationCollectionResponse
            .Should()
            .Match<MessagePaginationCollectionQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessageId &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingSenderId &&
                                                               m.SenderName == MessageTestUtilities.ValidUserName &&
                                                               m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                               m.ReceiverId == existingReceiverId &&
                                                               m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                               m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndReceiverNameCaseDoesNotMatch()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            SharedTestUtilities.GetNonCaseMatchingString(MessageTestUtilities.ValidUserName),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var messagePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<MessagePaginationCollectionQueryResponse>();

        // Assert
        messagePaginationCollectionResponse
            .Should()
            .Match<MessagePaginationCollectionQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessageId &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingSenderId &&
                                                               m.SenderName == MessageTestUtilities.ValidUserName &&
                                                               m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                               m.ReceiverId == existingReceiverId &&
                                                               m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                               m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRequestIsValidAndReceiverNameIsNotFull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);
        var route = GetApiRoute(
            existingReceiverId,
            SharedTestUtilities.GetHalfStartString(MessageTestUtilities.ValidUserName),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var messagePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<MessagePaginationCollectionQueryResponse>();

        // Assert
        messagePaginationCollectionResponse
            .Should()
            .Match<MessagePaginationCollectionQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessageId &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingSenderId &&
                                                               m.SenderName == MessageTestUtilities.ValidUserName &&
                                                               m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                               m.ReceiverId == existingReceiverId &&
                                                               m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                               m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnMessagePaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var existingMessageId = await CreateMessageAsync(existingSenderId, existingReceiverId, CancellationToken);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingSenderId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.GetAsync(ApiRoute, CancellationToken);

        var messagePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<MessagePaginationCollectionQueryResponse>();

        // Assert
        messagePaginationCollectionResponse
            .Should()
            .Match<MessagePaginationCollectionQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingMessageId &&
                                                               m.Content == MessageTestUtilities.ValidContent &&
                                                               m.SenderId == existingSenderId &&
                                                               m.SenderName == MessageTestUtilities.ValidUserName &&
                                                               m.SenderProfileImage == MessageTestUtilities.ValidUserProfileImage &&
                                                               m.ReceiverId == existingReceiverId &&
                                                               m.ReceiverName == MessageTestUtilities.ValidUserName &&
                                                               m.ReceiverProfileImage == MessageTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    private string GetApiRoute(string receiverId, string receiverName, SortOrder sortOrder, string sortPropertyName, int page, int pageSize)
    {
        var routeTemplate = "{0}?receiverId={1}&receiverName={2}&sortOrder={3}&sortPropertyName={4}&page={5}&pageSize={6}";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            receiverId,
            receiverName,
            sortOrder,
            sortPropertyName,
            page,
            pageSize);

        return route;
    }
}
