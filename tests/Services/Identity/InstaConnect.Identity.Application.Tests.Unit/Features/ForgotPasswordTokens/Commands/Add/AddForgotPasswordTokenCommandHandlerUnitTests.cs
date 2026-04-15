namespace InstaConnect.Identity.Application.Tests.Unit.Features.ForgotPasswordTokens.Commands.Add;

public class AddForgotPasswordTokenCommandHandlerUnitTests : BaseForgotPasswordTokenApplicationCommandUnitTest
{
    private readonly AddForgotPasswordTokenCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly AddForgotPasswordTokenCommandRequestBuilder _requestBuilder;
    private readonly AddForgotPasswordTokenCommandRequest _request;

    private readonly AddForgotPasswordTokenCommandHandler _handler;

    public AddForgotPasswordTokenCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, Service);

        Service.SetupAddCommand(_request, ForgotPasswordToken, CancellationToken);
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
