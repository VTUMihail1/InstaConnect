using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Assertions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Update;

public class UpdatePostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly UpdatePostCommandBuilder _commandBuilder;
    private readonly UpdatePostCommandHandler _commandHandler;

    public UpdatePostCommandHandlerUnitTests()
    {
        _user = new UserBuilder().Create();
        _post = new PostBuilder(_user).Create();
        _commandBuilder = new(_post);
        _commandHandler = new(
            PostService,
            ApplicationMapper);

        var request = _commandBuilder.Create();

        PostService.SetupUpdateRequest(request, _post, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = _commandBuilder.Create();

        // Act
        var response = await _commandHandler.Handle(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(_post);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceUpdateAsync_WhenRequestIsValid()
    {
        // Arrange
        var request = _commandBuilder.Create();

        // Act
        await _commandHandler.Handle(request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneUpdateAsync(request, CancellationToken);
    }
}
