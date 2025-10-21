using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Add;

internal class AddChatMessageCommandHandler : ICommandHandler<AddChatMessageCommandRequest, AddChatMessageCommandResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IChatMessageService _chatMessageService;

    public AddChatMessageCommandHandler(
        IApplicationMapper applicationMapper,
        IChatMessageService chatMessageService)
    {
        _applicationMapper = applicationMapper;
        _chatMessageService = chatMessageService;
    }

    public async Task<AddChatMessageCommandResponse> Handle(AddChatMessageCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddChatMessageCommand>(request);
        var chatMessage = await _chatMessageService.AddAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<AddChatMessageCommandResponse>(chatMessage);

        return response;
    }
}
