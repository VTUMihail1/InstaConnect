using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Assertions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Commands.Delete;

public class DeletePostCommandHandlerUnitTests : BasePostUnitTest
{
    private readonly User _user;
    private readonly Post _post;
    private readonly DeletePostCommandBuilder _commandBuilder;
    private readonly DeletePostCommandHandler _commandHandler;

    public DeletePostCommandHandlerUnitTests()
    {
        _user = new UserBuilder().Create();
        _post = new PostBuilder(_user).Create();
        _commandBuilder = new(_post);
        _commandHandler = new(
            PostService,
            ApplicationMapper);
    }

    [Fact]
    public async Task Handle_ShouldCallPostServiceDeleteAsync_WhenRequestIsValid()
    {
        // Arrange
        var request = _commandBuilder.Create();

        // Act
        await _commandHandler.Handle(request, CancellationToken);

        // Assert
        await PostService.ShouldReceiveOneDeleteAsync(request, CancellationToken);
    }
}
