using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;

namespace InstaConnect.Identity.Application.UnitTests.Features.ForgotPasswordTokens.Commands.Add;

public class AddForgotPasswordTokenCommandHandlerUnitTests : BaseForgotPasswordTokenUnitTest
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
        var existingUser = CreateUser();
        var command = new AddForgotPasswordTokenCommand(UserTestUtilities.ValidAddEmail);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldCallTheForgotPasswordTokenPublisher_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddForgotPasswordTokenCommand(existingUser.Email);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await ForgotPasswordTokenPublisher
            .Received(1)
            .PublishForgotPasswordTokenAsync(Arg.Is<CreateForgotPasswordTokenModel>(uc => uc.UserId == existingUser.Id &&
                                                                                          uc.Email == existingUser.Email), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddForgotPasswordTokenCommand(existingUser.Email);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
