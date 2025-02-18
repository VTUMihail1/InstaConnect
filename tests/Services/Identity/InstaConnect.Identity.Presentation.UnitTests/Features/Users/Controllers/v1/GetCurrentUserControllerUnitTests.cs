using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrent;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Controllers.v1;

public class GetCurrentUserControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public GetCurrentUserControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetCurrentAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetCurrentUserRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.GetCurrentAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetCurrentAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetCurrentUserRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.GetCurrentAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserQueryResponse>(m => m.Id == existingUser.Id &&
                                           m.FirstName == existingUser.FirstName &&
                                           m.LastName == existingUser.LastName &&
                                           m.UserName == existingUser.UserName &&
                                           m.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task GetCurrentAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetCurrentUserRequest(
            existingUser.Id
        );

        // Act
        await _userController.GetCurrentAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetCurrentUserQuery>(u => u.CurrentUserId == existingUser.Id), CancellationToken);
    }
}
