using InstaConnect.Follows.Application.Features.Follows.Commands.Add;

namespace InstaConnect.Follows.Application.IntegrationTests.Features.Follows.Commands;
public class AddFollowIntegrationTests : BaseFollowIntegrationTest
{
    public AddFollowIntegrationTests(FollowsWebApplicationFactory followsWebApplicationFactory) : base(followsWebApplicationFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingFollowing = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            null,
            existingFollowing.Id);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowing = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            SharedTestUtilities.GetString(length),
            existingFollowing.Id);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenFollowingIdIsNull()
    {
        // Arrange
        var existingFollower = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            existingFollower.Id,
            null);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollower = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            existingFollower.Id,
            SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingFollowing = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            UserTestUtilities.InvalidId,
            existingFollowing.Id);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenFollowingIdIsInvalid()
    {
        // Arrange
        var existingFollower = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            existingFollower.Id,
            UserTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenFollowAlreadyExists()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var command = new AddFollowCommand(
            existingFollow.FollowerId,
            existingFollow.FollowingId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<FollowAlreadyExistsException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddMessage_WhenMessageIsValid()
    {
        // Arrange
        var existingFollower = await CreateUserAsync(CancellationToken);
        var existingFollowing = await CreateUserAsync(CancellationToken);
        var command = new AddFollowCommand(
            existingFollower.Id,
            existingFollowing.Id);

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var follow = await FollowWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        follow
            .Should()
            .Match<Follow>(m => m.Id == response.Id &&
                                 m.FollowerId == existingFollower.Id &&
                                 m.FollowingId == existingFollowing.Id);
    }
}
