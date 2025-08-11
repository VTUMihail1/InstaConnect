using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Content;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Id;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Presentation.FunctionalTests.Features.PostComments.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostComments.Presentation.FunctionalTests.Features.PostComments.Controllers.v1;

public class AddPostCommentFunctionalTests : BasePostCommentPresentationFunctionalTest
{
    private readonly AddPostCommentApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommentApiRequestBuilder _requestBuilder;
    private readonly AddPostCommentApiRequest _request;

    public AddPostCommentFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddPostCommentStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedProblemDetails_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddPostCommentProblemDetailsUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUnauthorized();
    }

    [Theory]
    [PostIdNullData]
    [PostIdEmptyData]
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdNullWithMessageData]
    [PostIdEmptyWithMessageData]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostCommentContentNullData]
    [PostCommentContentEmptyData]
    [PostCommentContentTooShortData]
    [PostCommentContentTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenContentIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithContent(_request.Body.Content, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentContentNullWithMessageData]
    [PostCommentContentEmptyWithMessageData]
    [PostCommentContentTooShortWithMessageData]
    [PostCommentContentTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenContentIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithContent(_request.Body.Content, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Theory]
    [PostIdNotFoundData]
    public async Task AddAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(request.Id);
    }

    [Theory]
    [UserIdNotFoundData]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Theory]
    [UserIdNotFoundData]
    public async Task AddAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNotFound(request.UserId);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostCommentStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostCommentAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Id, response.CommentId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postComment);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Id, response.CommentId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postComment);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Id, response.CommentId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postComment);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPostComment_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostCommentAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Id, response.CommentId, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldAddPostComment_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Id, response.CommentId, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldAddPostComment_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Id, response.CommentId, CancellationToken);

        // Assert
        postComment.ShouldSatisfy(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldPublishPostCommentAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostCommentAsync(_request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Id, response.CommentId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostCommentAddedEventAsync(postComment, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishPostCommentAddedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Id, response.CommentId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostCommentAddedEventAsync(postComment, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishPostCommentAddedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostCommentAsync(request, CancellationToken);
        var postComment = await ServiceScope.GetPostCommentByIdAsync(response.Id, response.CommentId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostCommentAddedEventAsync(postComment, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }
}
