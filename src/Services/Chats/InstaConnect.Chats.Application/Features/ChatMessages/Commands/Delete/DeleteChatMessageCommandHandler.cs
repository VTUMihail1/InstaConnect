namespace InstaConnect.Chats.Application.Features.ChatMessages.Commands.Delete;

internal class DeleteChatMessageCommandHandler : ICommandHandler<DeleteChatMessageCommandRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IChatMessageService _chatMessageService;

    public DeleteChatMessageCommandHandler(
        IApplicationMapper applicationMapper,
        IChatMessageService chatMessageService)
    {
        _applicationMapper = applicationMapper;
        _chatMessageService = chatMessageService;
    }

    public async Task Handle(
        DeleteChatMessageCommandRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeleteChatMessageCommand>(request);
        await _chatMessageService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
