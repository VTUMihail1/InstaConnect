namespace InstaConnect.Chats.Application.Tests.Unit.Features.Users.Commands.Delete;

public class DeleteUserCommandHandlerUnitTests : BaseUserApplicationCommandUnitTest
{
    private readonly DeleteUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteUserCommandRequestBuilder _requestBuilder;
    private readonly DeleteUserCommandRequest _request;

    private readonly DeleteUserCommandHandler _handler;

    public DeleteUserCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, UserService);
    }

    [Fact]
    public async Task Handle_ShouldCallUserServiceDeleteAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await UserService.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
    }
}
