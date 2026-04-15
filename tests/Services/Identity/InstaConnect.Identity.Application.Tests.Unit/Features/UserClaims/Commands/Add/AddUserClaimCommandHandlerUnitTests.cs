namespace InstaConnect.Identity.Application.Tests.Unit.Features.UserClaims.Commands.Add;

public class AddUserClaimCommandHandlerUnitTests : BaseUserClaimApplicationCommandUnitTest
{
    private readonly AddUserClaimCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddUserClaimCommandRequestBuilder _requestBuilder;
    private readonly AddUserClaimCommandRequest _request;

    private readonly AddUserClaimCommandHandler _handler;

    public AddUserClaimCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, Service);

        Service.SetupAddCommand(_request, UserClaim, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(UserClaim, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallServiceAddAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await Service.ShouldReceiveOneAddAsync(_request, CancellationToken);
    }
}
