using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Business.IntegrationTests.Features.Follows.Utilities;
using InstaConnect.Follows.Business.IntegrationTests.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Follow;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Business.IntegrationTests.Features.Follows.Commands;

public class DeleteFollowIntegrationTests : BaseFollowIntegrationTest
{
    public DeleteFollowIntegrationTests(FollowsIntegrationTestWebAppFactory followIntegrationTestWebAppFactory) : base(followIntegrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var command = new DeleteFollowCommand(
            null!,
            existingFollowerId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

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
        var command = new DeleteFollowCommand(
            SharedTestUtilities.GetString(length),
            existingFollowerId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var command = new DeleteFollowCommand(
            existingFollowId,
            null!
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var command = new DeleteFollowCommand(
            existingFollowId,
            SharedTestUtilities.GetString(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

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
        var command = new DeleteFollowCommand(
            FollowTestUtilities.InvalidId,
            existingFollowerId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<FollowNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowAccountForbiddenException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowerFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowFollowerId, existingFollowerFollowingId, CancellationToken);
        var command = new DeleteFollowCommand(
            existingFollowId,
            existingFollowerId
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserForbiddenException>();
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteMessage_WhenMessageIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var command = new DeleteFollowCommand(
            existingFollowId,
            existingFollowerId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        var follow = await FollowWriteRepository.GetByIdAsync(existingFollowId, CancellationToken);

        follow
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteMessage_WhenMessageIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var command = new DeleteFollowCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingFollowId),
            existingFollowerId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        var follow = await FollowWriteRepository.GetByIdAsync(existingFollowId, CancellationToken);

        follow
            .Should()
            .BeNull();
    }
}
