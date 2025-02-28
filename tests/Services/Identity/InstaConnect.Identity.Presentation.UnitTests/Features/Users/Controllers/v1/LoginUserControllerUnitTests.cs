using InstaConnect.Identity.Application.Features.Users.Commands.Login;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Controllers.v1;

public class LoginUserControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public LoginUserControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUserClaim = CreateUserClaim();
        var request = new LoginUserRequest(
            new(
                existingUserClaim.User.Email,
                UserTestUtilities.ValidPassword)
        );

        // Act
        var response = await _userController.LoginAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingUserClaim = CreateUserClaim();
        var request = new LoginUserRequest(
            new(
                existingUserClaim.User.Email,
                UserTestUtilities.ValidPassword)
        );

        // Act
        var response = await _userController.LoginAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserTokenCommandResponse>(m => m.Value == UserTestUtilities.ValidAccessTokenValue &&
                                                     m.ValidUntil == UserTestUtilities.ValidUntil);
    }

    [Fact]
    public async Task LoginAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingUserClaim = CreateUserClaim();
        var request = new LoginUserRequest(
            new(
                existingUserClaim.User.Email,
                UserTestUtilities.ValidPassword)
        );

        // Act
        await _userController.LoginAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<LoginUserCommand>(m => m.Email == existingUserClaim.User.Email &&
                                                          m.Password == UserTestUtilities.ValidPassword), CancellationToken);
    }
}
