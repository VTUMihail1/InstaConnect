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
    public async Task SendAsync_ShouldThrowPostLikeNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostLikeAsync(PostLike, CancellationToken);

        // Act
        var action = async () => await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        await action.ShouldThrowPostLikeNotFoundExceptionAsync(_request.Id, _request.UserId);
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostLike_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(_request.Id, _request.UserId, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(request.Id, request.UserId, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(request.Id, request.UserId, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostLikeDeletedEventAsync(PostLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostLikeDeletedEventAsync(PostLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostLikeDeletedEventAsync(PostLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }
}
