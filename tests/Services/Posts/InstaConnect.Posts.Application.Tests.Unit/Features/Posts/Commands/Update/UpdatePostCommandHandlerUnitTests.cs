namespace InstaConnect.Posts.Application.Tests.Unit.Features.Posts.Commands.Update;

public class UpdatePostCommandHandlerUnitTests : BasePostApplicationUnitTest
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

        _handler = new(PostService, ApplicationMapper);

        PostService.SetupUpdateCommand(_request, Post, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Post);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceUpdateAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneUpdateAsync(_request, CancellationToken);
    }
}
