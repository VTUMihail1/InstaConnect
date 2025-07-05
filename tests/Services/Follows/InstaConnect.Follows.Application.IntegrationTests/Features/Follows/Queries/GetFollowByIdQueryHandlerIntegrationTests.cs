using InstaConnect.Common.Exceptions;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

namespace InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Queries;

public class GetFollowByIdQueryHandlerIntegrationTests : BaseFollowIntegrationTest
{
    public GetFollowByIdQueryHandlerIntegrationTests(FollowsWebApplicationFactory followsWebApplicationFactory) : base(followsWebApplicationFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var query = new GetFollowByIdQuery(null);

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetFollowByIdQuery(DataFaker.GetString(length));

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<InvalidValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowFollowNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetFollowByIdQuery(FollowTestUtilities.InvalidId);

        // Act
        var action = async () => await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<FollowNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetFollowByIdQuery(existingFollow.Id);

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryViewModel>(m => m.Id == existingFollow.Id &&
                                          m.FollowerId == existingFollow.FollowerId &&
                                          m.FollowerName == existingFollow.Follower.UserName &&
                                          m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                          m.FollowingId == existingFollow.FollowingId &&
                                          m.FollowingName == existingFollow.Following.UserName &&
                                          m.FollowingProfileImage == existingFollow.Following.ProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetFollowByIdQuery(DataFaker.GetDifferentCaseString(existingFollow.Id));

        // Act
        var response = await ApplicationSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryViewModel>(m => m.Id == existingFollow.Id &&
                                          m.FollowerId == existingFollow.FollowerId &&
                                          m.FollowerName == existingFollow.Follower.UserName &&
                                          m.FollowerProfileImage == existingFollow.Follower.ProfileImage &&
                                          m.FollowingId == existingFollow.FollowingId &&
                                          m.FollowingName == existingFollow.Following.UserName &&
                                          m.FollowingProfileImage == existingFollow.Following.ProfileImage);
    }
}
