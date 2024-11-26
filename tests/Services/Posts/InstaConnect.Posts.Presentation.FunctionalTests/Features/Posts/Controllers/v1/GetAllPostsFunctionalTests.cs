using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Controllers.v1;

public class GetAllPostsFunctionalTests : BasePostFunctionalTest
{
    public GetAllPostsFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(PostBusinessConfigurations.TITLE_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.TITLE_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostTestUtilities.ValidUserName,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostDoesNotContainProperty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.InvalidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

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
        var route = GetApiRoute(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

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
        var route = GetApiRoute(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            value,
            PostTestUtilities.ValidPageSizeValue);

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
        var route = GetApiRoute(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
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
        var route = GetApiRoute(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostPaginationQueryResponse>();

        // Assert
        postPaginationCollectionResponse
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                               m.Title == PostTestUtilities.ValidTitle &&
                                                               m.Content == PostTestUtilities.ValidContent) &&
                                                               mc.Page == PostTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValidAndCurrentUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostPaginationQueryResponse>();

        // Assert
        postPaginationCollectionResponse
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                               m.Title == PostTestUtilities.ValidTitle &&
                                                               m.Content == PostTestUtilities.ValidContent) &&
                                                               mc.Page == PostTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValidAndUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetNonCaseMatchingString(existingUserId),
            PostTestUtilities.ValidUserName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostPaginationQueryResponse>();

        // Assert
        postPaginationCollectionResponse
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                               m.Title == PostTestUtilities.ValidTitle &&
                                                               m.Content == PostTestUtilities.ValidContent) &&
                                                               mc.Page == PostTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValidAndUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetNonCaseMatchingString(PostTestUtilities.ValidUserName),
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostPaginationQueryResponse>();

        // Assert
        postPaginationCollectionResponse
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                               m.Title == PostTestUtilities.ValidTitle &&
                                                               m.Content == PostTestUtilities.ValidContent) &&
                                                               mc.Page == PostTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValidAndUserNameIsNotFull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetHalfStartString(PostTestUtilities.ValidUserName),
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostPaginationQueryResponse>();

        // Assert
        postPaginationCollectionResponse
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                               m.Title == PostTestUtilities.ValidTitle &&
                                                               m.Content == PostTestUtilities.ValidContent) &&
                                                               mc.Page == PostTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValidAndTitleCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostTestUtilities.ValidUserName,
            SharedTestUtilities.GetNonCaseMatchingString(PostTestUtilities.ValidTitle),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostPaginationQueryResponse>();

        // Assert
        postPaginationCollectionResponse
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                               m.Title == PostTestUtilities.ValidTitle &&
                                                               m.Content == PostTestUtilities.ValidContent) &&
                                                               mc.Page == PostTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValidAndTitleIsNotFull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetHalfStartString(PostTestUtilities.ValidUserName),
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostPaginationQueryResponse>();

        // Assert
        postPaginationCollectionResponse
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                               m.Title == PostTestUtilities.ValidTitle &&
                                                               m.Content == PostTestUtilities.ValidContent) &&
                                                               mc.Page == PostTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(ApiRoute, CancellationToken);

        var postPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostPaginationQueryResponse>();

        // Assert
        postPaginationCollectionResponse
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                                               m.Title == PostTestUtilities.ValidTitle &&
                                                               m.Content == PostTestUtilities.ValidContent) &&
                                                               mc.Page == PostTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    private string GetApiRoute(string userId, string userName, string title, SortOrder sortOrder, string sortPropertyName, int page, int pageSize)
    {
        var routeTemplate = "{0}?userId={1}&username={2}&title={3}&sortOrder={4}&sortPropertyName={5}&page={6}&pageSize={7}";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            userId,
            userName,
            title,
            sortOrder,
            sortPropertyName,
            page,
            pageSize);

        return route;
    }
}
