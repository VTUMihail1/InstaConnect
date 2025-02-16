using FluentAssertions;

using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Presentation.UnitTests.Features.EmailConfirmationTokens.Utilities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NSubstitute;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.EmailConfirmationTokens.Controllers.v1;
public class AddEmailConfirmationTokenControllerUnitTests : BaseEmailConfirmationTokenUnitTest
{
    private readonly EmailConfirmationTokenController _emailConfirmationTokenController;

    public AddEmailConfirmationTokenControllerUnitTests()
    {
        _emailConfirmationTokenController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new AddEmailConfirmationTokenRequest(
            existingUser.Email
        );

        // Act
        var response = await _emailConfirmationTokenController.AddAsync(request, CancellationToken);

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
        var request = new AddEmailConfirmationTokenRequest(
            existingUser.Email
        );

        // Act
        var response = await _emailConfirmationTokenController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<AddEmailConfirmationTokenCommand>(m => m.Email == existingUser.Email), CancellationToken);
    }
}
