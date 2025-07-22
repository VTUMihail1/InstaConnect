using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Factories;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Add;

public class AddPostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;

    private readonly AddPostCommandRequest _request;
    private readonly AddPostCommandRequestBuilder _requestBuilder;

    private readonly AddPostCommandHandler _handler;

    public AddPostCommandHandlerUnitTests()
    {
        _user = UserTestFactory.Create();
        _post = PostTestFactory.Create(_user);

        _requestBuilder = new(_post);
        _request = _requestBuilder.Create();

        _handler = new(PostService, ApplicationMapper);

        PostService.SetupAddRequest(_request, _post, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post);
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
