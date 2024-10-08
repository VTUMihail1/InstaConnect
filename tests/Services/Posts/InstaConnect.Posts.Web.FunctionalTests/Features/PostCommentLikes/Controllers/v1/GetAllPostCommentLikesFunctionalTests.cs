﻿using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Web.FunctionalTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.PostCommentLikes.Controllers.v1;

public class GetAllPostCommentLikesFunctionalTests : BasePostCommentLikeFunctionalTest
{
    public GetAllPostCommentLikesFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentLikeBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetString(length),
            PostCommentLikeTestUtilities.ValidUserName,
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(PostCommentLikeBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetString(length),
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentLikeBusinessConfigurations.POST_COMMENT_ID_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostCommentIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            SharedTestUtilities.GetString(length),
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostCommentLikeDoesNotContainProperty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.InvalidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            value,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentLikePaginationQueryResponse>();

        // Assert
        postCommentLikePaginationCollectionResponse
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostCommentId == existingPostCommentId) &&
                                                               mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRequestIsValidAndCurrentUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentLikePaginationQueryResponse>();

        // Assert
        postCommentLikePaginationCollectionResponse
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostCommentId == existingPostCommentId) &&
                                                               mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRequestIsValidAndUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetNonCaseMatchingString(existingUserId),
            PostCommentLikeTestUtilities.ValidUserName,
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentLikePaginationQueryResponse>();

        // Assert
        postCommentLikePaginationCollectionResponse
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostCommentId == existingPostCommentId) &&
                                                               mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRequestIsValidAndUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetNonCaseMatchingString(PostCommentLikeTestUtilities.ValidUserName),
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentLikePaginationQueryResponse>();

        // Assert
        postCommentLikePaginationCollectionResponse
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostCommentId == existingPostCommentId) &&
                                                               mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRequestIsValidAndUserIsNotFull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetHalfStartString(PostCommentLikeTestUtilities.ValidUserName),
            existingPostCommentId,
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentLikePaginationQueryResponse>();

        // Assert
        postCommentLikePaginationCollectionResponse
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostCommentId == existingPostCommentId) &&
                                                               mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRequestIsValidAndPostIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentLikeTestUtilities.ValidUserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostCommentId),
            PostCommentLikeTestUtilities.ValidSortOrderProperty,
            PostCommentLikeTestUtilities.ValidSortPropertyName,
            PostCommentLikeTestUtilities.ValidPageValue,
            PostCommentLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentLikePaginationQueryResponse>();

        // Assert
        postCommentLikePaginationCollectionResponse
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostCommentId == existingPostCommentId) &&
                                                               mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentLikePaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(ApiRoute, CancellationToken);

        var postCommentLikePaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentLikePaginationQueryResponse>();

        // Assert
        postCommentLikePaginationCollectionResponse
            .Should()
            .Match<PostCommentLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentLikeId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                                               m.PostCommentId == existingPostCommentId) &&
                                                               mc.Page == PostCommentLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostCommentLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostCommentLikeTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    private string GetApiRoute(string userId, string userName, string postCommentId, SortOrder sortOrder, string sortPropertyName, int page, int pageSize)
    {
        var routeTemplate = "{0}?userId={1}&username={2}&postCommentId={3}&sortOrder={4}&sortPropertyName={5}&page={6}&pageSize={7}";

        var route = string.Format(
            routeTemplate,
            ApiRoute,
            userId,
            userName,
            postCommentId,
            sortOrder,
            sortPropertyName,
            page,
            pageSize);

        return route;
    }
}
