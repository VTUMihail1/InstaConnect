namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Commands.Add;

public class AddPostCommandHandlerUnitTests : BasePostApplicationCommandUnitTest
{
	private readonly AddPostCommandRequestBuilderFactory _requestBuilderFactory;
	private readonly AddPostCommandRequestBuilder _requestBuilder;
	private readonly AddPostCommandRequest _request;

	private readonly AddPostCommandHandler _handler;

	public AddPostCommandHandlerUnitTests()
	{
		_requestBuilderFactory = new();
		_requestBuilder = _requestBuilderFactory.Create(User);
		_request = _requestBuilder.Build();

		_handler = new(Mapper, Service);

		Service.SetupAddCommand(_request, Post, CancellationToken);
	}

	[Fact]
	public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
	{
		// Act
		var response = await _handler.Handle(_request, CancellationToken);

		// Assert
		response.ShouldSatisfy(Post, _request);
	}

	[Fact]
	public async Task Handle_ShouldCallServiceAddAsync_WhenRequestIsValid()
	{
		// Act
		await _handler.Handle(_request, CancellationToken);

		// Assert
		await Service.ShouldReceiveOneAddAsync(_request, CancellationToken);
	}
}
