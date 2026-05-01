namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.Users.Controllers.v1;

public class AddUserControllerUnitTests : BaseUserPresentationCommandUnitTest
{
	private readonly AddUserApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserApiRequestBuilder _requestBuilder;
	private readonly AddUserApiRequest _request;

	private readonly UserController _controller;

	public AddUserControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create();
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupAddCommandRequest(_request, User, CancellationToken);
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
		response.ShouldSatisfy(User, _request);
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
