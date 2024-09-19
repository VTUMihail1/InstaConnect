using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.Posts.Utilities;
using InstaConnect.Posts.Web.Features.Posts.Models.Responses;
using InstaConnect.Posts.Web.FunctionalTests.Features.Posts.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;

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

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(InvalidId), CancellationToken);

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
                                 m.Content == ValidContent &&
                                 m.UserId == existingUserId &&
                                 m.UserName == ValidUserName &&
                                 m.UserProfileImage == ValidUserProfileImage &&
                                 m.Title == ValidTitle);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(GetNonCaseMatchingString(existingPostId)), CancellationToken);

        var postViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostQueryResponse>();

        // Assert
        postViewResponse
            .Should()
            .Match<PostQueryResponse>(m => m.Id == existingPostId &&
                                 m.Content == ValidContent &&
                                 m.UserId == existingUserId &&
                                 m.UserName == ValidUserName &&
                                 m.UserProfileImage == ValidUserProfileImage &&
                                 m.Title == ValidTitle);
    }
}
