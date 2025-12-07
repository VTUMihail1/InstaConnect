namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Controllers.v1;

public class GetPostCommentByIdFunctionalTests : BasePostCommentPresentationFunctionalTest
{
    private readonly GetPostCommentByIdApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostCommentByIdApiRequestBuilder _requestBuilder;
    private readonly GetPostCommentByIdApiRequest _request;

    public GetPostCommentByIdFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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

    [Theory]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentByIdStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetPostCommentByIdProblemDetailsAsync(request, CancellationToken);

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
        var response = await HttpClient.GetPostCommentByIdStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetPostCommentByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCommentId(messageTransformer, request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetPostCommentByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetPostCommentByIdProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.GetPostCommentByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.GetPostCommentByIdProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentNotFound(_request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetPostCommentByIdStatusCodeAsync(_request, CancellationToken);

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
        var response = await HttpClient.GetPostCommentByIdStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetPostCommentByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetPostCommentByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostCommentByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostComment, User);
    }
}
