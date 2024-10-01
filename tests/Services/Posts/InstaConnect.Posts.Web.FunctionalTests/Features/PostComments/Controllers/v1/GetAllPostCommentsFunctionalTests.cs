﻿using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Web.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Web.FunctionalTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.PostComments.Controllers.v1;

public class GetAllPostCommentsFunctionalTests : BasePostCommentFunctionalTest
{
    public GetAllPostCommentsFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetString(length),
            PostCommentTestUtilities.ValidUserName,
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
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_NAME_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
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
    [InlineData(PostCommentBusinessConfigurations.POST_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.POST_ID_MAX_LENGTH + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
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
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostCommentDoesNotContainProperty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
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
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentPaginationQueryResponse>();

        // Assert
        postCommentPaginationCollectionResponse
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId &&
                                                               m.Content == PostCommentTestUtilities.ValidContent) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRequestIsValidAndCurrentUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentPaginationQueryResponse>();

        // Assert
        postCommentPaginationCollectionResponse
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId &&
                                                               m.Content == PostCommentTestUtilities.ValidContent) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRequestIsValidAndUserIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            SharedTestUtilities.GetNonCaseMatchingString(existingUserId),
            PostCommentTestUtilities.ValidUserName,
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentPaginationQueryResponse>();

        // Assert
        postCommentPaginationCollectionResponse
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId &&
                                                               m.Content == PostCommentTestUtilities.ValidContent) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRequestIsValidAndUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetNonCaseMatchingString(PostCommentTestUtilities.ValidUserName),
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentPaginationQueryResponse>();

        // Assert
        postCommentPaginationCollectionResponse
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId &&
                                                               m.Content == PostCommentTestUtilities.ValidContent) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRequestIsValidAndUserNameIsNotFull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            SharedTestUtilities.GetHalfStartString(PostCommentTestUtilities.ValidUserName),
            existingPostId,
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentPaginationQueryResponse>();

        // Assert
        postCommentPaginationCollectionResponse
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId &&
                                                               m.Content == PostCommentTestUtilities.ValidContent) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRequestIsValidAndPostIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var route = GetApiRoute(
            existingUserId,
            PostCommentTestUtilities.ValidUserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostId),
            ValidSortOrderProperty,
            ValidSortPropertyName,
            ValidPageValue,
            ValidPageSizeValue);

        // Act
        var response = await HttpClient.GetAsync(route, CancellationToken);

        var postCommentPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentPaginationQueryResponse>();

        // Assert
        postCommentPaginationCollectionResponse
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId &&
                                                               m.Content == PostCommentTestUtilities.ValidContent) &&
                                                               mc.Page == ValidPageValue &&
                                                               mc.PageSize == ValidPageSizeValue &&
                                                               mc.TotalCount == ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostCommentPaginationCollectionResponse_WhenRouteHasNoParameters()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(ApiRoute, CancellationToken);

        var postCommentPaginationCollectionResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentPaginationQueryResponse>();

        // Assert
        postCommentPaginationCollectionResponse
            .Should()
            .Match<PostCommentPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostCommentId &&
                                                               m.UserId == existingUserId &&
                                                               m.UserName == PostCommentTestUtilities.ValidUserName &&
                                                               m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                                               m.PostId == existingPostId &&
                                                               m.Content == PostCommentTestUtilities.ValidContent) &&
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
