namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Commands;

public class DeletePostLikeIntegrationTests : BasePostLikeApplicationIntegrationTest
{
    private readonly DeletePostLikeCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostLikeCommandRequestBuilder _requestBuilder;
    private readonly DeletePostLikeCommandRequest _request;

    public DeletePostLikeIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
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
    public async Task SendAsync_ShouldThrowPostLikeNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostLikeAsync(PostLike, CancellationToken);

        // Assert
        await ApplicationSender.ShouldThrowPostLikeNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostLike_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(PostLike.Id, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(PostLike.Id, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(PostLike.Id, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(PostLike, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(PostLike, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedDeletedAsync(PostLike, CancellationToken);
    }
}
