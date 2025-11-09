namespace InstaConnect.Posts.Application.Tests.Integration.Features.Posts.Commands;

public class DeletePostIntegrationTests : BasePostApplicationIntegrationTest
{
    private readonly DeletePostCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommandRequestBuilder _requestBuilder;
    private readonly DeletePostCommandRequest _request;

    public DeletePostIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
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
    public async Task SendAsync_ShouldThrowPostForbiddenException_WhenUserIdIsInvalid()
    {
        // Arrange
        var user = UserBuilderFactory.Create().Build();
        await ServiceScope.AddUserAsync(user, CancellationToken);
        var request = _requestBuilder.WithUserId(user.Id).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostForbiddenExceptionAsync(request.Id, request.UserId);
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePost_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(_request.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePost_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(request.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePost_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var post = await ServiceScope.GetPostByIdAsync(request.Id, CancellationToken);

        // Assert
        post.ShouldBeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostDeletedEventAsync(Post, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostDeletedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostDeletedEventAsync(Post, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostDeletedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostDeletedEventAsync(Post, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }
}
