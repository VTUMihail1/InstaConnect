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
        _requestBuilder = _requestBuilderFactory.Create(Post, PostComment, User);
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
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var action = async () => await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        await action.ShouldThrowPostCommentNotFoundExceptionAsync(_request.Id, _request.CommentId);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var action = async () => await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        await action.ShouldThrowUserNotFoundExceptionAsync(_request.UserId);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);

        // Act
        var action = async () => await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        await action.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(_request.Id, _request.CommentId, _request.UserId);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(request.Id, request.CommentId, request.UserId);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndCommentIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(request.Id, request.CommentId, request.UserId);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(request.Id, request.CommentId, request.UserId);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Fact]
    public async Task SendAsync_ShouldAddPostCommentLike_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostCommentLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(_request);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostCommentLike_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostCommentLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(_request);
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostCommentLikeAddedEventAsync(postCommentLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAnIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostCommentLikeAddedEventAsync(postCommentLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAnCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostCommentLikeAddedEventAsync(postCommentLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.UserId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostCommentLikeAddedEventAsync(postCommentLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }
}
