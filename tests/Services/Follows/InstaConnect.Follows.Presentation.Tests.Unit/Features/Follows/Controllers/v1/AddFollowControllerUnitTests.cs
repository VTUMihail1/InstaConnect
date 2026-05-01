namespace InstaConnect.Follows.Presentation.Tests.Unit.Features.Follows.Controllers.v1;

public class AddFollowControllerUnitTests : BaseFollowPresentationCommandUnitTest
{
	private readonly AddFollowApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddFollowApiRequestBuilder _requestBuilder;
	private readonly AddFollowApiRequest _request;

	private readonly FollowController _controller;

	public AddFollowControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Follower, Following);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupAddCommandRequest(_request, Follow, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithOkStatusCode();
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.AddAsync(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Follow, _request);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.AddAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
	}
}
