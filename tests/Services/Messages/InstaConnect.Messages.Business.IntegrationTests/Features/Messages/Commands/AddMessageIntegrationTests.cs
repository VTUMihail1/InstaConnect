﻿using Bogus;
using FluentAssertions;
using InstaConnect.Messages.Business.Features.Messages.Commands.AddMessage;
using InstaConnect.Messages.Business.Features.Messages.Utilities;
using InstaConnect.Messages.Business.IntegrationTests.Features.Messages.Utilities;
using InstaConnect.Messages.Business.IntegrationTests.Utilities;
using InstaConnect.Messages.Data.Features.Messages.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.User;

namespace InstaConnect.Messages.Business.IntegrationTests.Features.Messages.Commands;
public class AddMessageIntegrationTests : BaseMessageIntegrationTest
{
    public AddMessageIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {

    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            null!,
            existingReceiverId,
            ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            Faker.Random.AlphaNumeric(length),
            existingReceiverId,
            ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenReceiverIdIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSenderId,
            null!,
            ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.RECEIVER_ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenReceiverIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSenderId,
            Faker.Random.AlphaNumeric(length),
            ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenContentIsNull()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSenderId,
            existingReceiverId,
            null!
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(MessageBusinessConfigurations.CONTENT_MIN_LENGTH - 1)]
    [InlineData(MessageBusinessConfigurations.CONTENT_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenContentLengthIsInvalid(int length)
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSenderId,
            existingReceiverId,
            Faker.Random.AlphaNumeric(length)
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            InvalidUserId,
            existingReceiverId,
            ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenReceiverIdIsInvalid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSenderId,
            InvalidUserId,
            ValidAddContent
        );

        // Act
        var action = async () => await InstaConnectSender.SendAsync(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldAddMessage_WhenMessageIsValid()
    {
        // Arrange
        var existingSenderId = await CreateUserAsync(CancellationToken);
        var existingReceiverId = await CreateUserAsync(CancellationToken);
        var command = new AddMessageCommand(
            existingSenderId,
            existingReceiverId,
            ValidAddContent
        );

        // Act
        var response = await InstaConnectSender.SendAsync(command, CancellationToken);
        var message = await MessageWriteRepository.GetByIdAsync(response.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Message>(m => m.Id == response.Id &&
                                 m.SenderId == existingSenderId &&
                                 m.ReceiverId == existingReceiverId &&
                                 m.Content == ValidAddContent);
    }
}