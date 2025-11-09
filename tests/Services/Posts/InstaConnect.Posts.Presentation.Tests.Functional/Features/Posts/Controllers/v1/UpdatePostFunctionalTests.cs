namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Posts.Controllers.v1;

public class UpdatePostFunctionalTests : BasePostPresentationFunctionalTest
{
    private readonly UpdatePostApiRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdatePostApiRequestBuilder _requestBuilder;
    private readonly UpdatePostApiRequest _request;

    public UpdatePostFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.UpdatePostStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUnauthorizedProblemDetails_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.UpdatePostProblemDetailsUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUnauthorized();
    }

    [Theory]
    [PostIdNullData]
    [PostIdEmptyData]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
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
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostTitleNullData]
    [PostTitleEmptyData]
    [PostTitleTooShortData]
    [PostTitleTooLongData]
    public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenTitleIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(_request.Body.Title, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostTitleNullWithMessageData]
    [PostTitleEmptyWithMessageData]
    [PostTitleTooShortWithMessageData]
    [PostTitleTooLongWithMessageData]
    public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenTitleIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithTitle(_request.Body.Title, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostContentNullData]
    [PostContentEmptyData]
    [PostContentTooShortData]
    [PostContentTooLongData]
    public async Task UpdateAsync_ShouldHaveBadRequestStatusCode_WhenContentIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithContent(_request.Body.Content, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostContentNullWithMessageData]
    [PostContentEmptyWithMessageData]
    [PostContentTooShortWithMessageData]
    [PostContentTooLongWithMessageData]
    public async Task UpdateAsync_ShouldHaveBadRequestProblemDetails_WhenContentIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithContent(_request.Body.Content, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Fact]
    public async Task UpdateAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.UpdatePostStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task UpdateAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.UpdatePostProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request.Id);
    }

    [Fact]
    public async Task UpdateAsync_ShouldHaveForbiddenStatusCode_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithUserId(user.Id).Build();

        // Act
        var response = await HttpClient.UpdatePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeForbidden();
    }

    [Fact]
    public async Task UpdateAsync_ShouldHavePostForbiddenProblemDetails_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithUserId(user.Id).Build();

        // Act
        var response = await HttpClient.UpdatePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostForbidden(request.Id, request.UserId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.UpdatePostStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task UpdateAsync_ShouldHaveNoContentStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task UpdateAsync_ShouldHaveNoContentStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Fact]
    public async Task UpdateAsync_ShouldHaveResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.UpdatePostAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task UpdateAsync_ShouldHaveResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task UpdateAsync_ShouldHaveResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.UpdatePostAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdatePost_WhenRequestIsValid()
    {
        // Act
        await HttpClient.UpdatePostAsync(_request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(_request.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task UpdateAsync_ShouldUpdatePost_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await HttpClient.UpdatePostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(_request.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task UpdateAsync_ShouldUpdatePost_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        await HttpClient.UpdatePostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(_request.Id, CancellationToken);

        // Assert
        post.ShouldSatisfy(_request);
    }

    [Fact]
    public async Task UpdateAsync_ShouldPublishPostUpdatedEvent_WhenRequestIsValid()
    {
        // Act
        await HttpClient.UpdatePostAsync(_request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(_request.Id, CancellationToken);
        var hasPublished = await EventHarness.HasPublishPostUpdatedEventAsync(post, CancellationToken);

        // Assert
        hasPublished.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task UpdateAsync_ShouldPublishPostUpdatedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await HttpClient.UpdatePostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(_request.Id, CancellationToken);
        var hasPublished = await EventHarness.HasPublishPostUpdatedEventAsync(post, CancellationToken);

        // Assert
        hasPublished.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task UpdateAsync_ShouldPublishPostUpdatedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        await HttpClient.UpdatePostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(_request.Id, CancellationToken);
        var hasPublished = await EventHarness.HasPublishPostUpdatedEventAsync(post, CancellationToken);

        // Assert
        hasPublished.ShouldBeTrue();
    }
}
