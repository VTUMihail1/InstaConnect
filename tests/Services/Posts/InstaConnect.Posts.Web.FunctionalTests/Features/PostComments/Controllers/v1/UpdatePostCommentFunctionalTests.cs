using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using Bogus;
using FluentAssertions;
using InstaConnect.Posts.Business.Features.PostComments.Utilities;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Web.Features.PostComments.Models.Binding;
using InstaConnect.Posts.Web.Features.PostComments.Models.Responses;
using InstaConnect.Posts.Web.FunctionalTests.Features.PostComments.Utilities;
using InstaConnect.Posts.Web.FunctionalTests.Utilities;

namespace InstaConnect.Posts.Web.FunctionalTests.Features.PostComments.Controllers.v1;

public class UpdatePostCommentFunctionalTests : BasePostCommentFunctionalTest
{
    public UpdatePostCommentFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(ValidUpdateContent);

        // Act
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostCommentId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(PostCommentBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenIdIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(Faker.Random.AlphaNumeric(length)),
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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(null!);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostCommentId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(Faker.Random.AlphaNumeric(length));

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostCommentId),
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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostCommentId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(PostCommentBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task UpdateAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = Faker.Random.AlphaNumeric(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostCommentId),
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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(InvalidId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnThePostCommentIdInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostCommentUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingPostCommentUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostCommentId),
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
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostCommentId),
            request,
            CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnPostCommentViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostCommentId),
            request,
            CancellationToken);

        // Assert
        var postCommentViewResponse = await response
            .Content
            .ReadFromJsonAsync<PostCommentCommandResponse>();

        postCommentViewResponse
            .Should()
            .Match<PostCommentCommandResponse>(m => m.Id == existingPostCommentId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(existingPostCommentId),
            request,
            CancellationToken);

        var postComment = await PostCommentWriteRepository.GetByIdAsync(existingPostCommentId, CancellationToken);

        // Arrange
        postComment
            .Should()
            .Match<PostComment>(m => m.Id == existingPostCommentId &&
                                 m.UserId == existingUserId &&
                                 m.PostId == existingPostId &&
                                 m.Content == ValidUpdateContent);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var existingPostId = await CreatePostAsync(existingUserId, CancellationToken);
        var existingPostCommentId = await CreatePostCommentAsync(existingUserId, existingPostId, CancellationToken);
        var request = new UpdatePostCommentBindingModel(ValidUpdateContent);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PutAsJsonAsync(
            GetIdRoute(GetNonCaseMatchingString(existingPostCommentId)),
            request,
            CancellationToken);

        var postComment = await PostCommentWriteRepository.GetByIdAsync(existingPostCommentId, CancellationToken);

        // Arrange
        postComment
            .Should()
            .Match<PostComment>(m => m.Id == existingPostCommentId &&
                                 m.UserId == existingUserId &&
                                 m.PostId == existingPostId &&
                                 m.Content == ValidUpdateContent);
    }
}
