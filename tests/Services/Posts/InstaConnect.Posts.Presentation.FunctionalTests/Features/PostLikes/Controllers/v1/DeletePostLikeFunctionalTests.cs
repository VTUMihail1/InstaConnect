using System.Net;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Controllers.v1;

public class DeletePostLikeFunctionalTests : BasePostLikeFunctionalTest
{
    public DeletePostLikeFunctionalTests(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new DeletePostLikeRequest(
            existingPostLike.Id,
            existingPostLike.UserId);

        // Act
        var response = await PostLikesClient.DeleteStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(PostLikeBusinessConfigurations.IdMinLength - 1)]
    [InlineData(PostLikeBusinessConfigurations.IdMaxLength + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new DeletePostLikeRequest(
            SharedTestUtilities.GetString(length),
            existingPostLike.UserId);

        // Act
        var response = await PostLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new DeletePostLikeRequest(
            existingPostLike.Id,
            null);

        // Act
        var response = await PostLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new DeletePostLikeRequest(
            existingPostLike.Id,
            SharedTestUtilities.GetString(length));

        // Act
        var response = await PostLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new DeletePostLikeRequest(
            PostLikeTestUtilities.InvalidId,
            existingPostLike.UserId);

        // Act
        var response = await PostLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnThePostLikeIdInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new DeletePostLikeRequest(
            existingPostLike.Id,
            existingUser.Id);

        // Act
        var response = await PostLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new DeletePostLikeRequest(
            existingPostLike.Id,
            existingPostLike.UserId);

        // Act
        var response = await PostLikesClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePostLike_WhenRequestIsValid()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new DeletePostLikeRequest(
            existingPostLike.Id,
            existingPostLike.UserId);

        // Act
        await PostLikesClient.DeleteAsync(request, CancellationToken);

        var message = await PostLikeWriteRepository.GetByIdAsync(existingPostLike.Id, CancellationToken);

        // Assert
        message
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePostLike_WhenRequestIsValidAndIdDoesNotMatchCase()
    {
        // Arrange
        var existingPostLike = await CreatePostLikeAsync(CancellationToken);
        var request = new DeletePostLikeRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPostLike.Id),
            existingPostLike.UserId);

        // Act
        await PostLikesClient.DeleteAsync(request, CancellationToken);

        var message = await PostLikeWriteRepository.GetByIdAsync(existingPostLike.Id, CancellationToken);

        // Assert
        message
            .Should()
            .BeNull();
    }
}
