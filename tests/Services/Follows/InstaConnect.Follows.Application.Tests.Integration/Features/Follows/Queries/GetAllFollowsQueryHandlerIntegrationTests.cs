using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Tests.Features.Common.Utilities;

namespace InstaConnect.Follows.Application.Tests.Integration.Features.Follows.Queries;

public class GetAllFollowsQueryHandlerIntegrationTests : BaseFollowApplicationQueryIntegrationTest
{
    private readonly GetAllFollowsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllFollowsQueryRequestBuilder _requestBuilder;
    private readonly GetAllFollowsQueryRequest _request;

    public GetAllFollowsQueryHandlerIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
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
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenFollowerIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForFollowerIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenFollowingNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingName(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForFollowingNameAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForCurrentUserIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [FollowsSortOrderEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForSortOrderAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [FollowsSortTermEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortTermIsInvalid(
        IEnumTransformer<FollowsSortTerm> transformer, IEnumMessageTransformer<FollowsSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForSortTermAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [FollowPageTooSmallWithMessageData]
    [FollowPageTooLargeWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForPageAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [FollowPageSizeTooSmallWithMessageData]
    [FollowPageSizeTooLargeWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForPageSizeAsync(
            messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowFollowerNotFoundException_WhenFollowerIdIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(Follower, CancellationToken);

        // Assert
        await Sender.ShouldThrowFollowerNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, _request);
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndFollowerIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowerId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndFollowingNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFollowingName(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, request);
    }

    [Theory]
    [FollowsSortOrderWithAscendingTermData]
    [FollowsSortOrderWithDescendingTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Follow> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, request, termTransformer);
    }

    [Theory]
    [FollowsSortTermWithCreatedAtTermData]
    [FollowsSortTermWithFollowingNameTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
        IEnumTransformer<FollowsSortTerm> transformer, ISortEnumTermTransformer<Follow> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Follower, Follows, request, termTransformer);
    }
}
