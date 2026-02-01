namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Commands.Update;

public class UpdatePostCommandHandlerUnitTests : BasePostApplicationCommandUnitTest
{
    private readonly UpdatePostCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly UpdatePostCommandRequestBuilder _requestBuilder;
    private readonly UpdatePostCommandRequest _request;

    private readonly UpdatePostCommandHandler _handler;

    public UpdatePostCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, Service);

        Service.SetupUpdateCommand(_request, Post, CancellationToken);
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
    public async Task Handle_ShouldCallPostServiceUpdateAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await Service.ShouldReceiveOneUpdateAsync(_request, CancellationToken);
    }
}
