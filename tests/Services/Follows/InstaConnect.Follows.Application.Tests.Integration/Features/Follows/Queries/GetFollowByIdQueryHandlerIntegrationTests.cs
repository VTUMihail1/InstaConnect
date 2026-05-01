namespace InstaConnect.Follows.Application.Tests.Integration.Features.Follows.Queries;

public class GetFollowByIdQueryHandlerIntegrationTests : BaseFollowApplicationQueryIntegrationTest
{
	private readonly GetFollowByIdQueryRequestBuilderFactory _requestBuilderFactory;
	private readonly GetFollowByIdQueryRequestBuilder _requestBuilder;
	private readonly GetFollowByIdQueryRequest _request;

	public GetFollowByIdQueryHandlerIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
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
	[UserIdNullWithMessageData]
	[UserIdEmptyWithMessageData]
	[UserIdTooShortWithMessageData]
	[UserIdTooLongWithMessageData]
	public async Task SendAsync_ShouldThrowValidationException_WhenFollowingIdIsInvalid(
		IStringTransformer transformer, IStringMessageTransformer messageTransformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Assert
		await Sender.ShouldThrowInvalidValidationExceptionForFollowingIdAsync(
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

	[Fact]
	public async Task SendAsync_ShouldThrowFollowNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteFollowAsync(Follow, CancellationToken);

		// Assert
		await Sender.ShouldThrowFollowNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Follow, _request);
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
		response.ShouldSatisfy(Follow, request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Follow, request);
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
		response.ShouldSatisfy(Follow, request);
	}
}
