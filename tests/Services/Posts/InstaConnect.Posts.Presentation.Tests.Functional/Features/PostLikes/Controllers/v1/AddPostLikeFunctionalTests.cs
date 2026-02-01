namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Controllers.v1;

public class AddPostLikeFunctionalTests : BasePostLikePresentationCommandFunctionalTest
{
    private readonly AddPostLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostLikeApiRequestBuilder _requestBuilder;
    private readonly AddPostLikeApiRequest _request;

    public AddPostLikeFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddPostLikeStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Theory]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNotFound(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostLikeAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostLikeAlreadyExistsAndIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostLikeAlreadyExistsAndUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Fact]
    public async Task AddAsync_ShouldHavePostLikeAlreadyExistsProblemDetails_WhenPostLikeAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);

        // Act
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostLikeAlreadyExists(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldHavePostLikeAlreadyExistsProblemDetails_WhenPostLikeAlreadyExistsAndIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostLikeAlreadyExists(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHavePostLikeAlreadyExistsProblemDetails_WhenPostLikeAlreadyExistsAndUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostLikeAlreadyExists(request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostLikeAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(postLike, _request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(postLike, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, CancellationToken);

        // Assert
        response.ShouldSatisfy(postLike, request);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPostLike_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostLikeAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldAddPostLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldAddPostLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(request);
    }

    [Fact]
    public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostLikeAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(postLike, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(postLike, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(postLike, CancellationToken);
    }
}
