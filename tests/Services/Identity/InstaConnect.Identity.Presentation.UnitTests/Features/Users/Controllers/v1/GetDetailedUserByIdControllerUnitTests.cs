using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Queries.GetDetailedById;
using InstaConnect.Identity.Presentation.Features.Users.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.UnitTests.Features.Users.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Controllers.v1;

public class GetDetailedUserByIdControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public GetDetailedUserByIdControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetDetailedByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetDetailedUserByIdRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.GetDetailedByIdAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetDetailedByIdAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetDetailedUserByIdRequest(
            existingUser.Id
        );

        // Act
        var response = await _userController.GetDetailedByIdAsync(request, CancellationToken);

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
    public async Task GetDetailedByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetDetailedUserByIdRequest(
            existingUser.Id
        );

        // Act
        await _userController.GetDetailedByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetDetailedUserByIdQuery>(m => m.Id == existingUser.Id), CancellationToken);
    }
}
