using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.DeleteApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.Id;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Presentation.FunctionalTests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostCommentLikes.Presentation.FunctionalTests.Features.PostCommentLikes.Controllers.v1;

public class DeletePostCommentLikeFunctionalTests : BasePostCommentLikePresentationFunctionalTest
{
    private readonly DeletePostCommentLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentLikeApiRequestBuilder _requestBuilder;
    private readonly DeletePostCommentLikeApiRequest _request;

    public DeletePostCommentLikeFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Create();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedProblemDetails_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.DeletePostCommentLikeProblemDetailsUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUnauthorized();
    }

    [Theory]
    [PostIdNullData]
    [PostIdEmptyData]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostCommentIdNullData]
    [PostCommentIdEmptyData]
    [PostCommentIdTooShortData]
    [PostCommentIdTooLongData]
    public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentIdNullWithMessageData]
    [PostCommentIdEmptyWithMessageData]
    [PostCommentIdTooShortWithMessageData]
    [PostCommentIdTooLongWithMessageData]
    public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostCommentLikeIdNullData]
    [PostCommentLikeIdEmptyData]
    [PostCommentLikeIdTooShortData]
    [PostCommentLikeIdTooLongData]
    public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenCommentLikeIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentLikeIdNullWithMessageData]
    [PostCommentLikeIdEmptyWithMessageData]
    [PostCommentLikeIdTooShortWithMessageData]
    [PostCommentLikeIdTooLongWithMessageData]
    public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenCommentLikeIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task DeleteAsync_ShouldHavePostCommentLikeNotFoundProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(request.Id);
    }

    [Theory]
    [PostCommentIdNotFoundData]
    public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenCommentLikeIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Theory]
    [PostCommentIdNotFoundData]
    public async Task DeleteAsync_ShouldHavePostCommentLikeNotFoundProblemDetails_WhenCommentLikeIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentNotFound(request.Id, request.CommentLikeId);
    }

    [Theory]
    [UserIdNotFoundData]
    public async Task DeleteAsync_ShouldHaveForbiddenStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeForbidden();
    }

    [Theory]
    [UserIdNotFoundData]
    public async Task DeleteAsync_ShouldHavePostCommentLikeForbiddenProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentLikeForbidden(request.Id, request.CommentId, request.CommentLikeId, request.UserId);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [PostCommentLikeIdDifferentCaseData]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndCommentLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.DeletePostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeletePostCommentLikeAsync(_request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(_request.Id, _request.CommentId, _request.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        await HttpClient.DeletePostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(_request.Id, _request.CommentId, _request.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldBeNull();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        await HttpClient.DeletePostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(_request.Id, _request.CommentId, _request.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldBeNull();
    }

    [Theory]
    [PostCommentLikeIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenRequestAndCommentLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        await HttpClient.DeletePostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(_request.Id, _request.CommentId, _request.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        await HttpClient.DeletePostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(_request.Id, _request.CommentId, _request.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldBeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeletePostCommentLikeAsync(_request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentLikeDeletedEventAsync(PostCommentLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        await HttpClient.DeletePostCommentLikeAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentLikeDeletedEventAsync(PostCommentLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        await HttpClient.DeletePostCommentLikeAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentLikeDeletedEventAsync(PostCommentLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostCommentLikeIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndCommentLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        await HttpClient.DeletePostCommentLikeAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentLikeDeletedEventAsync(PostCommentLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        await HttpClient.DeletePostCommentLikeAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentLikeDeletedEventAsync(PostCommentLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }
}
