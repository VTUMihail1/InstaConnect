namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.Posts.Controllers.v1;

public class DeletePostFunctionalTests : BasePostPresentationFunctionalTest
{
    private readonly DeletePostApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostApiRequestBuilder _requestBuilder;
    private readonly DeletePostApiRequest _request;

    public DeletePostFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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
    public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.DeletePostStatusCodeUnauthorizedAsync(_request, CancellationToken);

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
        var response = await HttpClient.DeletePostStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.DeletePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
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
        var response = await HttpClient.DeletePostStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.DeletePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.DeletePostStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task DeleteAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.DeletePostProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveForbiddenStatusCode_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithUserId(user).Build();

        // Act
        var response = await HttpClient.DeletePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeForbidden();
    }

    [Fact]
    public async Task DeleteAsync_ShouldHavePostForbiddenProblemDetails_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithUserId(user).Build();

        // Act
        var response = await HttpClient.DeletePostProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostForbidden(request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.DeletePostStatusCodeAsync(_request, CancellationToken);

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
        var response = await HttpClient.DeletePostStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.DeletePostStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePost_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeletePostAsync(_request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(Post.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePost_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await HttpClient.DeletePostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(Post.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePost_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        await HttpClient.DeletePostAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(Post.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldPublishPostDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeletePostAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(Post, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishPostDeletedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await HttpClient.DeletePostAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(Post, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishPostDeletedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        await HttpClient.DeletePostAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(Post, CancellationToken);
    }
}
