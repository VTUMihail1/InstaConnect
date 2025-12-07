namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Controllers.v1;

public class UpdatePostCommentFunctionalTests : BasePostCommentPresentationFunctionalTest
{
    private readonly UpdatePostCommentApiRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdatePostCommentApiRequestBuilder _requestBuilder;
    private readonly UpdatePostCommentApiRequest _request;

    public UpdatePostCommentFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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
    public async Task UpdateAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Theory]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
    }

    [Theory]
    [PostCommentIdTooShortData]
    [PostCommentIdTooLongData]
    public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentIdTooShortWithMessageData]
    [PostCommentIdTooLongWithMessageData]
    public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCommentId(messageTransformer, request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
    }

    [Theory]
    [PostCommentContentNullData]
    [PostCommentContentEmptyData]
    [PostCommentContentTooShortData]
    [PostCommentContentTooLongData]
    public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenContentIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithContent(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentContentNullWithMessageData]
    [PostCommentContentEmptyWithMessageData]
    [PostCommentContentTooShortWithMessageData]
    [PostCommentContentTooLongWithMessageData]
    public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenContentIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithContent(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForContent(messageTransformer, request);
    }

    [Fact]
    public async Task UpdateAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task UpdateAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.UpdatePostCommentProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request);
    }

    [Fact]
    public async Task UpdateAsync_ShouldHaveNotFoundStatusCode_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task UpdateAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.UpdatePostCommentProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentNotFound(_request);
    }

    [Fact]
    public async Task UpdateAsync_ShouldHaveForbiddenStatusCode_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithUserId(user).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeForbidden();
    }

    [Fact]
    public async Task UpdateAsync_ShouldHavePostCommentForbiddenProblemDetails_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithUserId(user).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentForbidden(request);
    }

    [Fact]
    public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task UpdateAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task UpdateAsync_ShouldHaveResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.UpdatePostCommentAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task UpdateAsync_ShouldHaveResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task UpdateAsync_ShouldHaveResponse_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task UpdateAsync_ShouldHaveResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.UpdatePostCommentAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task UpdateAsync_ShouldUpdatePostComment_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Fact]
    public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.UpdatePostCommentAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUpdatedAsync(postComment, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUpdatedAsync(postComment, CancellationToken);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUpdatedAsync(postComment, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUpdatedAsync(postComment, CancellationToken);
    }
}
