using Bogus;
using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Business.Features.Follows.Utilities;
using InstaConnect.Follows.Business.IntegrationTests.Features.Follows.Utilities;
using InstaConnect.Follows.Business.IntegrationTests.Utilities;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;

namespace InstaConnect.Follows.Business.IntegrationTests.Features.Follows.Commands;
public class AddFollowIntegrationTests : BaseFollowIntegrationTest
{
    public AddFollowIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
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
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            Faker.Random.AlphaNumeric(length),
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
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            existingFollowerId,
            Faker.Random.AlphaNumeric(length));

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
            InvalidUserId,
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
            InvalidUserId);

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
