using FluentAssertions;
using InstaConnect.Follows.Application.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Binding;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;
using InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Controllers.v1;

public class AddFollowUnitTests : BaseFollowUnitTest
{
    private readonly FollowController _followController;

    public AddFollowUnitTests()
    {
        _followController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new AddFollowRequest()
        {
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowingId)
        };

        // Act
        var response = await _followController.AddAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnFollowViewModel_WhenRequestIsValid()
    {
        // Arrange
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new AddFollowRequest()
        {
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowingId)
        };

        // Act
        var response = await _followController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<FollowCommandResponse>(m => m.Id == existingFollowId);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new AddFollowRequest()
        {
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowingId)
        };

        // Act
        await _followController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddFollowCommand>(m => m.CurrentUserId == existingCurrentUserId &&
                                                     m.FollowingId == existingFollowingId),
                                                     CancellationToken);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Arrange
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new AddFollowRequest()
        {
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowingId)
        };

        // Act
        await _followController.AddAsync(request, CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }
}
