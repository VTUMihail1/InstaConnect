using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using Bogus;
using FluentAssertions;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Web.Features.Posts.Models.Binding;
using InstaConnect.Posts.Web.Features.Posts.Models.Responses;
using InstaConnect.Posts.Web.FunctionalTests.Features.Posts.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.Posts.Controllers.v1;

public class UpdatePostFunctionalTests : BasePostFunctionalTest
{
    public UpdatePostFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent);

        // Act
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(PostBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(SharedTestUtilities.GetString(length)),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenTitleIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(null!, PostTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.TITLE_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.TITLE_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenTitleLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(SharedTestUtilities.GetString(length), PostTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, null!);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, SharedTestUtilities.GetString(length));

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetString(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange\
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(PostTestUtilities.InvalidId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnThePostIdInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingPostUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnPostViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostId),
            request,
            CancellationToken);

        // Assert
        var postViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommandResponse>();

        postViewResponse
            .Should()
            .Match<PostCommandResponse>(m => m.Id == existingPostId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePost_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostId),
            request,
            CancellationToken);

        var post = await PostWriteRepository.GetByIdAsync(existingPostId, CancellationToken);

        // Arrange
        post
            .Should()
            .Match<Post>(m => m.Id == existingPostId &&
                                 m.UserId == existingUserId &&
                                 m.Title == PostTestUtilities.ValidUpdateTitle &&
                                 m.Content == PostTestUtilities.ValidUpdateContent);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePost_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var request = new UpdatePostBindingModel(PostTestUtilities.ValidUpdateTitle, PostTestUtilities.ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(SharedTestUtilities.GetNonCaseMatchingString(existingPostId)),
            request,
            CancellationToken);

        var post = await PostWriteRepository.GetByIdAsync(existingPostId, CancellationToken);

        // Arrange
        post
            .Should()
            .Match<Post>(m => m.Id == existingPostId &&
                                 m.UserId == existingUserId &&
                                 m.Title == PostTestUtilities.ValidUpdateTitle &&
                                 m.Content == PostTestUtilities.ValidUpdateContent);
    }
}
