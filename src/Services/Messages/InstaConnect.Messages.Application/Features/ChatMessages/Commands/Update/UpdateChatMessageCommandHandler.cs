using InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Update;

internal class UpdateChatMessageCommandHandler : ICommandHandler<UpdateChatMessageCommandRequest, UpdateChatMessageCommandResponse>
{
    private readonly IChatMessageService _chatMessageService;
    private readonly IApplicationMapper _applicationMapper;

    public UpdateChatMessageCommandHandler(
        IChatMessageService chatMessageService,
        IApplicationMapper applicationMapper)
    {
        _chatMessageService = chatMessageService;
        _applicationMapper = applicationMapper;
    }

    public async Task<UpdateChatMessageCommandResponse> Handle(UpdateChatMessageCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<UpdateChatMessageCommand>(request);
        var chatMessage = await _chatMessageService.UpdateAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<UpdateChatMessageCommandResponse>(chatMessage);

        return response;
    }
}
