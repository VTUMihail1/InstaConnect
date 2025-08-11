using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Application.IntegrationTests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostLikes.Application.IntegrationTests.Features.PostLikes.Commands;

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
        _request = _requestBuilder.Create();
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
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostLikeIdNullWithMessageData]
    [PostLikeIdEmptyWithMessageData]
    [PostLikeIdTooShortWithMessageData]
    [PostLikeIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenLikeIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

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
    [PostLikeIdNotFoundData]
    public async Task SendAsync_ShouldThrowPostLikeNotFoundException_WhenLikeIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostLikeNotFoundExceptionAsync(request.Id, request.LikeId);
    }

    [Theory]
    [UserIdNotFoundData]
    public async Task SendAsync_ShouldThrowPostLikeForbiddenException_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostLikeForbiddenExceptionAsync(request.Id, request.LikeId, request.UserId);
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostLike_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(_request.Id, _request.LikeId, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(request.Id, request.LikeId, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Theory]
    [PostLikeIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostLike_WhenRequestAndLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(request.Id, request.LikeId, CancellationToken);

        // Assert
        postLike.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(request.Id, request.LikeId, CancellationToken);

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
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostLikeDeletedEventAsync(PostLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostLikeIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostLikeDeletedEvent_WhenRequestAndLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLikeId(_request.LikeId, transformer).Create();

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
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostLikeDeletedEventAsync(PostLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }
}
