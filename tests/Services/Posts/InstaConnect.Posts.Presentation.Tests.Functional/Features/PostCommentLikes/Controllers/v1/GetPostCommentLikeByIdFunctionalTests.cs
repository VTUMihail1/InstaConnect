namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostCommentLikes.Controllers.v1;

public class GetPostCommentLikeByIdFunctionalTests : BasePostCommentLikePresentationQueryFunctionalTest
{
    private readonly GetPostCommentLikeByIdApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostCommentLikeByIdApiRequestBuilder _requestBuilder;
    private readonly GetPostCommentLikeByIdApiRequest _request;

    public GetPostCommentLikeByIdFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
    }

    [Theory]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
    }

    [Theory]
    [PostCommentIdTooShortData]
    [PostCommentIdTooLongData]
    public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentIdTooShortWithMessageData]
    [PostCommentIdTooLongWithMessageData]
    public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCommentId(messageTransformer, request);
    }

    [Theory]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentNotFound(_request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentLikeAsync(PostCommentLike, CancellationToken);

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHavePostCommentLikeNotFoundProblemDetails_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentLikeAsync(PostCommentLike, CancellationToken);

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentLikeNotFound(_request);
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
        var request = _requestBuilder.WithId(transformer).Build();

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
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

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
        response.ShouldSatisfy(PostCommentLike, _request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, request);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentLikeByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, request);
    }
}
