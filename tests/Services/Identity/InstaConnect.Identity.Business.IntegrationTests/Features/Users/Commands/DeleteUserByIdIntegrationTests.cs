﻿using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.DeleteUserById;
using InstaConnect.Identity.Business.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Business.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Business.IntegrationTests.Features.Users.Commands;

public class DeleteUserByIdIntegrationTests : BaseUserIntegrationTest
{
    public DeleteUserByIdIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new DeleteUserByIdCommand(null!);

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
        var command = new DeleteUserByIdCommand(SharedTestUtilities.GetString(length));

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
        var command = new DeleteUserByIdCommand(UserTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteUserById_WhenUserIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var command = new DeleteUserByIdCommand(existingUserId);

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
        var command = new DeleteUserByIdCommand(existingUserId);

        // Act
        await InstaConnectSender.SendAsync(command, CancellationToken);

        await TestHarness.InactivityTask;
        var result = await TestHarness.Published.Any<UserDeletedEvent>(m =>
                              m.Context.Message.Id == existingUserId, CancellationToken);

        // Assert
        result.Should().BeTrue();
    }
}
