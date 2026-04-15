namespace InstaConnect.Identity.Application.Tests.Unit.Features.EmailConfirmationTokens.Commands.Add;

public class AddEmailConfirmationTokenCommandHandlerUnitTests : BaseEmailConfirmationTokenApplicationCommandUnitTest
{
    private readonly AddEmailConfirmationTokenCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddEmailConfirmationTokenCommandRequestBuilder _requestBuilder;
    private readonly AddEmailConfirmationTokenCommandRequest _request;

    private readonly AddEmailConfirmationTokenCommandHandler _handler;

    public AddEmailConfirmationTokenCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, Service);

        Service.SetupAddCommand(_request, EmailConfirmationToken, CancellationToken);
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
