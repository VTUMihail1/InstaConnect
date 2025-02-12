using FluentAssertions;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Presentation.UnitTests.Features.EmailConfirmationTokens.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.EmailConfirmationTokens.Controllers.v1;

public class VerifyEmailConfirmationTokenControllerUnitTests : BaseEmailConfirmationTokenUnitTest
{
    private readonly EmailConfirmationTokenController _emailConfirmationTokenController;

    public VerifyEmailConfirmationTokenControllerUnitTests()
    {
        _emailConfirmationTokenController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task VerifyAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var request = new VerifyEmailConfirmationTokenRequest(
            existingEmailConfirmationToken.Value,
            existingEmailConfirmationToken.UserId
        );

        // Act
        var response = await _emailConfirmationTokenController.VerifyAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task VerifyAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingEmailConfirmationToken = CreateEmailConfirmationToken();
        var request = new VerifyEmailConfirmationTokenRequest(
            existingEmailConfirmationToken.Value,
            existingEmailConfirmationToken.UserId
        );

        // Act
        var response = await _emailConfirmationTokenController.VerifyAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<VerifyEmailConfirmationTokenCommand>(m => m.Token == existingEmailConfirmationToken.Value &&
                                                                m.UserId == existingEmailConfirmationToken.UserId), CancellationToken);
    }
}
