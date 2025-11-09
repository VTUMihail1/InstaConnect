namespace InstaConnect.Posts.Presentation.Tests.Unit.Features.Users.EventHandlers.v1;

public class DeleteUserEventHandlerUnitTests : BaseUserPresentationUnitTest
{
    private readonly UserDeletedEventRequestBuilderFactory _requestBuilderFactory;
    private readonly UserDeletedEventRequestBuilder _requestBuilder;
    private readonly UserDeletedEventRequest _request;

    private readonly UserDeletedEventHandler _handler;

    public DeleteUserEventHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
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
