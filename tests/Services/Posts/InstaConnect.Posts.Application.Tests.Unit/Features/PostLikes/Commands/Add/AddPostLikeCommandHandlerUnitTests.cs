namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Commands.Add;

public class AddPostLikeCommandHandlerUnitTests : BasePostLikeApplicationCommandUnitTest
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

        _handler = new(Mapper, LikeService);

        LikeService.SetupAddCommand(_request, PostLike, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(PostLike, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallLikeServiceAddAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await LikeService.ShouldReceiveOneAddAsync(_request, CancellationToken);
    }
}
