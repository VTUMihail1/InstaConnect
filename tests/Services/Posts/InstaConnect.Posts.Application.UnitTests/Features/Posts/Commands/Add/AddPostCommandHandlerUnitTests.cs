using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddCommandRequest;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Add;

public class AddPostCommandHandlerUnitTests : BasePostApplicationUnitTest
{
    private readonly AddPostCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddPostCommandRequestBuilder _requestBuilder;
    private readonly AddPostCommandRequest _request;

    private readonly AddPostCommandHandler _handler;

    public AddPostCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Create();

        _handler = new(PostService, ApplicationMapper);

        PostService.SetupAddCommand(_request, Post, CancellationToken);
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
    public async Task Handle_ShouldCallPostServiceAddAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneAddAsync(_request, CancellationToken);
    }
}
