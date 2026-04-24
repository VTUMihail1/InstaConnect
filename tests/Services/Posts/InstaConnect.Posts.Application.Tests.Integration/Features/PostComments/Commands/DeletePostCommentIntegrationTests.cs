namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Commands;

public class DeletePostCommentIntegrationTests : BasePostCommentApplicationCommandIntegrationTest
{
    private readonly DeletePostCommentCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentCommandRequestBuilder _requestBuilder;
    private readonly DeletePostCommentCommandRequest _request;

    public DeletePostCommentIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
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
        await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(
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
        await Sender.ShouldThrowInvalidValidationExceptionForCommentIdAsync(
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
        await Sender.ShouldThrowInvalidValidationExceptionForUserIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Assert
        await Sender.ShouldThrowPostNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentNotFoundException_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Assert
        await Sender.ShouldThrowPostCommentNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentForbiddenException_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithUserId(user.Id).Build();

        // Assert
        await Sender.ShouldThrowPostCommentForbiddenExceptionAsync(request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostComment_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(PostComment.Id, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostComment_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(PostComment.Id, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostComment_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(PostComment.Id, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostComment_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(PostComment.Id, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedPostCommentDeletedAsync(PostComment, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedPostCommentDeletedAsync(PostComment, CancellationToken);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedPostCommentDeletedAsync(PostComment, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedPostCommentDeletedAsync(PostComment, CancellationToken);
    }
}
