using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.Add;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Controllers.v1;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.UnitTests.Features.Users.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Controllers.v1;

public class AddUserControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public AddUserControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new AddUserRequest(
            new(
                UserTestUtilities.ValidAddName,
                UserTestUtilities.ValidAddEmail,
                UserTestUtilities.ValidAddPassword,
                UserTestUtilities.ValidAddPassword,
                UserTestUtilities.ValidAddFirstName,
                UserTestUtilities.ValidAddLastName,
                UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await _userController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new AddUserRequest(
            new(
                UserTestUtilities.ValidAddName,
                UserTestUtilities.ValidAddEmail,
                UserTestUtilities.ValidAddPassword,
                UserTestUtilities.ValidAddPassword,
                UserTestUtilities.ValidAddFirstName,
                UserTestUtilities.ValidAddLastName,
                UserTestUtilities.ValidAddFormFile)
        );

        // Act
        var response = await _userController.AddAsync(request, CancellationToken);

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
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new AddUserRequest(
            new(
                UserTestUtilities.ValidAddName,
                UserTestUtilities.ValidAddEmail,
                UserTestUtilities.ValidAddPassword,
                UserTestUtilities.ValidAddPassword,
                UserTestUtilities.ValidAddFirstName,
                UserTestUtilities.ValidAddLastName,
                UserTestUtilities.ValidAddFormFile)
        );

        // Act
        await _userController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<AddUserCommand>(m => m.Email == UserTestUtilities.ValidAddEmail &&
                                                                m.Password == UserTestUtilities.ValidAddPassword &&
                                                                m.ConfirmPassword == UserTestUtilities.ValidAddPassword &&
                                                                m.UserName == UserTestUtilities.ValidAddName &&
                                                                m.FirstName == UserTestUtilities.ValidAddFirstName &&
                                                                m.LastName == UserTestUtilities.ValidAddLastName &&
                                                                m.ProfileImage == UserTestUtilities.ValidAddFormFile), CancellationToken);
    }
}
