namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Controllers.v1;

public class DeletePostCommentFunctionalTests : BasePostCommentPresentationFunctionalTest
{
    private readonly DeletePostCommentApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentApiRequestBuilder _requestBuilder;
    private readonly DeletePostCommentApiRequest _request;

    public DeletePostCommentFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.DeletePostCommentStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Theory]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.DeletePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.DeletePostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
    }

    [Theory]
    [PostCommentIdTooShortData]
    [PostCommentIdTooLongData]
    public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.DeletePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentIdTooShortWithMessageData]
    [PostCommentIdTooLongWithMessageData]
    public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.DeletePostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCommentId(messageTransformer, request);
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
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.DeletePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.DeletePostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.DeletePostCommentStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task DeleteAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.DeletePostCommentProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.DeletePostCommentStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task DeleteAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.DeletePostCommentProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentNotFound(_request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveForbiddenStatusCode_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithUserId(user).Build();

        // Act
        var response = await HttpClient.DeletePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeForbidden();
    }

    [Fact]
    public async Task DeleteAsync_ShouldHavePostCommentForbiddenProblemDetails_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithUserId(user).Build();

        // Act
        var response = await HttpClient.DeletePostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentForbidden(request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.DeletePostCommentStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.DeletePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.DeletePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.DeletePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePostComment_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeletePostCommentAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(PostComment.Id, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePostComment_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await HttpClient.DeletePostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(PostComment.Id, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePostComment_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        await HttpClient.DeletePostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(PostComment.Id, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePostComment_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        await HttpClient.DeletePostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(PostComment.Id, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeletePostCommentAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(PostComment, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await HttpClient.DeletePostCommentAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(PostComment, CancellationToken);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        await HttpClient.DeletePostCommentAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(PostComment, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        await HttpClient.DeletePostCommentAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(PostComment, CancellationToken);
    }
}
