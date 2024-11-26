using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Controllers.v1;

public class GetPostCommentLikeByIdFunctionalTests : BasePostCommentLikeFunctionalTest
{
    public GetPostCommentLikeByIdFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(PostCommentLikeBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentLikeBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(SharedTestUtilities.GetString(length)), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(PostCommentLikeTestUtilities.InvalidId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingPostCommentLikeId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostCommentLikeViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingPostCommentLikeId), CancellationToken);

        var postCommentLikeViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentLikeQueryResponse>();

        // Assert
        postCommentLikeViewResponse
            .Should()
            .Match<PostCommentLikeQueryResponse>(m => m.Id == existingPostCommentLikeId &&
                                 m.UserId == existingUserId &&
                                 m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                 m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                 m.PostCommentId == existingPostCommentId);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostCommentLikeViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var existingPostCommentLikeId = await CreatePostCommentLikeAsync(existingUserId, existingPostCommentId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(SharedTestUtilities.GetNonCaseMatchingString(existingPostCommentLikeId)), CancellationToken);

        var postCommentLikeViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentLikeQueryResponse>();

        // Assert
        postCommentLikeViewResponse
            .Should()
            .Match<PostCommentLikeQueryResponse>(m => m.Id == existingPostCommentLikeId &&
                                 m.UserId == existingUserId &&
                                 m.UserName == PostCommentLikeTestUtilities.ValidUserName &&
                                 m.UserProfileImage == PostCommentLikeTestUtilities.ValidUserProfileImage &&
                                 m.PostCommentId == existingPostCommentId);
    }
}
