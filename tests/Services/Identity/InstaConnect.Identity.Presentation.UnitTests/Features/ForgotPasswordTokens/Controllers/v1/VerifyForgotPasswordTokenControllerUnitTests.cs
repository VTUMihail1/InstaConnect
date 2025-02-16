using FluentAssertions;

using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Presentation.UnitTests.Features.ForgotPasswordTokens.Utilities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NSubstitute;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.ForgotPasswordTokens.Controllers.v1;

public class VerifyForgotPasswordTokenControllerUnitTests : BaseForgotPasswordTokenUnitTest
{
    private readonly ForgotPasswordTokenController _ForgotPasswordTokenController;

    public VerifyForgotPasswordTokenControllerUnitTests()
    {
        _ForgotPasswordTokenController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var request = new VerifyForgotPasswordTokenRequest(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            new(
                UserTestUtilities.ValidUpdatePassword,
                UserTestUtilities.ValidUpdatePassword));

        // Act
        var response = await _ForgotPasswordTokenController.VerifyAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task VerifyAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingForgotPasswordToken = CreateForgotPasswordToken();
        var request = new VerifyForgotPasswordTokenRequest(
            existingForgotPasswordToken.UserId,
            existingForgotPasswordToken.Value,
            new(
                UserTestUtilities.ValidUpdatePassword,
                UserTestUtilities.ValidUpdatePassword)
        );

        // Act
        var response = await _ForgotPasswordTokenController.VerifyAsync(request, CancellationToken);

        // Assert
        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<VerifyForgotPasswordTokenCommand>(m => m.Token == existingForgotPasswordToken.Value &&
                                                                 m.UserId == existingForgotPasswordToken.UserId &&
                                                                 m.Password == UserTestUtilities.ValidUpdatePassword &&
                                                                 m.ConfirmPassword == UserTestUtilities.ValidUpdatePassword), CancellationToken);
    }
}
