using InstaConnect.Common.Tests.Utilities.Assertions;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Presentation.FunctionalTests.Features.PostLikes.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.DataAttributes.Id;
using InstaConnect.Posts.Common.Tests.Features.Utilities;

namespace InstaConnect.PostLikes.Presentation.FunctionalTests.Features.PostLikes.Controllers.v1;

public class AddPostLikeFunctionalTests : BasePostLikePresentationFunctionalTest
{
    private readonly AddPostLikeApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostLikeApiRequestBuilder _requestBuilder;
    private readonly AddPostLikeApiRequest _request;

    public AddPostLikeFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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
        var response = await HttpClient.AddPostLikeStatusCodeUnauthorizedAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeUnauthorized();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedProblemDetails_WhenRequestIsUnauthorized()
    {
        // Act
        var response = await HttpClient.AddPostLikeProblemDetailsUnauthorizedAsync(_request, CancellationToken);

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
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(request, CancellationToken);

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
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(request, CancellationToken);

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
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(request, CancellationToken);

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
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNotFound(request.UserId);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostLikeAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostLikeAlreadyExistsAndIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenPostLikeAlreadyExistsAndUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Fact]
    public async Task AddAsync_ShouldHavePostLikeAlreadyExistsProblemDetails_WhenPostLikeAlreadyExists()
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);

        // Act
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostLikeAlreadyExists(_request.Id, _request.UserId);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldHavePostLikeAlreadyExistsProblemDetails_WhenPostLikeAlreadyExistsAndIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostLikeAlreadyExists(request.Id, request.UserId);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldHavePostLikeAlreadyExistsProblemDetails_WhenPostLikeAlreadyExistsAndUserIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        await ServiceScope.AddPostLikeAsync(PostLike, CancellationToken);
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostLikeProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostLikeAlreadyExists(request.Id, request.UserId);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostLikeStatusCodeAsync(_request, CancellationToken);

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
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.AddPostLikeStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostLikeAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postLike);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postLike);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);

        // Assert
        response.ShouldSatisfy(postLike);
    }

    [Fact]
    public async Task AddAsync_ShouldAddPostLike_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostLikeAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(_request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldAddPostLike_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(_request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldAddPostLike_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);

        // Assert
        postLike.ShouldSatisfy(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddPostLikeAsync(_request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostLikeAddedEventAsync(postLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Create();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostLikeAddedEventAsync(postLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task AddAsync_ShouldPublishPostLikeAddedEvent_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(_request.UserId, transformer).Create();

        // Act
        var response = await HttpClient.AddPostLikeAsync(request, CancellationToken);
        var postLike = await ServiceScope.GetPostLikeByIdAsync(response.Id, response.LikeId, CancellationToken);
        var eventWasPublished = await EventHarness.HasPublishPostLikeAddedEventAsync(postLike, CancellationToken);

        // Assert
        eventWasPublished.ShouldBeTrue();
    }
}
