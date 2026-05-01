namespace InstaConnect.Chats.Application.Tests.Unit.Features.Users.Commands.Update;

public class UpdateUserCommandHandlerUnitTests : BaseUserApplicationCommandUnitTest
{
	private readonly UpdateUserCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly UpdateUserCommandRequestBuilder _requestBuilder;
	private readonly UpdateUserCommandRequest _request;

	private readonly UpdateUserCommandHandler _handler;

	public UpdateUserCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, UserService);

		UserService.SetupUpdateCommand(_request, User, CancellationToken);
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
	public async Task Handle_ShouldCallUserServiceUpdateAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await UserService.ShouldReceiveOneUpdateAsync(_request, CancellationToken);
	}
}
