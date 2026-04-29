using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Controllers.v1;

public class GetAllFollowsForFollowingFunctionalTests : BaseFollowPresentationQueryFunctionalTest
{
	private readonly GetAllFollowsForFollowingApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllFollowsForFollowingApiRequestBuilder _requestBuilder;
	private readonly GetAllFollowsForFollowingApiRequest _request;

	public GetAllFollowsForFollowingFunctionalTests(FollowsWebApplicationFactory webApplicationFactory)
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
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestStatusCode_WhenFollowingIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestProblemDetails_WhenFollowingIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFollowingId(messageTransformer, request);
	}

	[Theory]
	[UserNameTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenFollowerNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerName(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenFollowerNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerName(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFollowerName(messageTransformer, request);
	}

	[Theory]
	[UserIdTooLongData]
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
	}

	[Theory]
	[FollowsSortOrderEmptyData]
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[FollowsSortOrderEmptyWithMessageData]
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
	}

	[Theory]
	[FollowsForFollowingSortTermEmptyData]
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
		IEnumTransformer<FollowsForFollowingSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[FollowsForFollowingSortTermEmptyWithMessageData]
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
		IEnumTransformer<FollowsForFollowingSortTerm> transformer, IEnumMessageTransformer<FollowsForFollowingSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortTerm(messageTransformer, request);
	}

	[Theory]
	[FollowPageTooSmallData]
	[FollowPageTooLargeData]
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[FollowPageTooSmallWithMessageData]
	[FollowPageTooLargeWithMessageData]
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPage(messageTransformer, request);
	}

	[Theory]
	[FollowPageSizeTooSmallData]
	[FollowPageSizeTooLargeData]
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[FollowPageSizeTooSmallWithMessageData]
	[FollowPageSizeTooLargeWithMessageData]
	public async Task GetAllForFollowingAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllForFollowingAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowerNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerName(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllForFollowingAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[FollowsSortOrderAscendingData]
	[FollowsSortOrderDescendingData]
	public async Task GetAllForFollowingAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[FollowsForFollowingSortTermCreatedAtData]
	[FollowsForFollowingSortTermFollowerNameData]
	public async Task GetAllForFollowingAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<FollowsForFollowingSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await HttpClient.GetAllFollowsForFollowingAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Following, Follows, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Following, Follows, request);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndFollowerNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerName(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Following, Follows, request);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Following, Follows, request);
	}

	[Theory]
	[FollowsSortOrderWithAscendingTermData]
	[FollowsSortOrderWithDescendingTermData]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<Follow> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Following, Follows, request, termTransformer);
	}

	[Theory]
	[FollowsForFollowingSortTermWithCreatedAtTermData]
	[FollowsForFollowingSortTermWithFollowerNameTermData]
	public async Task GetAllForFollowingAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<FollowsForFollowingSortTerm> transformer, ISortEnumTermTransformer<Follow> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await HttpClient.GetAllFollowsForFollowingAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Following, Follows, request, termTransformer);
	}
}
