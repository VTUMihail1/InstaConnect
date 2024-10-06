using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Business.IntegrationTests.Features.Follows.Utilities;
using InstaConnect.Follows.Business.IntegrationTests.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Follow;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Business.IntegrationTests.Features.Follows.Queries;

public class GetFollowByIdQueryHandlerIntegrationTests : BaseFollowIntegrationTest
{
    public GetFollowByIdQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetFollowByIdQuery(null!);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetFollowByIdQuery(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowFollowNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetFollowByIdQuery(FollowTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<FollowNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetFollowByIdQuery(existingFollowId);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryViewModel>(m => m.Id == existingFollowId &&
                                          m.FollowerId == existingFollowerId &&
                                          m.FollowerName == FollowTestUtilities.ValidUserName &&
                                          m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                          m.FollowingId == existingFollowingId &&
                                          m.FollowingName == FollowTestUtilities.ValidUserName &&
                                          m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var query = new GetFollowByIdQuery(SharedTestUtilities.GetNonCaseMatchingString(existingFollowId));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryViewModel>(m => m.Id == existingFollowId &&
                                          m.FollowerId == existingFollowerId &&
                                          m.FollowerName == FollowTestUtilities.ValidUserName &&
                                          m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                          m.FollowingId == existingFollowingId &&
                                          m.FollowingName == FollowTestUtilities.ValidUserName &&
                                          m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage);
    }
}
