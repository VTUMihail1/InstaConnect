using System.Net;

using FluentAssertions;

using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Controllers.v1;

public class GetAllPostLikesFunctionalTests : BasePostLikeFunctionalTest
{
    public GetAllPostLikesFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            SharedTestUtilities.GetString(length),
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            SharedTestUtilities.GetString(length),
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            SharedTestUtilities.GetString(length),
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnBadRequestResponse_WhenPostLikeDoesNotContainProperty()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.InvalidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            value,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            value);

        // Act
        var response = await PostLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnPostLikePaginationCollectionResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLike.Id &&
                                                               m.UserId == existingPostLike.UserId &&
                                                               m.UserName == existingPostLike.User.UserName &&
                                                               m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                               m.PostId == existingPostLike.PostId) &&
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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLike.Id &&
                                                               m.UserId == existingPostLike.UserId &&
                                                               m.UserName == existingPostLike.User.UserName &&
                                                               m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                               m.PostId == existingPostLike.PostId) &&
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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostLike.UserId),
            existingPostLike.User.UserName,
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLike.Id &&
                                                               m.UserId == existingPostLike.UserId &&
                                                               m.UserName == existingPostLike.User.UserName &&
                                                               m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                               m.PostId == existingPostLike.PostId) &&
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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostLike.User.UserName),
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLike.Id &&
                                                               m.UserId == existingPostLike.UserId &&
                                                               m.UserName == existingPostLike.User.UserName &&
                                                               m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                               m.PostId == existingPostLike.PostId) &&
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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            SharedTestUtilities.GetHalfStartString(existingPostLike.User.UserName),
            existingPostLike.PostId,
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLike.Id &&
                                                               m.UserId == existingPostLike.UserId &&
                                                               m.UserName == existingPostLike.User.UserName &&
                                                               m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                               m.PostId == existingPostLike.PostId) &&
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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetAllPostLikesRequest(
            existingPostLike.UserId,
            existingPostLike.User.UserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingPostLike.PostId),
            PostLikeTestUtilities.ValidSortOrderProperty,
            PostLikeTestUtilities.ValidSortPropertyName,
            PostLikeTestUtilities.ValidPageValue,
            PostLikeTestUtilities.ValidPageSizeValue);

        // Act
        var response = await PostLikesClient.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLike.Id &&
                                                               m.UserId == existingPostLike.UserId &&
                                                               m.UserName == existingPostLike.User.UserName &&
                                                               m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                               m.PostId == existingPostLike.PostId) &&
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
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);

        // Act
        var response = await PostLikesClient.GetAllAsync(CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikePaginationQueryResponse>(mc => mc.Items.All(m =>
                                                               m.Id == existingPostLike.Id &&
                                                               m.UserId == existingPostLike.UserId &&
                                                               m.UserName == existingPostLike.User.UserName &&
                                                               m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                                               m.PostId == existingPostLike.PostId) &&
                                                               mc.Page == PostLikeTestUtilities.ValidPageValue &&
                                                               mc.PageSize == PostLikeTestUtilities.ValidPageSizeValue &&
                                                               mc.TotalCount == PostLikeTestUtilities.ValidTotalCountValue &&
                                                               !mc.HasPreviousPage &&
                                                               !mc.HasNextPage);
    }
}
