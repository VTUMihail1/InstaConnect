using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Add;

internal class AddChatMessageCommandHandler : ICommandHandler<AddChatMessageCommandRequest, AddChatMessageCommandResponse>
{
    private readonly IChatMessageService _chatMessageService;
    private readonly IApplicationMapper _applicationMapper;

    public AddChatMessageCommandHandler(
        IChatMessageService chatMessageService,
        IApplicationMapper applicationMapper)
    {
        _chatMessageService = chatMessageService;
        _applicationMapper = applicationMapper;
    }

    public async Task<AddChatMessageCommandResponse> Handle(AddChatMessageCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddChatMessageCommand>(request);
        var chatMessage = await _chatMessageService.AddAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<AddChatMessageCommandResponse>(chatMessage);

        return response;
    }
}
