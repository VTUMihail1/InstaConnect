using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.Update;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.UnitTests.Features.Users.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Controllers.v1;

public class UpdateCurrentUserControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public UpdateCurrentUserControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
                UserTestUtilities.ValidUpdateName,
                UserTestUtilities.ValidUpdateFirstName,
                UserTestUtilities.ValidUpdateLastName,
                UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await _userController.UpdateCurrentAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
                UserTestUtilities.ValidUpdateName,
                UserTestUtilities.ValidUpdateFirstName,
                UserTestUtilities.ValidUpdateLastName,
                UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        var response = await _userController.UpdateCurrentAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserCommandResponse>(m => m.Id == existingUser.Id);
    }

    [Fact]
    public async Task UpdateCurrentAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new UpdateCurrentUserRequest(
            existingUser.Id,
            new(
                UserTestUtilities.ValidUpdateName,
                UserTestUtilities.ValidUpdateFirstName,
                UserTestUtilities.ValidUpdateLastName,
                UserTestUtilities.ValidUpdateFormFile)
        );

        // Act
        await _userController.UpdateCurrentAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<UpdateUserCommand>(m => m.CurrentUserId == existingUser.Id &&
                                                                m.UserName == UserTestUtilities.ValidUpdateName &&
                                                                m.FirstName == UserTestUtilities.ValidUpdateFirstName &&
                                                                m.LastName == UserTestUtilities.ValidUpdateLastName &&
                                                                m.ProfileImageFile == UserTestUtilities.ValidUpdateFormFile), CancellationToken);
    }
}
