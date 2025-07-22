using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Factories;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Update;

public class UpdatePostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;

    private readonly UpdatePostCommandRequest _request;
    private readonly UpdatePostCommandRequestBuilder _requestBuilder;

    private readonly UpdatePostCommandHandler _handler;

    public UpdatePostCommandHandlerUnitTests()
    {
        _user = UserTestFactory.Create();
        _post = PostTestFactory.Create(_user);

        _requestBuilder = new(_post);
        _request = _requestBuilder.Create();

        _handler = new(PostService, ApplicationMapper);

        PostService.SetupUpdateRequest(_request, _post, CancellationToken);
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
    public async Task Handle_ShouldCallPostServiceUpdateAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneUpdateAsync(_request, CancellationToken);
    }
}
