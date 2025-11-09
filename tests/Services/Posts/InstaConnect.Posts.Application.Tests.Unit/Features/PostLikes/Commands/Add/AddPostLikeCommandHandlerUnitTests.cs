namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Commands.Add;

public class AddPostLikeCommandHandlerUnitTests : BasePostLikeApplicationUnitTest
{
    private readonly AddPostLikeCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostLikeCommandRequestBuilder _requestBuilder;
    private readonly AddPostLikeCommandRequest _request;

    private readonly AddPostLikeCommandHandler _handler;

    public AddPostLikeCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Post, User);
        _request = _requestBuilder.Build();

        _handler = new(PostLikeService, ApplicationMapper);

        PostLikeService.SetupAddCommand(_request, PostLike, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike);
    }

    [Fact]
    public async Task Handle_ShouldCallPostLikeServiceAddAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostLikeService.ShouldReceiveOneAddAsync(_request, CancellationToken);
    }
}
