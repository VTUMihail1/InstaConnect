using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Controllers.v1;

public class GetAllFollowsFunctionalTests : BaseFollowPresentationQueryFunctionalTest
{
    private readonly GetAllFollowsApiRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllFollowsApiRequestBuilder _requestBuilder;
    private readonly GetAllFollowsApiRequest _request;

    public GetAllFollowsFunctionalTests(FollowsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Follow);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserRangeAsync(Followers, CancellationToken);
        await ServiceScope.AddUserRangeAsync(Followings, CancellationToken);
        await ServiceScope.AddFollowRangeAsync(Follows, CancellationToken);
    }

    [Theory]
    [UserIdTooShortData]
    [UserIdTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenFollowerIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenFollowerIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForFollowerId(messageTransformer, request);
    }

    [Theory]
    [UserNameTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenFollowingNameIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenFollowingNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForFollowingName(messageTransformer, request);
    }

    [Theory]
    [UserIdTooLongData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllFollowsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
    }

    [Theory]
    [FollowsSortOrderEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [FollowsSortOrderEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer,
        IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
    }

    [Theory]
    [FollowsSortTermEmptyData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
        IEnumTransformer<FollowsSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [FollowsSortTermEmptyWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
        IEnumTransformer<FollowsSortTerm> transformer,
        IEnumMessageTransformer<FollowsSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForSortTerm(messageTransformer, request);
    }

    [Theory]
    [FollowPageTooSmallData]
    [FollowPageTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [FollowPageTooSmallWithMessageData]
    [FollowPageTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPage(messageTransformer, request);
    }

    [Theory]
    [FollowPageSizeTooSmallData]
    [FollowPageSizeTooLargeData]
    public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
        IIntTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [FollowPageSizeTooSmallWithMessageData]
    [FollowPageSizeTooLargeWithMessageData]
    public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveNotFoundStatusCode_WhenFollowerIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(Follower, CancellationToken);

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveFollowerNotFoundProblemDetails_WhenFollowerIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(Follower, CancellationToken);

        // Act
        var response = await HttpClient.GetAllFollowsProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyFollowerNotFound(_request);
    }

    [Fact]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowerIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowingNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

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
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [FollowsSortOrderAscendingData]
    [FollowsSortOrderDescendingData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Theory]
    [FollowsSortTermCreatedAtData]
    [FollowsSortTermFollowingNameData]
    public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
        IEnumTransformer<FollowsSortTerm> transformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeOk();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.GetAllFollowsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, _request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndFollowerIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndFollowingNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingName(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, request);
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
        var response = await HttpClient.GetAllFollowsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, request);
    }

    [Theory]
    [FollowsSortOrderWithAscendingTermData]
    [FollowsSortOrderWithDescendingTermData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Follow> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, request, termTransformer);
    }

    [Theory]
    [FollowsSortTermWithCreatedAtTermData]
    [FollowsSortTermWithFollowingNameTermData]
    public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
        IEnumTransformer<FollowsSortTerm> transformer, ISortEnumTermTransformer<Follow> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await HttpClient.GetAllFollowsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, request, termTransformer);
    }
}
