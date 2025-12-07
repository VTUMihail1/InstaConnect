namespace InstaConnect.Posts.Application.Tests.Integration.Features.PostLikes.Commands;

public class AddPostLikeIntegrationTests : BasePostLikeApplicationIntegrationTest
{
    private readonly AddPostLikeCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostLikeCommandRequestBuilder _requestBuilder;
    private readonly AddPostLikeCommandRequest _request;

    public AddPostLikeIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
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
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Assert
        await ApplicationSender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);

        // Assert
        await ApplicationSender.ShouldThrowPostLikeAlreadyExistsExceptionAsync(_request, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExistsAndIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithId(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowPostLikeAlreadyExistsExceptionAsync(request, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExistsAndUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Assert
        await ApplicationSender.ShouldThrowPostLikeAlreadyExistsExceptionAsync(request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postLike);
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
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postLike);
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
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        response.ShouldSatisfy(postLike);
    }

    [Fact]
    public async Task SendAsync_ShouldAddPostLike_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(request);
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostLikeAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(postLike, CancellationToken);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostLikeAddedEvent_WhenRequestAnIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(postLike, CancellationToken);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostLikeAddedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Response, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedAddedAsync(postLike, CancellationToken);
    }
}
