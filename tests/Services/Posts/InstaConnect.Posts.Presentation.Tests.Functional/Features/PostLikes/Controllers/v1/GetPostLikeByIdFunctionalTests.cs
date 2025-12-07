namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Controllers.v1;

public class GetPostLikeByIdFunctionalTests : BasePostLikePresentationFunctionalTest
{
    private readonly GetPostLikeByIdApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostLikeByIdApiRequestBuilder _requestBuilder;
    private readonly GetPostLikeByIdApiRequest _request;

    public GetPostLikeByIdFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
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
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetPostLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
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
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetPostLikeByIdProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetPostLikeByIdProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostLikeAsync(PostLike, CancellationToken);

        // Act
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHavePostLikeNotFoundProblemDetails_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostLikeAsync(PostLike, CancellationToken);

        // Act
        var response = await HttpClient.GetPostLikeByIdProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostLikeNotFound(_request);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(_request, CancellationToken);

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
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetPostLikeByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetPostLikeByIdAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostLikeByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetPostLikeByIdAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, User);
    }
}
