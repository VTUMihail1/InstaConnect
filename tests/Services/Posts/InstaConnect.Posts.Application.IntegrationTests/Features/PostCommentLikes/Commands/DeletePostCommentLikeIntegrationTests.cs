using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.PostCommentLikes.Application.IntegrationTests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.DeleteCommandRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.Id;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostCommentLikes.Application.IntegrationTests.Features.PostCommentLikes.Commands;

public class DeletePostCommentLikeIntegrationTests : BasePostCommentLikeApplicationIntegrationTest
{
    private readonly DeletePostCommentLikeCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentLikeCommandRequestBuilder _requestBuilder;
    private readonly DeletePostCommentLikeCommandRequest _request;

    public DeletePostCommentLikeIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Create();
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
    [PostCommentIdNullWithMessageData]
    [PostCommentIdEmptyWithMessageData]
    [PostCommentIdTooShortWithMessageData]
    [PostCommentIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenCommentIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Theory]
    [PostCommentLikeIdNullWithMessageData]
    [PostCommentLikeIdEmptyWithMessageData]
    [PostCommentLikeIdTooShortWithMessageData]
    [PostCommentLikeIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenCommentLikeIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

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
    [PostCommentIdNotFoundData]
    public async Task SendAsync_ShouldThrowPostCommentNotFoundException_WhenCommentIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostCommentNotFoundExceptionAsync(request.Id, request.CommentId);
    }

    [Theory]
    [PostCommentLikeIdNotFoundData]
    public async Task SendAsync_ShouldThrowPostCommentLikeNotFoundException_WhenCommentLikeIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostCommentLikeNotFoundExceptionAsync(request.Id, request.CommentId, request.CommentLikeId);
    }

    [Theory]
    [UserIdNotFoundData]
    public async Task SendAsync_ShouldThrowPostCommentLikeForbiddenException_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowPostCommentLikeForbiddenExceptionAsync(request.Id, request.CommentId, request.CommentLikeId, request.UserId);
    }

    [Fact]
    public async Task SendAsync_ShouldDeletePostCommentLike_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(_request.Id, _request.CommentId, _request.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldBeNull();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostCommentLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(_request.Id, _request.CommentId, _request.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldBeNull();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostCommentLike_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(_request.Id, _request.CommentId, _request.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldBeNull();
    }

    [Theory]
    [PostCommentLikeIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostCommentLike_WhenRequestAndCommentLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(_request.Id, _request.CommentId, _request.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeletePostCommentLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(_request.Id, _request.CommentId, _request.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldBeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentLikeDeletedEventAsync(PostCommentLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentLikeDeletedEventAsync(PostCommentLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentLikeDeletedEventAsync(PostCommentLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [PostCommentLikeIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndCommentLikeIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentLikeId(_request.CommentLikeId, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentLikeDeletedEventAsync(PostCommentLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var hasPublshed = await EventHarness.HasPublishPostCommentLikeDeletedEventAsync(PostCommentLike, CancellationToken);

        // Assert
        hasPublshed.ShouldBeTrue();
    }
}
