namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Queries.GetAll;

public class GetAllChatMessagesQueryHandlerUnitTests : BaseChatMessageApplicationQueryUnitTest
{
    private readonly GetAllChatMessagesQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllChatMessagesQueryRequestBuilder _requestBuilder;
    private readonly GetAllChatMessagesQueryRequest _request;

    private readonly GetAllChatMessagesQueryHandler _handler;

    public GetAllChatMessagesQueryHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(ChatMessage);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, CommentService);

        CommentService.SetupGetAllQuery(_request, Chat, ChatMessages, CancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await _handler.Handle(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Chat, ChatMessages, _request);
    }

    [Fact]
    public async Task Handle_ShouldCallCommentServiceGetAllAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await CommentService.ShouldReceiveOneGetAllAsync(_request, CancellationToken);
    }
}
