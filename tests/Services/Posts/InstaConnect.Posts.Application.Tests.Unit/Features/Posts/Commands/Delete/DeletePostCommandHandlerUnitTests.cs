namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Commands.Delete;

public class DeletePostCommandHandlerUnitTests : BasePostApplicationUnitTest
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

        _handler = new(PostService, ApplicationMapper);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceDeleteAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
    }
}
