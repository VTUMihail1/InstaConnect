using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
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
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(PostConfigurations.TitleMinLength - 1)]
    [InlineData(PostConfigurations.TitleMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostDoesNotContainProperty()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.InvalidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.SortPropertyMinLength - 1)]
    [InlineData(SharedConfigurations.SortPropertyMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            value,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }



    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            value);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostPaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
                                                               m.UserId == existingPost.UserId &&
                                                               m.UserName == UserTestUtilities.ValidName &&
                                                               m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
                                                               m.UserId == existingPost.UserId &&
                                                               m.UserName == UserTestUtilities.ValidName &&
                                                               m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.UserId),
            UserTestUtilities.ValidName,
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
                                                               m.UserId == existingPost.UserId &&
                                                               m.UserName == UserTestUtilities.ValidName &&
                                                               m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
                                                               m.UserId == existingPost.UserId &&
                                                               m.UserName == UserTestUtilities.ValidName &&
                                                               m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
                                                               m.UserId == existingPost.UserId &&
                                                               m.UserName == UserTestUtilities.ValidName &&
                                                               m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetNonCaseMatchingString(PostTestUtilities.ValidTitle),
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
                                                               m.UserId == existingPost.UserId &&
                                                               m.UserName == UserTestUtilities.ValidName &&
                                                               m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetAllPostsRequest(
            existingPost.UserId,
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            PostTestUtilities.ValidTitle,
            PostTestUtilities.ValidSortOrderProperty,
            PostTestUtilities.ValidSortPropertyName,
            PostTestUtilities.ValidPageValue,
            PostTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostsClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
                                                               m.UserId == existingPost.UserId &&
                                                               m.UserName == UserTestUtilities.ValidName &&
                                                               m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
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
        var existingPost = await CreatePostAsync(CancellationToken);

        // Act
        var response = await PostsClient.GetAllAsync(CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPost.Id &&
                                                               m.UserId == existingPost.UserId &&
                                                               m.UserName == UserTestUtilities.ValidName &&
                                                               m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                                               m.Title == PostTestUtilities.ValidTitle &&
                                                               m.Content == PostTestUtilities.ValidContent) &&
                                                               mc.Page == PostTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }
}
