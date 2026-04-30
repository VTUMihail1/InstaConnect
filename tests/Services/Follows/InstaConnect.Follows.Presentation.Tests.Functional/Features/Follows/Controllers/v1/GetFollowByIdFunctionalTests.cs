namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Controllers.v1;

public class GetFollowByIdFunctionalTests : BaseFollowPresentationQueryFunctionalTest
{
	private readonly GetFollowByIdApiRequestBuilderFactory _requestBuilderFactory;
	private readonly GetFollowByIdApiRequestBuilder _requestBuilder;
	private readonly GetFollowByIdApiRequest _request;

	public GetFollowByIdFunctionalTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follow);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(Follower, CancellationToken);
		await ServiceScope.AddUserAsync(Following, CancellationToken);
		await ServiceScope.AddFollowAsync(Follow, CancellationToken);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenFollowerIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenFollowerIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFollowerId(messageTransformer, request);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenFollowingIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenFollowingIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFollowingId(messageTransformer, request);
	}

	[Theory]
	[UserIdTooLongData]
	public async Task GetByIdAsync_ShouldHaveBadRequestStatusCode_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooLongWithMessageData]
	public async Task GetByIdAsync_ShouldHaveBadRequestProblemDetails_WhenCurrentUserIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForCurrentUserId(messageTransformer, request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveNotFoundStatusCode_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteFollowAsync(Follow, CancellationToken);

		// Act
		var response = await Client.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveFollowNotFoundProblemDetails_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteFollowAsync(Follow, CancellationToken);

		// Act
		var response = await Client.GetByIdProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowNotFound(_request);
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetByIdStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveOkStatusCode_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Client.GetByIdAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Follow, _request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Follow, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldHaveResponse_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Follow, request);
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdDifferentCaseData]
	public async Task GetByIdAsync_ShouldReturnResponse_WhenRequestAndCurrentUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithCurrentUserId(transformer).Build();

		// Act
		var response = await Client.GetByIdAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Follow, request);
	}
}
