namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Users.EventHandlers.v1;

public class AddUserEventHandlerUnitTests : BaseUserPresentationUnitTest
{
    private readonly UserAddedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserAddedEventRequestBuilder _requestBuilder;
    private readonly UserAddedEventRequest _request;

    private readonly UserAddedEventHandler _handler;

    public AddUserEventHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create();
        _request = _requestBuilder.Build();

        _handler = new(ApplicationMapper, ApplicationSender);
    }

    [Fact]
    public async Task Consume_ShouldCallTheApplicationSenderSendAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Consume(_request, CancellationToken);

        // Assert
        await ApplicationSender.ShouldReceiveOneSendAsync(_request, CancellationToken);
    }
}
