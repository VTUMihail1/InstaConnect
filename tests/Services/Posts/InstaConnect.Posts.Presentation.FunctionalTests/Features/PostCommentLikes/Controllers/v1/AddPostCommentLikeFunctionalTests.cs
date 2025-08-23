using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Presentation.FunctionalTests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Assertions;
using InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostCommentLikes.Presentation.FunctionalTests.Features.PostCommentLikes.Controllers.v1;

public class AddPostCommentLikeFunctionalTests : BasePostCommentLikePresentationFunctionalTest
{
    private readonly AddPostCommentLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommentLikeApiRequestBuilder _requestBuilder;
    private readonly AddPostCommentLikeApiRequest _request;

    public AddPostCommentLikeFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, PostComment, User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddPostAsync(Post, CancellationToken);
        await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedProblemDetails_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddPostCommentLikeProblemDetailsUnauthorizedAsync(_request, CancellationToken);

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
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

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
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Theory]
    [PostCommentIdNullData]
    [PostCommentIdEmptyData]
    [PostCommentIdTooShortData]
    [PostCommentIdTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenCommentIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentIdNullWithMessageData]
    [PostCommentIdEmptyWithMessageData]
    [PostCommentIdTooShortWithMessageData]
    [PostCommentIdTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenCommentIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

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
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

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
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyBadRequest(errorMessage);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request.Id);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHavePostCommentNotFoundProblemDetails_WhenCommentIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

        // Act
        var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentNotFound(_request.Id, _request.CommentId);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNotFound(_request.UserId);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExistsAndIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExistsAndCommentIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostCommentLikeAlreadyExistsAndUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Fact]
    public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);

        // Act
        var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentLikeAlreadyExists(_request.Id, _request.CommentId, _request.UserId);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExistsAndIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentLikeAlreadyExists(request.Id, request.CommentId, request.UserId);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExistsAndCommentIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentLikeAlreadyExists(request.Id, request.CommentId, request.UserId);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHavePostCommentLikeAlreadyExistsProblemDetails_WhenPostCommentLikeAlreadyExistsAndUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostCommentLikeAlreadyExists(request.Id, request.CommentId, request.UserId);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(_request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postCommentLike);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(_request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(_request);
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldAddPostCommentLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);

        // Assert
        postCommentLike.ShouldSatisfy(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(_request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostCommentLikeAddedEventAsync(postCommentLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostCommentLikeAddedEventAsync(postCommentLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [PostCommentIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAndCommentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCommentId(_request.CommentId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostCommentLikeAddedEventAsync(postCommentLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Build();

        // Act
        var response = await HttpClient.AddPostCommentLikeAsync(request, CancellationToken);
        var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response.Id, response.CommentId, response.CommentLikeId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostCommentLikeAddedEventAsync(postCommentLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }
}
