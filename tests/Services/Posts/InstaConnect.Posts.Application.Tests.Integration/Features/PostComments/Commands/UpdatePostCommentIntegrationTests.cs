namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Commands;

public class UpdatePostCommentIntegrationTests : BasePostCommentApplicationIntegrationTest
{
    private readonly UpdatePostCommentCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdatePostCommentCommandRequestBuilder _requestBuilder;
    private readonly UpdatePostCommentCommandRequest _request;

    public UpdatePostCommentIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
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

    [Theory]
    [PostCommentContentNullWithMessageData]
    [PostCommentContentEmptyWithMessageData]
    [PostCommentContentTooShortWithMessageData]
    [PostCommentContentTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenContentIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithContent(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowInvalidValidationExceptionForContentAsync(
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
    public async Task SendAsync_ShouldThrowPostCommentForbiddenException_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);

        var request = _requestBuilder.WithUserId(user).Build();

        // Assert
        await ApplicationSender.ShouldThrowPostCommentForbiddenExceptionAsync(request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postComment);
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
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postComment);
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
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postComment);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(User, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postComment);
    }

    [Fact]
    public async Task SendAsync_ShouldUpdatePostComment_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdatePostComment_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdatePostComment_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldUpdatePostComment_WhenRequestAndUserIdAreValids(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(User, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostCommentUpdatedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUpdatedAsync(postComment, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentUpdatedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUpdatedAsync(postComment, CancellationToken);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentUpdatedEvent_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUpdatedAsync(postComment, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishUpdatedEvent_WhenRequestAndUserIdAreValids(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(User, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedUpdatedAsync(postComment, CancellationToken);
    }
}
