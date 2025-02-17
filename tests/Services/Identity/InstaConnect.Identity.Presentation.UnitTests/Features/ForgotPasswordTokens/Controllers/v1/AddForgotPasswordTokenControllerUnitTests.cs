using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.ForgotPasswordTokens.Controllers.v1;
public class AddForgotPasswordTokenControllerUnitTests : BaseForgotPasswordTokenUnitTest
{
    private readonly ForgotPasswordTokenController _forgotPasswordTokenController;

    public AddForgotPasswordTokenControllerUnitTests()
    {
        _forgotPasswordTokenController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new AddForgotPasswordTokenRequest(
            existingUser.Email
        );

        // Act
        var response = await _forgotPasswordTokenController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new AddForgotPasswordTokenRequest(
            existingUser.Email
        );

        // Act
        var response = await _forgotPasswordTokenController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<AddForgotPasswordTokenCommand>(m => m.Email == existingUser.Email), CancellationToken);
    }
}
