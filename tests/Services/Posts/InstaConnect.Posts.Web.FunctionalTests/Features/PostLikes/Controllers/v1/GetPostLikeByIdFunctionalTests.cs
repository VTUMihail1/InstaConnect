using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Web.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Web.FunctionalTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.PostLikes.Controllers.v1;

public class GetPostLikeByIdFunctionalTests : BasePostLikeFunctionalTest
{
    public GetPostLikeByIdFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(PostLikeBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostLikeBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(Faker.Random.AlphaNumeric(length)), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(PostLikeTestUtilities.InvalidId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingPostLikeId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostLikeViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingPostLikeId), CancellationToken);

        var postLikeViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostLikeQueryResponse>();

        // Assert
        postLikeViewResponse
            .Should()
            .Match<PostLikeQueryResponse>(m => m.Id == existingPostLikeId &&
                                 m.UserId == existingUserId &&
                                 m.UserName == PostLikeTestUtilities.ValidUserName &&
                                 m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                 m.PostId == existingPostId);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostLikeViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostLikeId = await CreatePostLikeAsync(existingUserId, existingPostId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(GetNonCaseMatchingString(existingPostLikeId)), CancellationToken);

        var postLikeViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostLikeQueryResponse>();

        // Assert
        postLikeViewResponse
            .Should()
            .Match<PostLikeQueryResponse>(m => m.Id == existingPostLikeId &&
                                 m.UserId == existingUserId &&
                                 m.UserName == PostLikeTestUtilities.ValidUserName &&
                                 m.UserProfileImage == PostLikeTestUtilities.ValidUserProfileImage &&
                                 m.PostId == existingPostId);
    }
}
