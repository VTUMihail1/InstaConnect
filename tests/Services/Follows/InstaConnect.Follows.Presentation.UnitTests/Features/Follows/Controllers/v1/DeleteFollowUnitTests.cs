using FluentAssertions;
using InstaConnect.Follows.Application.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Presentation.Features.Follows.Controllers.v1;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Controllers.v1;

public class DeleteFollowUnitTests : BaseFollowUnitTest
{
    private readonly FollowController _followController;

    public DeleteFollowUnitTests()
    {
        _followController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new DeleteFollowRequest()
        {
            Id = existingFollowId,
            CurrentUserId = existingCurrentUserId
        };

        // Act
        var response = await _followController.DeleteAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<NoContentResult>(m => m.StatusCode == StatusCodes.Status204NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingCurrentUserId = CreateCurrentUser();
        var existingFollowingId = CreateUser();
        var existingFollowId = CreateFollow(existingCurrentUserId, existingFollowingId);
        var request = new DeleteFollowRequest()
        {
            Id = existingFollowId,
            CurrentUserId = existingCurrentUserId
        };

        // Act
        await _followController.DeleteAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
            .Received(1)
            .SendAsync(Arg.Is<DeleteFollowCommand>(m => m.Id == existingFollowId &&
                                                    m.CurrentUserId == existingCurrentUserId),
                                                    CancellationToken);
    }
}
