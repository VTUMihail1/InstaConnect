namespace InstaConnect.Follows.Application.Tests.Integration.Features.Follows.Commands;

public class AddFollowIntegrationTests : BaseFollowApplicationCommandIntegrationTest
{
	private readonly AddFollowCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddFollowCommandRequestBuilder _requestBuilder;
	private readonly AddFollowCommandRequest _request;

	public AddFollowIntegrationTests(FollowsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follower, Following);
		_request = _requestBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(Follower, CancellationToken);
		await ServiceScope.AddUserAsync(Following, CancellationToken);

		await NotificationClient.ConnectAsync(CancellationToken);
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

	[Fact]
	public async Task SendAsync_ShouldThrowFollowerNotFoundException_WhenFollowerIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(Follower, CancellationToken);

		// Assert
		await Sender.ShouldThrowFollowerNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowFollowingNotFoundException_WhenFollowingIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(Following, CancellationToken);

		// Assert
		await Sender.ShouldThrowFollowingNotFoundExceptionAsync(_request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddFollowAsync(Follow, CancellationToken);

		// Assert
		await Sender.ShouldThrowFollowAlreadyExistsExceptionAsync(_request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExistsAndFollowerIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddFollowAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Assert
		await Sender.ShouldThrowFollowAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldThrowFollowAlreadyExistsException_WhenFollowAlreadyExistsAndFollowingIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddFollowAsync(Follow, CancellationToken);
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Assert
		await Sender.ShouldThrowFollowAlreadyExistsExceptionAsync(request, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(follow, _request);
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
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(follow, request);
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
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

		// Assert
		response.ShouldSatisfy(follow, request);
	}

	[Fact]
	public async Task SendAsync_ShouldAddFollow_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(_request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddFollow_WhenRequestAndFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(request);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldAddFollow_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

		// Assert
		follow.ShouldSatisfy(request);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishFollowAddedEvent_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedFollowAddedAsync(follow, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishFollowAddedEvent_WhenRequestAnFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedFollowAddedAsync(follow, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishFollowAddedEvent_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedFollowAddedAsync(follow, CancellationToken);
	}

	[Fact]
	public async Task SendAsync_ShouldPublishFollowAddedNotification_WhenRequestIsValid()
	{
		// Act
		var response = await Sender.SendAsync(_request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishFollowAddedNotification_WhenRequestAnFollowerIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowerId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(follow);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task SendAsync_ShouldPublishFollowAddedNotification_WhenRequestAndFollowingIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var request = _requestBuilder.WithFollowingId(transformer).Build();

		// Act
		var response = await Sender.SendAsync(request, CancellationToken);
		var follow = await ServiceScope.GetFollowByIdAsync(response.Response, CancellationToken);
		var notification = await NotificationClient.AddedAsync(CancellationToken);

		// Assert
		notification.ShouldSatisfy(follow);
	}
}
