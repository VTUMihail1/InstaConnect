namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Posts.Controllers.v1;

public class AddPostFunctionalTests : BasePostPresentationFunctionalTest
{
    private readonly AddPostApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostApiRequestBuilder _requestBuilder;
    private readonly AddPostApiRequest _request;

    public AddPostFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddPostStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
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
        var response = await HttpClient.AddPostStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.AddPostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
    }

    [Theory]
    [PostTitleNullData]
    [PostTitleEmptyData]
    [PostTitleTooShortData]
    [PostTitleTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenTitleIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(transformer).Build();

        // Act
        var response = await HttpClient.AddPostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostTitleNullWithMessageData]
    [PostTitleEmptyWithMessageData]
    [PostTitleTooShortWithMessageData]
    [PostTitleTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenTitleIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(transformer).Build();

        // Act
        var response = await HttpClient.AddPostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForTitle(messageTransformer, request);
    }

    [Theory]
    [PostContentNullData]
    [PostContentEmptyData]
    [PostContentTooShortData]
    [PostContentTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenContentIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithContent(transformer).Build();

        // Act
        var response = await HttpClient.AddPostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostContentNullWithMessageData]
    [PostContentEmptyWithMessageData]
    [PostContentTooShortWithMessageData]
    [PostContentTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenContentIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithContent(transformer).Build();

        // Act
        var response = await HttpClient.AddPostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForContent(messageTransformer, request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddPostStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddPostProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNotFound(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostStatusCodeAsync(_request, CancellationToken);

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
        var response = await HttpClient.AddPostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostAsync(_request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(post);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(post);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPost_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostAsync(_request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

        // Assert
        post.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldAddPost_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

        // Assert
        post.ShouldSatisfy(request);
    }

    [Fact]
    public async Task AddAsync_ShouldPublishPostAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostAsync(_request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(post, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishPostAddedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.AddPostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(post, CancellationToken);
    }
}
