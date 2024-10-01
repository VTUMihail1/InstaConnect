using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Web.Features.Posts.Models.Responses;
using InstaConnect.Posts.Web.FunctionalTests.Features.Posts.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.Posts.Controllers.v1;

public class GetPostByIdFunctionalTests : BasePostFunctionalTest
{
    public GetPostByIdFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(PostBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);

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

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(PostTestUtilities.InvalidId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingPostId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingPostId), CancellationToken);

        var postViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostQueryResponse>();

        // Assert
        postViewResponse
            .Should()
            .Match<PostQueryResponse>(m => m.Id == existingPostId &&
                                 m.Content == PostTestUtilities.ValidContent &&
                                 m.UserId == existingUserId &&
                                 m.UserName == PostTestUtilities.ValidUserName &&
                                 m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                 m.Title == PostTestUtilities.ValidTitle);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(SharedTestUtilities.GetNonCaseMatchingString(existingPostId)), CancellationToken);

        var postViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostQueryResponse>();

        // Assert
        postViewResponse
            .Should()
            .Match<PostQueryResponse>(m => m.Id == existingPostId &&
                                 m.Content == PostTestUtilities.ValidContent &&
                                 m.UserId == existingUserId &&
                                 m.UserName == PostTestUtilities.ValidUserName &&
                                 m.UserProfileImage == PostTestUtilities.ValidUserProfileImage &&
                                 m.Title == PostTestUtilities.ValidTitle);
    }
}
