namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Controllers.v1;

public class DeletePostLikeFunctionalTests : BasePostLikePresentationCommandFunctionalTest
{
    private readonly DeletePostLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostLikeApiRequestBuilder _requestBuilder;
    private readonly DeletePostLikeApiRequest _request;

    public DeletePostLikeFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.DeletePostLikeStatusCodeUnauthorizedAsync(_request, CancellationToken);

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
        var response = await HttpClient.DeletePostLikeStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.DeletePostLikeProblemDetailsAsync(request, CancellationToken);

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
        var response = await HttpClient.DeletePostLikeStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.DeletePostLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.DeletePostLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task DeleteAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.DeletePostLikeProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostLikeAsync(PostLike, CancellationToken);

        // Act
        var response = await HttpClient.DeletePostLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task DeleteAsync_ShouldHavePostLikeNotFoundProblemDetails_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostLikeAsync(PostLike, CancellationToken);

        // Act
        var response = await HttpClient.DeletePostLikeProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostLikeNotFound(_request);
    }

    [Fact]
    public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.DeletePostLikeStatusCodeAsync(_request, CancellationToken);

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
        var response = await HttpClient.DeletePostLikeStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.DeletePostLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeletePostLike_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeletePostLikeAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(PostLike.Id, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePostLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await HttpClient.DeletePostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(PostLike.Id, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldDeletePostLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        await HttpClient.DeletePostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(PostLike.Id, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await HttpClient.DeletePostLikeAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(PostLike, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await HttpClient.DeletePostLikeAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(PostLike, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task DeleteAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        await HttpClient.DeletePostLikeAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(PostLike, CancellationToken);
    }
}
