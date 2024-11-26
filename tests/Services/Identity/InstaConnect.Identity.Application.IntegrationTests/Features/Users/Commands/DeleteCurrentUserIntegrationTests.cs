using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrentUser;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Application.Contracts.Users;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Commands;

public class DeleteCurrentUserIntegrationTests : BaseUserIntegrationTest
{
    public DeleteCurrentUserIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new DeleteCurrentUserCommand(null!);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new DeleteCurrentUserCommand(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new DeleteCurrentUserCommand(UserTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteCurrentUser_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new DeleteCurrentUserCommand(existingUserId);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);
        var user = await UserWriteRepository.GetByIdAsync(existingUserId, CancellationToken);

        // Assert
        user
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task SendAsync_ShouldPublishUserUpdateEvent_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new DeleteCurrentUserCommand(existingUserId);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserDeletedEvent>(m =>
                              m.Context.Message.Id == existingUserId, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
