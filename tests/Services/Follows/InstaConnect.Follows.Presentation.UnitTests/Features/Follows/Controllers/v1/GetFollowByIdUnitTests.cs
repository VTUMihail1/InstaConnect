using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

namespace InstaConnect.Follows.Presentation.UnitTests.Features.Follows.Controllers.v1;

public class GetFollowByIdUnitTests : BaseFollowUnitTest
{
    private readonly FollowController _followController;

    public GetFollowByIdUnitTests()
    {
        _followController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var request = new GetFollowByIdRequest(existingFollow.Id);

        // Act
        var response = await _followController.GetByIdAsync(request, CancellationToken);

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
        var existingFollow = CreateFollow();
        var request = new GetFollowByIdRequest(existingFollow.Id);

        // Act
        var response = await _followController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<FollowQueryResponse>(m => m.Id == existingFollow.Id &&
                                                 m.FollowerId == existingFollow.FollowerId &&
                                                 m.FollowerName == existingFollow.Follower.UserName &&
                                                 m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                                 m.FollowingId == existingFollow.FollowingId &&
                                                 m.FollowingName == existingFollow.Following.UserName &&
                                                 m.FollowingProfileImage == existingFollow.Following.ProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = CreateFollow();
        var request = new GetFollowByIdRequest(existingFollow.Id);

        // Act
        await _followController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetFollowByIdQuery>(m => m.Id == existingFollow.Id), CancellationToken);
    }
}
