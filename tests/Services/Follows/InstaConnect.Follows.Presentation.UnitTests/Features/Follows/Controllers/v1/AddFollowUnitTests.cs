using FluentAssertions;

using InstaConnect.Follows.Application.Features.Follows.Commands.Add;
using InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;
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
            InstaConnectSender);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var request = new AddFollowRequest(
            existingFollow.FollowerId,
            new(existingFollow.FollowingId)
        );

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
        var existingFollow = CreateFollow();
        var request = new AddFollowRequest(
            existingFollow.FollowerId,
            new(existingFollow.FollowingId)
        );

        // Act
        var response = await _followController.AddAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<FollowCommandResponse>(m => m.Id == existingFollow.Id);
    }

    [Fact]
    public async Task AddAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var request = new AddFollowRequest(
            existingFollow.FollowerId,
            new(existingFollow.FollowingId)
        );

        // Act
        await _followController.AddAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<AddFollowCommand>(m => m.CurrentUserId == existingFollow.FollowerId &&
                                                     m.FollowingId == existingFollow.FollowingId),
                                                     CancellationToken);
    }
}
