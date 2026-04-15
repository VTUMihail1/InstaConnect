namespace InstaConnect.Posts.Application.Tests.Unit.Features.PostLikes.Commands.Delete;

public class DeletePostLikeCommandHandlerUnitTests : BasePostLikeApplicationCommandUnitTest
{
    private readonly DeletePostLikeCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostLikeCommandRequestBuilder _requestBuilder;
    private readonly DeletePostLikeCommandRequest _request;

    private readonly DeletePostLikeCommandHandler _handler;

    public DeletePostLikeCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, LikeService);
    }

    [Fact]
    public async Task Handle_ShouldCallLikeServiceDeleteAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await LikeService.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
    }
}
