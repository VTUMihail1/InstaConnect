using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;

namespace InstaConnect.Identity.Application.UnitTests.Features.EmailConfirmationTokens.Commands.Add;

public class AddEmailConfirmationTokenCommandHandlerUnitTests : BaseEmailConfirmationTokenUnitTest
{
    private readonly AddEmailConfirmationTokenCommandHandler _commandHandler;

    public AddEmailConfirmationTokenCommandHandlerUnitTests()
    {
        _commandHandler = new(
            UnitOfWork,
            InstaConnectMapper,
            UserWriteRepository,
            EmailConfirmationTokenPublisher);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenEmailIsInvalid()
    {
        // Arrange
        var command = new AddEmailConfirmationTokenCommand(UserTestUtilities.ValidAddEmail);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowUserEmailAlreadyConfirmedException_WhenEmailIsConfirmed()
    {
        // Arrange
        var existingUser = CreateUserWithConfirmedEmail();
        var command = new AddEmailConfirmationTokenCommand(existingUser.Email);

        // Act
        var action = async () => await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserEmailAlreadyConfirmedException>();
    }

    [Fact]
    public async Task Handle_ShouldCallTheEmailConfirmationTokenPublisher_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddEmailConfirmationTokenCommand(existingUser.Email);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await EmailConfirmationTokenPublisher
            .Received(1)
            .PublishEmailConfirmationTokenAsync(Arg.Is<CreateEmailConfirmationTokenModel>(uc => uc.UserId == existingUser.Id &&
                                                                                          uc.Email == existingUser.Email), CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldCallTheUnitOfWorkSaveChanges_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var command = new AddEmailConfirmationTokenCommand(existingUser.Email);

        // Act
        await _commandHandler.Handle(command, CancellationToken);

        // Assert
        await UnitOfWork
            .Received(1)
            .SaveChangesAsync(CancellationToken);
    }
}
