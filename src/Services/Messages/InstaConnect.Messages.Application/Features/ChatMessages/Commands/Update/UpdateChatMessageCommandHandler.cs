using InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Update;

internal class UpdateChatMessageCommandHandler : ICommandHandler<UpdateChatMessageCommandRequest, UpdateChatMessageCommandResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IChatMessageService _chatMessageService;

    public UpdateChatMessageCommandHandler(
        IApplicationMapper applicationMapper,
        IChatMessageService chatMessageService)
    {
        _applicationMapper = applicationMapper;
        _chatMessageService = chatMessageService;
    }

    public async Task<UpdateChatMessageCommandResponse> Handle(UpdateChatMessageCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<UpdateChatMessageCommand>(request);
        var chatMessage = await _chatMessageService.UpdateAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<UpdateChatMessageCommandResponse>(chatMessage);

        return response;
    }
}
