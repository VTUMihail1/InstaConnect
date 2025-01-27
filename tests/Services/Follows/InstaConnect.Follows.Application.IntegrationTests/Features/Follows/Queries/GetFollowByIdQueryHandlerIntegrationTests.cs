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
        var existingFollow = await CreateFollowAsync(CancellationToken);
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetFollowByIdQuery(existingFollow.Id);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryViewModel>(m => m.Id == existingFollow.Id &&
                                          m.FollowerId == existingFollow.FollowerId &&
                                          m.FollowerName == UserTestUtilities.ValidName &&
                                          m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                          m.FollowingId == existingFollow.FollowingId &&
                                          m.FollowingName == UserTestUtilities.ValidName &&
                                          m.FollowingProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnFollowViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var query = new GetFollowByIdQuery(SharedTestUtilities.GetNonCaseMatchingString(existingFollow.Id));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryViewModel>(m => m.Id == existingFollow.Id &&
                                          m.FollowerId == existingFollow.FollowerId &&
                                          m.FollowerName == UserTestUtilities.ValidName &&
                                          m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                          m.FollowingId == existingFollow.FollowingId &&
                                          m.FollowingName == UserTestUtilities.ValidName &&
                                          m.FollowingProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
