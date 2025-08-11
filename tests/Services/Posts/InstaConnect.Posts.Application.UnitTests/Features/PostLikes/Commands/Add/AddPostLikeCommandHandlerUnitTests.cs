using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Application.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddCommandRequest;

namespace InstaConnect.PostLikes.Application.UnitTests.Features.PostLikes.Commands.Add;

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
        _request = _requestBuilder.Create();

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
