namespace InstaConnect.Chats.Application.Tests.Unit.Features.ChatMessages.Commands.Delete;

public class DeleteChatMessageCommandHandlerUnitTests : BaseChatMessageApplicationCommandUnitTest
{
    private readonly DeleteChatMessageCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteChatMessageCommandRequestBuilder _requestBuilder;
    private readonly DeleteChatMessageCommandRequest _request;

    private readonly DeleteChatMessageCommandHandler _handler;

    public DeleteChatMessageCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(ChatMessage);
        _request = _requestBuilder.Build();

        _handler = new(Mapper, CommentService);
    }

    [Fact]
    public async Task Handle_ShouldCallCommentServiceDeleteAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await CommentService.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
    }
}
