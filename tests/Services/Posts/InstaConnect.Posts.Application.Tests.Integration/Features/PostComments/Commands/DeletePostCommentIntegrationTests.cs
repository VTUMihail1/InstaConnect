namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Commands;

public class DeletePostCommentIntegrationTests : BasePostCommentApplicationIntegrationTest
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
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostCommentIdNullWithMessageData]
    [PostCommentIdEmptyWithMessageData]
    [PostCommentIdTooShortWithMessageData]
    [PostCommentIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenCommentIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var action = async () => await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        await action.ShouldThrowPostNotFoundExceptionAsync(_request.Id);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentNotFoundException_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var action = async () => await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        await action.ShouldThrowPostCommentNotFoundExceptionAsync(_request.Id, _request.CommentId);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentForbiddenException_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithUserId(user.Id).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostCommentForbiddenExceptionAsync(request.Id, request.CommentId, request.UserId);
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostComment_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(_request.Id, _request.CommentId, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostComment_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(request.Id, request.CommentId, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostComment_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(request.Id, request.CommentId, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostComment_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(request.Id, request.CommentId, CancellationToken);

        // Assert
        postComment.ShouldBeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentDeletedEventAsync(PostComment, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentDeletedEventAsync(PostComment, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentDeletedEventAsync(PostComment, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentDeletedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentDeletedEventAsync(PostComment, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }
}
