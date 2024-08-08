using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Utilities;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Business.Utilities;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Controllers.v1;

public class GetAllFollowsFunctionalTests : BaseFollowFunctionalTest
{
    public GetAllFollowsFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowerIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            Faker.Random.AlphaNumeric(length),
            ValidUserName,
            existingFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowerNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            Faker.Random.AlphaNumeric(length),
            existingFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            ValidUserName,
            Faker.Random.AlphaNumeric(length),
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_NAME_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowingNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            ValidUserName,
            existingFollowingId,
            Faker.Random.AlphaNumeric(length),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenFollowDoesNotContainProperty()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            ValidUserName,
            existingFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            InvalidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            ValidUserName,
            existingFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            Faker.Random.AlphaNumeric(length),
            ValidPageValue,
            ValidPageSizeValue);

        // Act
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            ValidUserName,
            existingFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            value,
            ValidPageSizeValue);

        // Act
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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            ValidUserName,
            existingFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            value);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            ValidUserName,
            existingFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowerIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            GetNonCaseMatchingString(existingFollowerId),
            ValidUserName,
            existingFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var followPaginationQueryResponse = await response
            .Content
            .ReadFromJsonAsync<FollowPaginationQueryResponse>();

        // Assert
        followPaginationQueryResponse
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
                                                               m.FollowerId == existingFollowerId &&
                                                               m.FollowerName == ValidUserName &&
                                                               m.FollowerProfileImage == ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == ValidUserName &&
                                                               m.FollowingProfileImage == ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowerNameCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            GetNonCaseMatchingString(ValidUserName),
            existingFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var followPaginationQueryResponse = await response
            .Content
            .ReadFromJsonAsync<FollowPaginationQueryResponse>();

        // Assert
        followPaginationQueryResponse
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
                                                               m.FollowerId == existingFollowerId &&
                                                               m.FollowerName == ValidUserName &&
                                                               m.FollowerProfileImage == ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == ValidUserName &&
                                                               m.FollowingProfileImage == ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowerNameIsNotFull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            GetHalfStartString(ValidUserName),
            existingFollowingId,
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var followPaginationQueryResponse = await response
            .Content
            .ReadFromJsonAsync<FollowPaginationQueryResponse>();

        // Assert
        followPaginationQueryResponse
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
                                                               m.FollowerId == existingFollowerId &&
                                                               m.FollowerName == ValidUserName &&
                                                               m.FollowerProfileImage == ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == ValidUserName &&
                                                               m.FollowingProfileImage == ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowingIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            ValidUserName,
            GetNonCaseMatchingString(existingFollowingId),
            ValidUserName,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var followPaginationQueryResponse = await response
            .Content
            .ReadFromJsonAsync<FollowPaginationQueryResponse>();

        // Assert
        followPaginationQueryResponse
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
                                                               m.FollowerId == existingFollowerId &&
                                                               m.FollowerName == ValidUserName &&
                                                               m.FollowerProfileImage == ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == ValidUserName &&
                                                               m.FollowingProfileImage == ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowingNameCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            ValidUserName,
            existingFollowingId,
            GetNonCaseMatchingString(ValidUserName),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var followPaginationQueryResponse = await response
            .Content
            .ReadFromJsonAsync<FollowPaginationQueryResponse>();

        // Assert
        followPaginationQueryResponse
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
                                                               m.FollowerId == existingFollowerId &&
                                                               m.FollowerName == ValidUserName &&
                                                               m.FollowerProfileImage == ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == ValidUserName &&
                                                               m.FollowingProfileImage == ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRequestIsValidAndFollowingNameIsNotFull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var route = GetApiRoute(
            existingFollowerId,
            ValidUserName,
            existingFollowingId,
            GetHalfStartString(ValidUserName),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var followPaginationQueryResponse = await response
            .Content
            .ReadFromJsonAsync<FollowPaginationQueryResponse>();

        // Assert
        followPaginationQueryResponse
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
                                                               m.FollowerId == existingFollowerId &&
                                                               m.FollowerName == ValidUserName &&
                                                               m.FollowerProfileImage == ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == ValidUserName &&
                                                               m.FollowingProfileImage == ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnFollowPaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(ApiRoute, CancellationToken);

        var followPaginationQueryResponse = await response
            .Content
            .ReadFromJsonAsync<FollowPaginationQueryResponse>();

        // Assert
        followPaginationQueryResponse
            .Should()
            .Match<FollowPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingFollowId &&
                                                               m.FollowerId == existingFollowerId &&
                                                               m.FollowerName == ValidUserName &&
                                                               m.FollowerProfileImage == ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == ValidUserName &&
                                                               m.FollowingProfileImage == ValidUserProfileImage) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    private string GetApiRoute(string followerId, string followerName, string followingId, string followingName, SortOrder sortOrder, string sortPropertyName, int page, int pageSize)
    {
        var routeTemplate = "{0}?followerId={1}&followerName={2}&followingId={3}&followingName={4}&sortOrder={5}&sortPropertyName={6}&page={7}&pageSize={8}";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            followerId,
            followerName,
            followingId,
            followingName,
            sortOrder,
            sortPropertyName,
            page,
            pageSize);

        return route;
    }
}
