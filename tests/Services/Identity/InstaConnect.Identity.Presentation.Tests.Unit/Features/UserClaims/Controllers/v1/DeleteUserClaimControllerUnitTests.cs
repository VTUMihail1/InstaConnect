namespace InstaConnect.Identity.Presentation.Tests.Unit.Features.UserClaims.Controllers.v1;


public class DeleteUserClaimControllerUnitTests : BaseUserClaimPresentationCommandUnitTest
{
	private readonly DeleteUserClaimApiRequestBuilderFactory _requestBuilderFactory;
	private readonly DeleteUserClaimApiRequestBuilder _requestBuilder;
	private readonly DeleteUserClaimApiRequest _request;

	private readonly UserClaimController _controller;

	public DeleteUserClaimControllerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(UserClaim);
		_request = _requestBuilder.Build();

		_controller = new(Mapper, Sender);
	}

	[Fact]
	public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
	{
		// Act
		var response = await _controller.DeleteAsync(_request, CancellationToken);

		// Assert
		response.ShouldBeActionResultWithNoContentStatusCode();
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
	{
		// Act
		await _controller.DeleteAsync(_request, CancellationToken);

		// Assert
		await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
	}
}
