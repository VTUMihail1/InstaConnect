namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Commands.Delete;

public class DeletePostCommandHandlerUnitTests : BasePostApplicationCommandUnitTest
{
	private readonly DeletePostCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly DeletePostCommandRequestBuilder _requestBuilder;
	private readonly DeletePostCommandRequest _request;

	private readonly DeletePostCommandHandler _handler;

	public DeletePostCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(Post);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);
	}

	[Fact]
	public async Task Handle_ShouldCallServiceDeleteAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
	}
}
