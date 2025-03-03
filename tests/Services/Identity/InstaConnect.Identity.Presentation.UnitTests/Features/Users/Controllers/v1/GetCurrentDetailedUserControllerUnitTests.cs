﻿using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailed;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Controllers.v1;

public class GetCurrentDetailedUserControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public GetCurrentDetailedUserControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetCurrentDetailedAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetCurrentDetailedUserRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.GetCurrentDetailedAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetCurrentDetailedAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetCurrentDetailedUserRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.GetCurrentDetailedAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserDetailedQueryResponse>(m => m.Id == existingUser.Id &&
                                           m.FirstName == existingUser.FirstName &&
                                           m.LastName == existingUser.LastName &&
                                           m.UserName == existingUser.UserName &&
                                           m.Email == existingUser.Email &&
                                           m.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task GetCurrentDetailedAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetCurrentDetailedUserRequest(
            existingUser.Id
        );

        // Act
        await _userController.GetCurrentDetailedAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetCurrentDetailedUserQuery>(u => u.CurrentUserId == existingUser.Id), CancellationToken);
    }
}
