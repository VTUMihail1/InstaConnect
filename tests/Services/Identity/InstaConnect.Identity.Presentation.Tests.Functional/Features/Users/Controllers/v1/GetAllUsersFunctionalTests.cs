using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.Users.Controllers.v1;

public class GetAllUsersFunctionalTests : BaseUserPresentationQueryFunctionalTest
{
	private readonly GetAllUsersApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetAllUsersApiRequestBuilder _requestBuilder;
	private readonly GetAllUsersApiRequest _request;

	public GetAllUsersFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserRangeAsync(Users, CancellationToken);
	}

	[Theory]
	[UserNameTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserNameTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForName(messageTransformer, request);
	}

	[Theory]
	[UserFirstNameTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenFirstNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserFirstNameTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenFirstNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFirstName(messageTransformer, request);
	}

	[Theory]
	[UserLastNameTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenLastNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserLastNameTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenLastNameIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForLastName(messageTransformer, request);
	}

	[Theory]
	[UserIdTooLongData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenCurrentIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentId(messageTransformer, request);
	}

	[Theory]
	[UsersSortOrderEmptyData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UsersSortOrderEmptyWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortOrderIsInvalid(
		IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortOrder(messageTransformer, request);
	}

	[Theory]
	[UsersSortTermEmptyData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenSortTermIsInvalid(
		IEnumTransformer<UsersSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UsersSortTermEmptyWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenSortTermIsInvalid(
		IEnumTransformer<UsersSortTerm> transformer, IEnumMessageTransformer<UsersSortTerm> messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForSortTerm(messageTransformer, request);
	}

	[Theory]
	[UserPageTooSmallData]
	[UserPageTooLargeData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserPageTooSmallWithMessageData]
	[UserPageTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPage(transformer).Build();

		// Act
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPage(messageTransformer, request);
	}

	[Theory]
	[UserPageSizeTooSmallData]
	[UserPageSizeTooLargeData]
	public async Task GetAllAsync_ShouldHaveBadRequestStatusCode_WhenPageSizeIsInvalid(
		IIntTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserPageSizeTooSmallWithMessageData]
	[UserPageSizeTooLargeWithMessageData]
	public async Task GetAllAsync_ShouldHaveBadRequestProblemDetails_WhenPageSizeIsInvalid(
		IIntTransformer transformer, IIntMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithPageSize(transformer).Build();

		// Act
		var response = await Client.GetAllProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForPageSize(messageTransformer, request);
	}

	[Fact]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetAllStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserFirstNameNullData]
	[UserFirstNameEmptyData]
	[UserFirstNameDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndFirstNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserLastNameNullData]
	[UserLastNameEmptyData]
	[UserLastNameDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndLastNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UsersSortOrderAscendingData]
	[UsersSortOrderDescendingData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UsersSortTermCreatedAtData]
	[UsersSortTermNameData]
	[UsersSortTermFirstNameData]
	[UsersSortTermLastNameData]
	public async Task GetAllAsync_ShouldHaveOkStatusCode_WhenRequestAndSortTermAreValid(
		IEnumTransformer<UsersSortTerm> transformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetAllAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Users, _request);
	}

	[Theory]
	[UserNameNullData]
	[UserNameEmptyData]
	[UserNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithName(transformer).Build();

		// Act
		var response = await Client.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Users, request);
	}

	[Theory]
	[UserFirstNameNullData]
	[UserFirstNameEmptyData]
	[UserFirstNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndFirstNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFirstName(transformer).Build();

		// Act
		var response = await Client.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Users, request);
	}

	[Theory]
	[UserLastNameNullData]
	[UserLastNameEmptyData]
	[UserLastNameDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndLastNameAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithLastName(transformer).Build();

		// Act
		var response = await Client.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Users, request);
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndCurrentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentId(transformer).Build();

		// Act
		var response = await Client.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Users, request);
	}

	[Theory]
	[UsersSortOrderWithAscendingTermData]
	[UsersSortOrderWithDescendingTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
		IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<User> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortOrder(transformer).Build();

		// Act
		var response = await Client.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Users, request, termTransformer);
	}

	[Theory]
	[UsersSortTermWithCreatedAtTermData]
	[UsersSortTermWithNameTermData]
	[UsersSortTermWithFirstNameTermData]
	[UsersSortTermWithLastNameTermData]
	public async Task GetAllAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
		IEnumTransformer<UsersSortTerm> transformer, ISortEnumTermTransformer<User> termTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithSortTerm(transformer).Build();

		// Act
		var response = await Client.GetAllAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Users, request, termTransformer);
	}
}
