namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostCommentLikes.Commands;

public class AddPostCommentLikeIntegrationTests : BasePostCommentLikeApplicationIntegrationTest
{
    private readonly AddPostCommentLikeCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommentLikeCommandRequestBuilder _requestBuilder;
    private readonly AddPostCommentLikeCommandRequest _request;

    public AddPostCommentLikeIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment, User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [PostCommentIdNullWithMessageData]
    [PostCommentIdEmptyWithMessageData]
    [PostCommentIdTooShortWithMessageData]
    [PostCommentIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenCommentIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForCommentIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForUserIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Assert
        await ApplicationSender.ShouldThrowPostNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentNotFoundException_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Assert
        await ApplicationSender.ShouldThrowPostCommentNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Assert
        await ApplicationSender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);

        // Assert
        await ApplicationSender.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(_request, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithId(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(request, CancellationToken);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndCommentIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(request, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Fact]
    public async Task SendAsync_ShouldAddPostCommentLike_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostCommentLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(request);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostCommentLike_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostCommentLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(request);
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(postCommentLike, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAnIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(postCommentLike, CancellationToken);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAnCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(postCommentLike, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(postCommentLike, CancellationToken);
    }
}
