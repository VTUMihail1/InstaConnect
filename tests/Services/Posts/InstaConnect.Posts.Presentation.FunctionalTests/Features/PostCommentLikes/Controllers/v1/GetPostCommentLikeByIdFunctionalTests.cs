using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.GetByIdApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.Id;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Presentation.FunctionalTests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostCommentLikes.Presentation.FunctionalTests.Features.PostCommentLikes.Controllers.v1;

public class GetPostCommentLikeByIdFunctionalTests : BasePostCommentLikePresentationFunctionalTest
{
    private readonly GetPostCommentLikeByIdApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostCommentLikeByIdApiRequestBuilder _requestBuilder;
    private readonly GetPostCommentLikeByIdApiRequest _request;

    public GetPostCommentLikeByIdFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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

    [Theory]
    [PostIdNullData]
    [PostIdEmptyData]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostCommentIdNullData]
    [PostCommentIdEmptyData]
    [PostCommentIdTooShortData]
    [PostCommentIdTooLongData]
    public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentIdNullWithMessageData]
    [PostCommentIdEmptyWithMessageData]
    [PostCommentIdTooShortWithMessageData]
    [PostCommentIdTooLongWithMessageData]
    public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostCommentLikeIdNullData]
    [PostCommentLikeIdEmptyData]
    [PostCommentLikeIdTooShortData]
    [PostCommentLikeIdTooLongData]
    public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenCommentLikeIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentLikeIdNullWithMessageData]
    [PostCommentLikeIdEmptyWithMessageData]
    [PostCommentLikeIdTooShortWithMessageData]
    [PostCommentLikeIdTooLongWithMessageData]
    public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCommentLikeIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task GetByIdAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(request.Id);
    }

    [Theory]
    [PostCommentIdNotFoundData]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenCommentIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Theory]
    [PostCommentIdNotFoundData]
    public async Task GetByIdAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenCommentIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(request.CommentId);
    }

    [Theory]
    [PostCommentLikeIdNotFoundData]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenCommentLikeIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Theory]
    [PostCommentLikeIdNotFoundData]
    public async Task GetByIdAsync_ShouldHavePostCommentLikeNotFoundProblemDetails_WhenCommentLikeIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentLikeNotFound(request.Id, request.CommentId, request.CommentLikeId);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostCommentLikeIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCommentLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetPostCommentLikeByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User);
    }

    [Theory]
    [PostCommentLikeIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndCommentLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User);
    }
}
