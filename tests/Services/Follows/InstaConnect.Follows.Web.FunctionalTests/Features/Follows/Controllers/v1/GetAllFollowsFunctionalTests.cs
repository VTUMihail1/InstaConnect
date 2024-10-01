using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

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
            SharedTestUtilities.GetString(length),
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
            SharedTestUtilities.GetString(length),
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
            FollowTestUtilities.ValidUserName,
            SharedTestUtilities.GetString(length),
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            SharedTestUtilities.GetString(length),
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.InvalidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            value,
            FollowTestUtilities.ValidPageSizeValue);

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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
            SharedTestUtilities.GetNonCaseMatchingString(existingFollowerId),
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
                                                               m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == FollowTestUtilities.ValidPageValue &&
                                                               mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
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
            SharedTestUtilities.GetNonCaseMatchingString(FollowTestUtilities.ValidUserName),
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
                                                               m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == FollowTestUtilities.ValidPageValue &&
                                                               mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
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
            SharedTestUtilities.GetHalfStartString(FollowTestUtilities.ValidUserName),
            existingFollowingId,
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
                                                               m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == FollowTestUtilities.ValidPageValue &&
                                                               mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
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
            FollowTestUtilities.ValidUserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingFollowingId),
            FollowTestUtilities.ValidUserName,
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
                                                               m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == FollowTestUtilities.ValidPageValue &&
                                                               mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            SharedTestUtilities.GetNonCaseMatchingString(FollowTestUtilities.ValidUserName),
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
                                                               m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == FollowTestUtilities.ValidPageValue &&
                                                               mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
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
            FollowTestUtilities.ValidUserName,
            existingFollowingId,
            SharedTestUtilities.GetHalfStartString(FollowTestUtilities.ValidUserName),
            FollowTestUtilities.ValidSortOrderProperty,
            FollowTestUtilities.ValidSortPropertyName,
            FollowTestUtilities.ValidPageValue,
            FollowTestUtilities.ValidPageSizeValue);

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
                                                               m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == FollowTestUtilities.ValidPageValue &&
                                                               mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
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
                                                               m.FollowerName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                                               m.FollowingId == existingFollowingId &&
                                                               m.FollowingName == FollowTestUtilities.ValidUserName &&
                                                               m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage) &&
                                                               mc.Page == FollowTestUtilities.ValidPageValue &&
                                                               mc.PageSize == FollowTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == FollowTestUtilities.ValidTotalCountValue &&
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
