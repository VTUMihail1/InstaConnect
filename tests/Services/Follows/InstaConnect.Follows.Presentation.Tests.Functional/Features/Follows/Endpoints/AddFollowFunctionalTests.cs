namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Endpoints;

public class AddFollowFunctionalTests : BaseFollowPresentationCommandFunctionalTest
{
	private readonly AddFollowApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddFollowApiRequestBuilder _requestBuilder;
	private readonly AddFollowApiRequest _request;

	public AddFollowFunctionalTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follower, Following);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddAsync(Follower, CancellationToken);
		await ServiceScope.AddAsync(Following, CancellationToken);

		await base.OnInitializeAsync();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await Client.AddUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowerIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenFollowerIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFollowerId(request, messageTransformer);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowingIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenFollowingIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFollowingId(request, messageTransformer);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenFollowerIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follower, CancellationToken);

		// Act
		var response = await Client.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveFollowerNotFoundProblemDetails_WhenFollowerIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Follower, CancellationToken);

		// Act
		var response = await Client.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowerNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenFollowingIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Following, CancellationToken);

		// Act
		var response = await Client.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveFollowingNotFoundProblemDetails_WhenFollowingIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteAsync(Following, CancellationToken);

		// Act
		var response = await Client.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowingNotFound(_request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);

		// Act
		var response = await Client.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowAlreadyExistsAndFollowerIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenFollowAlreadyExistsAndFollowingIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Fact]
	public async Task AddAsync_ShouldHaveFollowAlreadyExistsProblemDetails_WhenFollowAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);

		// Act
		var response = await Client.AddProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowAlreadyExists(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveFollowAlreadyExistsProblemDetails_WhenFollowAlreadyExistsAndFollowerIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowAlreadyExists(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveFollowAlreadyExistsProblemDetails_WhenFollowAlreadyExistsAndFollowingIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.AddProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowAlreadyExists(request);
	}

	[Fact]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.AddStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.AddStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeOk();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Client.AddAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(_request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(request, follow);
	}

	[Fact]
	public async Task AddAsync_ShouldAddFollow_WhenRequestIsValid()
	{
		// Act
		var response = await Client.AddAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddFollow_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddFollow_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(request);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Client.AddAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventHarness.PublishedAddedEventRequestAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(_request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventHarness.PublishedAddedEventRequestAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedEvent_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var eventRequest = await EventHarness.PublishedAddedEventRequestAsync(CancellationToken);

		// Assert
		eventRequest.ShouldSatisfy(request, follow);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishFollowAddedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await Client.AddAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(_request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedNotification_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(request, follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishFollowAddedNotification_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.AddAsync(request, CancellationToken);
		var follow = await ServiceScope.GetByIdAsync(response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(request, follow);
	}
}
