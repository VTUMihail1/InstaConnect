using System.Net;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Controllers.v1;

public class GetPostCommentLikeByIdFunctionalTests : BasePostCommentLikeFunctionalTest
{
    public GetPostCommentLikeByIdFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(PostCommentLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostCommentLikeConfigurations.IdMaxLength + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetPostCommentLikeByIdRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await PostCommentLikesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetPostCommentLikeByIdRequest(
            PostCommentLikeTestUtilities.InvalidId
        );

        // Act
        var response = await PostCommentLikesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetPostCommentLikeByIdRequest(
            existingPostCommentLike.Id
        );

        // Act
        var response = await PostCommentLikesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostCommentLikeViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetPostCommentLikeByIdRequest(
            existingPostCommentLike.Id
        );

        // Act
        var response = await PostCommentLikesClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikeQueryResponse>(m => m.Id == existingPostCommentLike.Id &&
                                 m.UserId == existingPostCommentLike.UserId &&
                                 m.UserName == existingPostCommentLike.User.UserName &&
                                 m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                 m.PostCommentId == existingPostCommentLike.PostCommentId);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostCommentLikeViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostCommentLike = await CreatePostCommentLikeAsync(CancellationToken);
        var request = new GetPostCommentLikeByIdRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostCommentLike.Id)
        );

        // Act
        var response = await PostCommentLikesClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostCommentLikeQueryResponse>(m => m.Id == existingPostCommentLike.Id &&
                                 m.UserId == existingPostCommentLike.UserId &&
                                 m.UserName == existingPostCommentLike.User.UserName &&
                                 m.UserProfileImage == existingPostCommentLike.User.ProfileImage &&
                                 m.PostCommentId == existingPostCommentLike.PostCommentId);
    }
}
