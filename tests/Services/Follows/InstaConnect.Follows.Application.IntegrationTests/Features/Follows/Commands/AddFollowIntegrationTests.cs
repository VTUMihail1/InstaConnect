using FluentAssertions;
using InstaConnect.Follows.Application.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Utilities;
using InstaConnect.Follows.Application.IntegrationTests.Utilities;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Commands;
public class AddFollowIntegrationTests : BaseFollowIntegrationTest
{
    public AddFollowIntegrationTests(FollowsIntegrationTestWebAppFactory followIntegrationTestWebAppFactory) : base(followIntegrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            null!,
            existingFollowingId);

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
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            SharedTestUtilities.GetString(length),
            existingFollowingId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFollowingIdIsNull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            existingFollowerId,
            null!);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            existingFollowerId,
            SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            FollowTestUtilities.InvalidUserId,
            existingFollowingId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenFollowingIdIsInvalid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            existingFollowerId,
            FollowTestUtilities.InvalidUserId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFollowAlreadyExists()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var command = new AddFollowCommand(
            existingFollowerId,
            existingFollowingId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddMessage_WhenMessageIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            existingFollowerId,
            existingFollowingId);

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var follow = await FollowWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        follow
            .Should()
            .Match<Follow>(m => m.Id == response.Id &&
                                 m.FollowerId == existingFollowerId &&
                                 m.FollowingId == existingFollowingId);
    }
}
