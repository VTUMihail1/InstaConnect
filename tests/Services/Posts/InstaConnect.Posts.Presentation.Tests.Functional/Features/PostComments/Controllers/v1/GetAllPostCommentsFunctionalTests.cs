using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.Posts.Presentation.Tests.Functional.Features.PostComments.Controllers.v1;

public class GetAllPostCommentsFunctionalTests : BasePostCommentPresentationQueryFunctionalTest
{
    private readonly GetAllPostCommentsApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllPostCommentsApiRequestBuilder _requestBuilder;
    private readonly GetAllPostCommentsApiRequest _request;

    public GetAllPostCommentsFunctionalTests(PostsWebApplicationFactory webApplicationFactory)
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
    [PostIdTooShortData]
    [PostIdTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostIdTooShortWithMessageData]
    [PostIdTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForId(messageTransformer, request);
    }

    [Theory]
    [UserNameTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenUserNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenUserNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForUserName(messageTransformer, request);
    }

    [Theory]
    [UserIdTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
    }

    [Theory]
    [PostCommentsSortOrderEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentsSortOrderEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
    }

    [Theory]
    [PostCommentsSortTermEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
        IEnumTransformer<PostCommentsSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentsSortTermEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
        IEnumTransformer<PostCommentsSortTerm> transformer,
        IEnumMessageTransformer<PostCommentsSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortTerm(messageTransformer, request);
    }

    [Theory]
    [PostCommentPageTooSmallData]
    [PostCommentPageTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentPageTooSmallWithMessageData]
    [PostCommentPageTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPage(messageTransformer, request);
    }

    [Theory]
    [PostCommentPageSizeTooSmallData]
    [PostCommentPageSizeTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [PostCommentPageSizeTooSmallWithMessageData]
    [PostCommentPageSizeTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndUserNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostCommentsSortOrderAscendingData]
    [PostCommentsSortOrderDescendingData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [PostCommentsSortTermCreatedAtData]
    [PostCommentsSortTermUserNameData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortPropertyAreValid(
        IEnumTransformer<PostCommentsSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetAllAsync_ShouldHavePostNotFoundProblemDetails_WhenIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeletePostAsync(Post, CancellationToken);

        // Act
        var response = await HttpClient.GetAllPostCommentsProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyPostNotFound(_request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllPostCommentsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, PostComments, _request);
    }

    [Theory]
    [PostIdDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, PostComments, request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndUserNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithUserName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, PostComments, request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, PostComments, request);
    }

    [Theory]
    [PostCommentsSortOrderWithAscendingTermData]
    [PostCommentsSortOrderWithDescendingTermData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, PostComments, request, termTransformer);
    }

    [Theory]
    [PostCommentsSortTermWithCreatedAtTermData]
    [PostCommentsSortTermWithUserNameTermData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortPropertyAreValid(
        IEnumTransformer<PostCommentsSortTerm> transformer, ISortEnumTermTransformer<PostComment> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllPostCommentsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post, PostComments, request, termTransformer);
    }
}
