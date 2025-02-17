using InstaConnect.Identity.Application.Features.Users.Commands.Delete;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Controllers.v1;

public class DeleteUserControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public DeleteUserControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new DeleteUserRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new DeleteUserRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<DeleteUserCommand>(m => m.Id == existingUser.Id), CancellationToken);
    }
}
