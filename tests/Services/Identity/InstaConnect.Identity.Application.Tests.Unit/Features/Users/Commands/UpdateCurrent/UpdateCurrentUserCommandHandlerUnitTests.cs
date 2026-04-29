namespace InstaConnect.Identity.Application.Tests.Unit.Features.Users.Commands.UpdateCurrent;

public class UpdateCurrentUserCommandHandlerUnitTests : BaseUserApplicationCommandUnitTest
{
	private readonly UpdateCurrentUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateCurrentUserCommandRequestBuilder _requestBuilder;
	private readonly UpdateCurrentUserCommandRequest _request;

	private readonly UpdateCurrentUserCommandHandler _handler;

	public UpdateCurrentUserCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupUpdateCommand(_request, User, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, _request);
	}

	[Fact]
	public async Task Handle_ShouldCallServiceUpdateAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldReceiveOneUpdateAsync(_request, CancellationToken);
	}
}
