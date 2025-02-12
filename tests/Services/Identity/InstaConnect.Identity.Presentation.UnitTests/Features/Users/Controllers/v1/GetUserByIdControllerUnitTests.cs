using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Queries.GetById;
using InstaConnect.Identity.Presentation.Features.Users.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.UnitTests.Features.Users.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Controllers.v1;

public class GetUserByIdControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public GetUserByIdControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetUserByIdRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetUserByIdRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.GetByIdAsync(request, CancellationToken);

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
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetUserByIdRequest(
            existingUser.Id
        );

        // Act
        await _userController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetUserByIdQuery>(m => m.Id == existingUser.Id), CancellationToken);
    }
}
