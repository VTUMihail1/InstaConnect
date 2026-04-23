using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostComments.Commands;

public class AddPostCommentIntegrationTests : BasePostCommentApplicationCommandIntegrationTest
{
    private readonly AddPostCommentCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommentCommandRequestBuilder _requestBuilder;
    private readonly AddPostCommentCommandRequest _request;

    public AddPostCommentIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
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
        await Sender.ShouldThrowInvalidValidationExceptionForContentAsync(
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
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Assert
        await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postComment, _request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postComment, request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postComment, request);
    }

    [Fact]
    public async Task SendAsync_ShouldAddPostComment_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostComment_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostComment_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(request);
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostCommentAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedPostCommentAddedAsync(postComment, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentAddedEvent_WhenRequestAnIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedPostCommentAddedAsync(postComment, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentAddedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedPostCommentAddedAsync(postComment, CancellationToken);
    }
}
