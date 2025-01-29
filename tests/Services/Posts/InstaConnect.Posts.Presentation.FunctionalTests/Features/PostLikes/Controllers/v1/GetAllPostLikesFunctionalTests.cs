using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Controllers.v1;

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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.InvalidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.SortPropertyMinLength - 1)]
    [InlineData(SharedConfigurations.SortPropertyMaxLength + 1)]
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
            PostLikeTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            value,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }



    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
                                                               mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
                                                               mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
                                                               mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
                                                               mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
                                                               mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
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
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

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
                                                               mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
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
                                                               mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
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
