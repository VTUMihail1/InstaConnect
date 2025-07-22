using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Factories;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Delete;

public class DeletePostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;

    private readonly DeletePostCommandRequest _request;
    private readonly DeletePostCommandRequestBuilder _requestBuilder;

    private readonly DeletePostCommandHandler _handler;

    public DeletePostCommandHandlerUnitTests()
    {
        _user = UserTestFactory.Create();
        _post = PostTestFactory.Create(_user);

        _requestBuilder = new(_post);
        _request = _requestBuilder.Create();

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
