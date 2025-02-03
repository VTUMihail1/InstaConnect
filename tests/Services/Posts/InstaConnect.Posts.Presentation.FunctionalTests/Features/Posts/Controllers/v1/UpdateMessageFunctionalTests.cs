using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Binding;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;
using InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Utilities;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Controllers.v1;

public class UpdatePostFunctionalTests : BasePostFunctionalTest
{
    public UpdatePostFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(PostConfigurations.IdMinLength - 1)]
    [InlineData(PostConfigurations.IdMaxLength + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            SharedTestUtilities.GetString(length),
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenTitleIsNull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingPost.UserId,
            new(null!, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.TitleMinLength - 1)]
    [InlineData(PostConfigurations.TitleMaxLength + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingPost.UserId,
            new(SharedTestUtilities.GetString(length), PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, null!)
        );

        // Act
        var response = await PostsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostConfigurations.ContentMinLength - 1)]
    [InlineData(PostConfigurations.ContentMaxLength + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, SharedTestUtilities.GetString(length))
        );

        // Act
        var response = await PostsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            existingPost.Id,
            null!,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            existingPost.Id,
            SharedTestUtilities.GetString(length),
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange\
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            PostTestUtilities.InvalidId,
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnThePostIdInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingUser.Id,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnPostViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateAsync(request, CancellationToken);

        // Assert

        response
            .Should()
            .Match<PostCommandResponse>(m => m.Id == existingPost.Id);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePost_WhenRequestIsValid()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            existingPost.Id,
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateAsync(request, CancellationToken);

        var post = await PostWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Arrange
        post
            .Should()
            .Match<Post>(m => m.Id == response.Id &&
                                 m.UserId == existingPost.UserId &&
                                 m.Title == PostTestUtilities.ValidUpdateTitle &&
                                 m.Content == PostTestUtilities.ValidUpdateContent);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePost_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingPost = await CreatePostAsync(CancellationToken);
        var request = new UpdatePostRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingPost.Id),
            existingPost.UserId,
            new(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent)
        );

        // Act
        var response = await PostsClient.UpdateAsync(request, CancellationToken);

        var post = await PostWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Arrange
        post
            .Should()
            .Match<Post>(m => m.Id == response.Id &&
                                 m.UserId == existingPost.UserId &&
                                 m.Title == PostTestUtilities.ValidUpdateTitle &&
                                 m.Content == PostTestUtilities.ValidUpdateContent);
    }
}
