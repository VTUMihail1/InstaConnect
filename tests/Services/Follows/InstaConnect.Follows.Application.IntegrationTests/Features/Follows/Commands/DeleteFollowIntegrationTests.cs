using FluentAssertions;
using InstaConnect.Follows.Application.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Utilities;
using InstaConnect.Follows.Application.IntegrationTests.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.Follow;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Commands;

public class DeleteFollowIntegrationTests : BaseFollowIntegrationTest
{
    public DeleteFollowIntegrationTests(FollowsWebApplicationFactory followsWebApplicationFactory) : base(followsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var command = new DeleteFollowCommand(
            null,
            existingFollow.FollowerId
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var command = new DeleteFollowCommand(
            SharedTestUtilities.GetString(length),
            existingFollow.FollowerId
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var command = new DeleteFollowCommand(
            existingFollow.Id,
            null
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var command = new DeleteFollowCommand(
            existingFollow.Id,
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var command = new DeleteFollowCommand(
            FollowTestUtilities.InvalidId,
            existingFollow.FollowerId
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var command = new DeleteFollowCommand(
            existingFollow.Id,
            existingUser.Id
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
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var command = new DeleteFollowCommand(
            existingFollow.Id,
            existingFollow.FollowerId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        var follow = await FollowWriteRepository.GetByIdAsync(existingFollow.Id, CancellationToken);

        follow
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteMessage_WhenMessageIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var command = new DeleteFollowCommand(
            SharedTestUtilities.GetNonCaseMatchingString(existingFollow.Id),
            existingFollow.FollowerId
        );

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        var follow = await FollowWriteRepository.GetByIdAsync(existingFollow.Id, CancellationToken);

        follow
            .Should()
            .BeNull();
    }
}
