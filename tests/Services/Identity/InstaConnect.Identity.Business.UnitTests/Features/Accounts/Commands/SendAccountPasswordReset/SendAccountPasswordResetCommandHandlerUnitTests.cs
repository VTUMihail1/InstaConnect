using FluentAssertions;
using InstaConnect.Identity.Business.Features.Accounts.Commands.SendAccountPasswordReset;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Business.UnitTests.Features.Accounts.Utilities;
using InstaConnect.Shared.Business.Exceptions.User;
using NSubstitute;

namespace InstaConnect.Identity.Business.UnitTests.Features.Accounts.Commands.SendAccountPasswordReset;

public class SendAccountPasswordResetCommandHandlerUnitTests : BaseAccountUnitTest
{
    private readonly SendAccountPasswordResetCommandHandler _commandHandler;

    public SendAccountPasswordResetCommandHandlerUnitTests()
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
        var command = new SendAccountPasswordResetCommand(InvalidEmail);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallTheForgotPasswordTokenPublisher_WhenRequestIsValid()
    {
        // Arrange
        var command = new SendAccountPasswordResetCommand(ValidEmail);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ForgotPasswordTokenPublisher
            .Received(1)
            .PublishForgotPasswordTokenAsync(Arg.Is<CreateForgotPasswordTokenModel>(uc => uc.UserId == ValidId &&
                                                                                          uc.Email == ValidEmail), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var command = new SendAccountPasswordResetCommand(ValidEmail);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
