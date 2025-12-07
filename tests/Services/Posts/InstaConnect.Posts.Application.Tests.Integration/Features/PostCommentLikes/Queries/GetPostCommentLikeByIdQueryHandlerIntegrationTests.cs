namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostCommentLikes.Queries;

public class GetPostCommentLikeByIdQueryHandlerIntegrationTests : BasePostCommentLikeApplicationIntegrationTest
{
    private readonly GetPostCommentLikeByIdQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetPostCommentLikeByIdQueryRequestBuilder _requestBuilder;
    private readonly GetPostCommentLikeByIdQueryRequest _request;

    public GetPostCommentLikeByIdQueryHandlerIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
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
    public async Task SendAsync_ShouldThrowPostCommentLikeNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentLikeAsync(PostCommentLike, CancellationToken);

        // Assert
        await ApplicationSender.ShouldThrowPostCommentLikeNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostCommentLike, User);
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

        // Assert
        response.ShouldSatisfy(PostCommentLike, User);
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

        // Assert
        response.ShouldSatisfy(PostCommentLike, User);
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

        // Assert
        response.ShouldSatisfy(PostCommentLike, User);
    }
}
