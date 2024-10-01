using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Web.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Web.FunctionalTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.PostLikes.Controllers.v1;

public class GetAllPostLikesFunctionalTests : BasePostLikeFunctionalTest
{
    public GetAllPostLikesFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetString(length),
            PostLikeTestUtilities.ValidUserName,
            existingPostId,
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
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetString(length),
            existingPostId,
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
    [InlineData(PostLikeBusinessConfigurations.POST_ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.POST_ID_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
            SharedTestUtilities.GetString(length),
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
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostLikeDoesNotContainProperty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
            existingPostId,
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
            existingPostId,
            ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
            existingPostId,
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
            existingPostId,
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
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
            existingPostId,
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
    public async Task GetAllAsync_ShouldReturnPostLikePaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostLikePaginationQueryResponse>();

        // Assert
        postLikePaginationCollectionResponse
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostLikePaginationCollectionResponse_WhenRequestIsValidAndCurrentUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostLikePaginationQueryResponse>();

        // Assert
        postLikePaginationCollectionResponse
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostLikePaginationCollectionResponse_WhenRequestIsValidAndUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetNonCaseMatchingString(existingUserId),
            PostLikeTestUtilities.ValidUserName,
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostLikePaginationQueryResponse>();

        // Assert
        postLikePaginationCollectionResponse
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostLikePaginationCollectionResponse_WhenRequestIsValidAndUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetNonCaseMatchingString(PostLikeTestUtilities.ValidUserName),
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostLikePaginationQueryResponse>();

        // Assert
        postLikePaginationCollectionResponse
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostLikePaginationCollectionResponse_WhenRequestIsValidAndUserNameIsNotFull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetHalfStartString(PostLikeTestUtilities.ValidUserName),
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostLikePaginationQueryResponse>();

        // Assert
        postLikePaginationCollectionResponse
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostLikePaginationCollectionResponse_WhenRequestIsValidAndPostIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostLikeTestUtilities.ValidUserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostId),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostLikePaginationQueryResponse>();

        // Assert
        postLikePaginationCollectionResponse
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostLikePaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(ApiRoute, CancellationToken);

        var postLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostLikePaginationQueryResponse>();

        // Assert
        postLikePaginationCollectionResponse
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    private string GetApiRoute(string userId, string userName, string postId, SortOrder sortOrder, string sortPropertyName, int page, int pageSize)
    {
        var routeTemplate = "{0}?userId={1}&username={2}&postId={3}&sortOrder={4}&sortPropertyName={5}&page={6}&pageSize={7}";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            userId,
            userName,
            postId,
            sortOrder,
            sortPropertyName,
            page,
            pageSize);

        return route;
    }
}
