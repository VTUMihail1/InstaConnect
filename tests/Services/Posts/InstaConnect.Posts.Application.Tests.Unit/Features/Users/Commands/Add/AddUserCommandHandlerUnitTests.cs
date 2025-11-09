namespace InstaConnect.Posts.Application.Tests.Unit.Features.Users.Commands.Add;

public class AddUserCommandHandlerUnitTests : BaseUserApplicationUnitTest
{
    private readonly AddUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddUserCommandRequestBuilder _requestBuilder;
    private readonly AddUserCommandRequest _request;

    private readonly AddUserCommandHandler _handler;

    public AddUserCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create();
        _request = _requestBuilder.Build();

        _handler = new(UserService, ApplicationMapper);

        UserService.SetupAddCommand(_request, User, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(User);
    }

    [Fact]
    public async Task Handle_ShouldCallUserServiceAddAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await UserService.ShouldReceiveOneAddAsync(_request, CancellationToken);
    }
}
