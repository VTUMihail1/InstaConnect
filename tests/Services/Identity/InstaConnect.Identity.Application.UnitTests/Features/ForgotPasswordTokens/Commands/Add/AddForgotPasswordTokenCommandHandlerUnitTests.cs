using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Commands.SendUserPasswordReset;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.UnitTests.Features.Users.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Application.UnitTests.Features.Users.Commands.SendUserPasswordReset;

public class AddForgotPasswordTokenCommandHandlerUnitTests : BaseUserUnitTest
{
    private readonly AddForgotPasswordTokenCommandHandler _commandHandler;

    public AddForgotPasswordTokenCommandHandlerUnitTests()
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
        var command = new AddForgotPasswordTokenCommand(UserTestUtilities.InvalidEmail);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallTheForgotPasswordTokenPublisher_WhenRequestIsValid()
    {
        // Arrange
        var command = new AddForgotPasswordTokenCommand(UserTestUtilities.ValidEmail);

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
        var command = new AddForgotPasswordTokenCommand(UserTestUtilities.ValidEmail);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
