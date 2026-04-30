namespace InstaConnect.Follows.Presentation.Tests.Functional.Features.Follows.Controllers.v1;

public class DeleteFollowFunctionalTests : BaseFollowPresentationCommandFunctionalTest
{
	private readonly DeleteFollowApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteFollowApiRequestBuilder _requestBuilder;
	private readonly DeleteFollowApiRequest _request;

	public DeleteFollowFunctionalTests(FollowsWebApplicationFactory webApplicationFactory)
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

	[Fact]
	public async Task DeleteAsync_ShouldReturnUnauthorizedStatusCode_WhenRequestIsUnauthorized()
	{
		// Act
		var response = await Client.DeleteUnauthorizedStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeUnauthorized();
	}

	[Theory]
	[UserIdNullData]
	[UserIdEmptyData]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenFollowerIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenFollowerIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFollowerId(messageTransformer, request);
	}

	[Theory]
	[UserIdTooShortData]
	[UserIdTooLongData]
	public async Task DeleteAsync_ShouldHaveBadRequestStatusCode_WhenFollowingIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeBadRequest();
	}

	[Theory]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task DeleteAsync_ShouldHaveBadRequestProblemDetails_WhenFollowingIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.DeleteProblemDetailsAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfyInvalidValidationForFollowingId(messageTransformer, request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNotFoundStatusCode_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteFollowAsync(Follow, CancellationToken);

		// Act
		var response = await Client.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNotFound();
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveFollowNotFoundProblemDetails_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteFollowAsync(Follow, CancellationToken);

		// Act
		var response = await Client.DeleteProblemDetailsAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfyFollowNotFound(_request);
	}

	[Fact]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await Client.DeleteStatusCodeAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldHaveNoContentStatusCode_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Client.DeleteStatusCodeAsync(request, CancellationToken);

		// Assert
		response.ShouldBeNoContent();
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenRequestIsValid()
	{
		// Act
		await Client.DeleteAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(Follow.Id, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(Follow.Id, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeleteFollow_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(Follow.Id, CancellationToken);

		// Assert
		follow.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishFollowDeletedEvent_WhenRequestIsValid()
	{
		// Act
		await Client.DeleteAsync(_request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedFollowDeletedAsync(Follow, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishFollowDeletedEvent_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedFollowDeletedAsync(Follow, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishFollowDeletedEvent_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		await Client.DeleteAsync(request, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedFollowDeletedAsync(Follow, CancellationToken);
	}
}
