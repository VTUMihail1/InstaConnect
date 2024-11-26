using FluentAssertions;
using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Follows.Application.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Utilities;
using InstaConnect.Follows.Application.IntegrationTests.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Follow;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Queries;

public class GetFollowByIdQueryHandlerIntegrationTests : BaseFollowIntegrationTest
{
    public GetFollowByIdQueryHandlerIntegrationTests(FollowsIntegrationTestWebAppFactory followIntegrationTestWebAppFactory) : base(followIntegrationTestWebAppFactory)
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
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
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
                                          m.FollowerName == UserTestUtilities.ValidName &&
                                          m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                          m.FollowingId == existingFollowingId &&
                                          m.FollowingName == UserTestUtilities.ValidName &&
                                          m.FollowingProfileImage == UserTestUtilities.ValidProfileImage);
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
                                          m.FollowerName == UserTestUtilities.ValidName &&
                                          m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                          m.FollowingId == existingFollowingId &&
                                          m.FollowingName == UserTestUtilities.ValidName &&
                                          m.FollowingProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
