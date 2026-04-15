namespace InstaConnect.Follows.Presentation.Tests.Unit.Features.Users.EventHandlers.v1;

public class UpdateUserEventHandlerUnitTests : BaseUserPresentationCommandUnitTest
{
    private readonly UserUpdatedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserUpdatedEventRequestBuilder _requestBuilder;
    private readonly UserUpdatedEventRequest _request;

    private readonly UserUpdatedEventHandler _handler;

    public UpdateUserEventHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, Sender);
    }

    [Fact]
    public async Task Consume_ShouldCallTheSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Consume(_request, CancellationToken);

        // Assert
        await Sender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
