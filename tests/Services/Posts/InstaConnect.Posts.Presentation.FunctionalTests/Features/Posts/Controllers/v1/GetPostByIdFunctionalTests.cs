using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Controllers.v1;

public class GetPostByIdFunctionalTests : BasePostFunctionalTest
{
    public GetPostByIdFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetPostByIdRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await PostsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetPostByIdRequest(
            PostTestUtilities.InvalidId
        );

        // Act
        var response = await PostsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetPostByIdRequest(
            existingPost.Id
        );

        // Act
        var response = await PostsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetPostByIdRequest(
            existingPost.Id
        );

        // Act
        var response = await PostsClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostQueryResponse>(m => m.Id == existingPost.Id &&
                                 m.Content == PostTestUtilities.ValidContent &&
                                 m.UserId == existingPost.UserId &&
                                 m.UserName == UserTestUtilities.ValidName &&
                                 m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                 m.Title == PostTestUtilities.ValidTitle);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new GetPostByIdRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.Id)
        );

        // Act
        var response = await PostsClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostQueryResponse>(m => m.Id == existingPost.Id &&
                                 m.Content == PostTestUtilities.ValidContent &&
                                 m.UserId == existingPost.UserId &&
                                 m.UserName == UserTestUtilities.ValidName &&
                                 m.UserProfileImage == UserTestUtilities.ValidProfileImage &&
                                 m.Title == PostTestUtilities.ValidTitle);
    }
}
