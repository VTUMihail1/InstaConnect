﻿using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Commands.SendUserPasswordReset;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Business.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Users.Commands.SendUserPasswordReset;

public class SendUserPasswordResetCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly SendUserPasswordResetCommandHandler _commandHandler;

    public SendUserPasswordResetCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository,
            ForgotPasswordTokenPublisher);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenEmailIsInvalid()
    {
        // Arrange
        var command = new SendUserPasswordResetCommand(UserTestUtilities.InvalidEmail);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallTheForgotPasswordTokenPublisher_WhenRequestIsValid()
    {
        // Arrange
        var command = new SendUserPasswordResetCommand(UserTestUtilities.ValidEmail);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ForgotPasswordTokenPublisher
            .Received(1)
            .PublishForgotPasswordTokenAsync(Arg.Is<CreateForgotPasswordTokenModel>(uc => uc.UserId == UserTestUtilities.ValidId &&
                                                                                          uc.Email == UserTestUtilities.ValidEmail), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var command = new SendUserPasswordResetCommand(UserTestUtilities.ValidEmail);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
