namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.UserClaims.Controllers.v1;

public class AddUserClaimControllerUnitTests : BaseUserClaimPresentationCommandUnitTest
{
	private readonly AddUserClaimApiRequestBuilderFactory _requestBuilderFactory;
	private readonly AddUserClaimApiRequestBuilder _requestBuilder;
	private readonly AddUserClaimApiRequest _request;

	private readonly UserClaimController _controller;

	public AddUserClaimControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);

		Sender.SetupAddCommandRequest(_request, UserClaim, CancellationToken);
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
		response.ShouldSatisfy(UserClaim, _request);
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
