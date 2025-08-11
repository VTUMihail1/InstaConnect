using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.IntegrationTests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddCommandRequest;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostLikes.Application.IntegrationTests.Features.PostLikes.Commands;

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
        _request = _requestBuilder.Create();
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
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

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
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task SendAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostNotFoundExceptionAsync(request.Id);
    }

    [Theory]
    [UserIdNotFoundData]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowUserNotFoundExceptionAsync(request.UserId);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);

        // Act
        var action = async () => await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        await action.ShouldThrowPostLikeAlreadyExistsExceptionAsync(_request.Id, _request.UserId);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExistsAndIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostLikeAlreadyExistsExceptionAsync(request.Id, request.UserId);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldThrowPostLikeAlreadyExistsException_WhenPostLikeAlreadyExistsAndUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostLikeAlreadyExistsExceptionAsync(request.Id, request.UserId);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postLike);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(User.Id, transformer).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postLike);
    }

    [Fact]
    public async Task SendAsync_ShouldAddPostLike_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldAddPostLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(_request);
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostLikeAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await ApplicationSender.SendAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostLikeAddedEventAsync(postLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostLikeAddedEvent_WhenRequestAnIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostLikeAddedEventAsync(postLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostLikeAddedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostLikeAddedEventAsync(postLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }
}
