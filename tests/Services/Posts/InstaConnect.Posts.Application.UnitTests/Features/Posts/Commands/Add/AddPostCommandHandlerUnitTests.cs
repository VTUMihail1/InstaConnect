using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Add;

public class AddPostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly AddPostCommandBuilder _commandBuilder;
    private readonly AddPostCommandHandler _commandHandler;

    public AddPostCommandHandlerUnitTests()
    {
        _user = new UserBuilder().Create();
        _post = new PostBuilder(_user).Create();
        _commandBuilder = new(_post);
        _commandHandler = new(
            PostService,
            ApplicationMapper);

        var request = _commandBuilder.Create();

        PostService.SetupAddRequest(request, _post, CancellationToken);
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
    public async Task Handle_ShouldCallPostServiceAddAsync_WhenRequestIsValid()
    {
        // Arrange
        var request = _commandBuilder.Create();

        // Act
        await _commandHandler.Handle(request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneAddAsync(request, CancellationToken);
    }
}
