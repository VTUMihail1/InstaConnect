using InstaConnect.Identity.Application.Features.Users.Commands.Delete;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Controllers.v1;

public class DeleteCurrentUserControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public DeleteCurrentUserControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new DeleteCurrentUserRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.DeleteCurrentAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task DeleteCurrentAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new DeleteCurrentUserRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.DeleteCurrentAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<DeleteUserCommand>(m => m.Id == existingUser.Id), CancellationToken);
    }
}
