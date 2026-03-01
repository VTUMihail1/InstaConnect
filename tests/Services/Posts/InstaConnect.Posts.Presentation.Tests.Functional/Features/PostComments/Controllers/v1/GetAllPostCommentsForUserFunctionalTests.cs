using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortTerm.ForUser;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Controllers.v1;

public class GetAllPostCommentsForUserFunctionalTests : BasePostCommentPresentationQueryFunctionalTest
{
    private readonly GetAllPostCommentsForUserApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentsForUserApiRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentsForUserApiRequest _request;

    public GetAllPostCommentsForUserFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostComment);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserRangeAsync(Users, CancellationToken);
        await ServiceScope.AddPostRangeAsync(Posts, CancellationToken);
        await ServiceScope.AddPostLikeRangeAsync(PostLikes, CancellationToken);
        await ServiceScope.AddPostCommentRangeAsync(PostComments, CancellationToken);
        await ServiceScope.AddPostCommentLikeRangeAsync(PostCommentLikes, CancellationToken);
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
        var response = await HttpClient.GetAllPostCommentsForUserStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllPostCommentsForUserProblemDetailsAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllPostCommentsForUserStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllPostCommentsForUserProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
    }

    [Theory]
    [PostCommentsSortOrderEmptyData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentsSortOrderEmptyWithMessageData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
    }

    [Theory]
    [PostCommentsForUserSortTermEmptyData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
        IEnumTransformer<PostCommentsForUserSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentsForUserSortTermEmptyWithMessageData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
        IEnumTransformer<PostCommentsForUserSortTerm> transformer, IEnumMessageTransformer<PostCommentsForUserSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortTerm(messageTransformer, request);
    }

    [Theory]
    [PostCommentPageTooSmallData]
    [PostCommentPageTooLargeData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentPageTooSmallWithMessageData]
    [PostCommentPageTooLargeWithMessageData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPage(messageTransformer, request);
    }

    [Theory]
    [PostCommentPageSizeTooSmallData]
    [PostCommentPageSizeTooLargeData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentPageSizeTooSmallWithMessageData]
    [PostCommentPageSizeTooLargeWithMessageData]
    public async Task GetAllForUserAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
    }

    [Fact]
    public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostCommentsForUserStatusCodeAsync(_request, CancellationToken);

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
        var response = await HttpClient.GetAllPostCommentsForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostCommentsSortOrderAscendingData]
    [PostCommentsSortOrderDescendingData]
    public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostCommentsForUserSortTermCreatedAtData]
    [PostCommentsForUserSortTermUserNameData]
    public async Task GetAllForUserAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
        IEnumTransformer<PostCommentsForUserSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostCommentsForUserAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, PostComments, _request);
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
        var response = await HttpClient.GetAllPostCommentsForUserAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, PostComments, request);
    }

    [Theory]
    [PostCommentsSortOrderWithAscendingTermData]
    [PostCommentsSortOrderWithDescendingTermData]
    public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, PostComments, request, termTransformer);
    }

    [Theory]
    [PostCommentsForUserSortTermWithCreatedAtTermData]
    [PostCommentsForUserSortTermWithUserNameTermData]
    public async Task GetAllForUserAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
        IEnumTransformer<PostCommentsForUserSortTerm> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsForUserAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User, PostComments, request, termTransformer);
    }
}
