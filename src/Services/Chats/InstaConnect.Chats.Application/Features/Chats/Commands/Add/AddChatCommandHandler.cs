namespace InstaConnect.Chats.Application.Features.Chats.Commands.Add;

internal class AddChatCommandHandler : ICommandHandler<AddChatCommandRequest, AddChatCommandResponse>
{
    private readonly IChatService _chatService;
    private readonly IApplicationMapper _applicationMapper;

    public AddChatCommandHandler(
        IChatService chatService,
        IApplicationMapper applicationMapper)
    {
        _chatService = chatService;
        _applicationMapper = applicationMapper;
    }

    public async Task<AddChatCommandResponse> Handle(AddChatCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddChatCommand>(request);
        var chat = await _chatService.AddAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<AddChatCommandResponse>(chat);

        return response;
    }
}
