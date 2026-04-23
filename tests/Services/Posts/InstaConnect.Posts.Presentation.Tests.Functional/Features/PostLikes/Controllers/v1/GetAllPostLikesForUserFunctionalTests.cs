using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Tests.Features.Common.Utilities;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostLikes.Controllers.v1;

public class GetAllPostLikesForUserFunctionalTests : BasePostLikePresentationQueryFunctionalTest
{
    private readonly GetAllPostLikesForUserApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostLikesForUserApiRequestBuilder _requestBuilder;
    private readonly GetAllPostLikesForUserApiRequest _request;

    public GetAllPostLikesForUserFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserRangeAsync(Users, CancellationToken);
        await ServiceScope.AddPostRangeAsync(Posts, CancellationToken);
        await ServiceScope.AddPostLikeRangeAsync(PostLikes, CancellationToken);
    }

    [Theory]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserId(messageTransformer, request);
    }

    [Theory]
    [UserIdTooLongData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdTooLongWithMessageData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
    }

    [Theory]
    [PostLikesSortOrderEmptyData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostLikesSortOrderEmptyWithMessageData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
    }

    [Theory]
    [PostLikesForUserSortTermEmptyData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
        IEnumTransformer<PostLikesForUserSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostLikesForUserSortTermEmptyWithMessageData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
        IEnumTransformer<PostLikesForUserSortTerm> transformer, IEnumMessageTransformer<PostLikesForUserSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortTerm(messageTransformer, request);
    }

    [Theory]
    [PostLikePageTooSmallData]
    [PostLikePageTooLargeData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostLikePageTooSmallWithMessageData]
    [PostLikePageTooLargeWithMessageData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPage(messageTransformer, request);
    }

    [Theory]
    [PostLikePageSizeTooSmallData]
    [PostLikePageSizeTooLargeData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostLikePageSizeTooSmallWithMessageData]
    [PostLikePageSizeTooLargeWithMessageData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveUserNotFoundProblemDetails_WhenUserIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.GetAllPostLikesForUserProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNotFound(_request);
    }

    [Fact]
    public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdDifferentCaseData]
    public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostLikesSortOrderAscendingData]
    [PostLikesSortOrderDescendingData]
    public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostLikesForUserSortTermCreatedAtData]
    [PostLikesForUserSortTermUserNameData]
    public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
        IEnumTransformer<PostLikesForUserSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostLikesForUserAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, PostLikes, _request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, PostLikes, request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdDifferentCaseData]
    public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, PostLikes, request);
    }

    [Theory]
    [PostLikesSortOrderWithAscendingTermData]
    [PostLikesSortOrderWithDescendingTermData]
    public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostLike> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, PostLikes, request, termTransformer);
    }

    [Theory]
    [PostLikesForUserSortTermWithCreatedAtTermData]
    [PostLikesForUserSortTermWithUserNameTermData]
    public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
        IEnumTransformer<PostLikesForUserSortTerm> transformer, ISortEnumTermTransformer<PostLike> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostLikesForUserAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, PostLikes, request, termTransformer);
    }
}
