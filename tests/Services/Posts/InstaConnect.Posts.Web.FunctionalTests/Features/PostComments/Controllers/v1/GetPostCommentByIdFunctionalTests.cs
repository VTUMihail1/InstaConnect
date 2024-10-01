using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.PostComments.Utilities;
using InstaConnect.Posts.Web.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Web.FunctionalTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.PostComments.Controllers.v1;

public class GetPostCommentByIdFunctionalTests : BasePostCommentFunctionalTest
{
    public GetPostCommentByIdFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(PostCommentBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);

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

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(PostCommentTestUtilities.InvalidId), CancellationToken);

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

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingPostCommentId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostCommentViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingPostCommentId), CancellationToken);

        var postCommentViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentQueryResponse>();

        // Assert
        postCommentViewResponse
            .Should()
            .Match<PostCommentQueryResponse>(m => m.Id == existingPostCommentId &&
                                 m.Content == PostCommentTestUtilities.ValidContent &&
                                 m.UserId == existingUserId &&
                                 m.UserName == PostCommentTestUtilities.ValidUserName &&
                                 m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                 m.PostId == existingPostId);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostCommentViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(SharedTestUtilities.GetNonCaseMatchingString(existingPostCommentId)), CancellationToken);

        var postCommentViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentQueryResponse>();

        // Assert
        postCommentViewResponse
            .Should()
            .Match<PostCommentQueryResponse>(m => m.Id == existingPostCommentId &&
                                 m.Content == PostCommentTestUtilities.ValidContent &&
                                 m.UserId == existingUserId &&
                                 m.UserName == PostCommentTestUtilities.ValidUserName &&
                                 m.UserProfileImage == PostCommentTestUtilities.ValidUserProfileImage &&
                                 m.PostId == existingPostId);
    }
}
