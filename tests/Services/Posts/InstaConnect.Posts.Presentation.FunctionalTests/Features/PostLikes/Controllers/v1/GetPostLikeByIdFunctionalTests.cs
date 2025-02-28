using InstaConnect.Posts.Common.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Controllers.v1;

public class GetPostLikeByIdFunctionalTests : BasePostLikeFunctionalTest
{
    public GetPostLikeByIdFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(PostLikeConfigurations.IdMinLength - 1)]
    [InlineData(PostLikeConfigurations.IdMaxLength + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var request = new GetPostLikeByIdRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await PostLikesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var request = new GetPostLikeByIdRequest(
            PostLikeTestUtilities.InvalidId
        );

        // Act
        var response = await PostLikesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetPostLikeByIdRequest(
            existingPostLike.Id
        );

        // Act
        var response = await PostLikesClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostLikeViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetPostLikeByIdRequest(
            existingPostLike.Id
        );

        // Act
        var response = await PostLikesClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeQueryResponse>(m => m.Id == existingPostLike.Id &&
                                 m.UserId == existingPostLike.UserId &&
                                 m.UserName == existingPostLike.User.UserName &&
                                 m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                 m.PostId == existingPostLike.PostId);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnPostLikeViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new GetPostLikeByIdRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostLike.Id)
        );

        // Act
        var response = await PostLikesClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<PostLikeQueryResponse>(m => m.Id == existingPostLike.Id &&
                                 m.UserId == existingPostLike.UserId &&
                                 m.UserName == existingPostLike.User.UserName &&
                                 m.UserProfileImage == existingPostLike.User.ProfileImage &&
                                 m.PostId == existingPostLike.PostId);
    }
}
