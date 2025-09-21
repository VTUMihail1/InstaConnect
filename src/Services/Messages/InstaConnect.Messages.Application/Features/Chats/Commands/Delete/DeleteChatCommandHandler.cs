using InstaConnect.Chats.Application.Features.Chats.Commands.Add;
using InstaConnect.Chats.Domain.Features.Chats.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

namespace InstaConnect.Chats.Application.Features.Chats.Commands.Delete;

internal class DeleteChatCommandHandler : ICommandHandler<DeleteChatCommandRequest>
{
    private readonly IChatService _chatService;
    private readonly IApplicationMapper _applicationMapper;

    public DeleteChatCommandHandler(
        IChatService chatService,
        IApplicationMapper applicationMapper)
    {
        _chatService = chatService;
        _applicationMapper = applicationMapper;
    }

    public async Task Handle(
        DeleteChatCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeleteChatCommand>(request);
        await _chatService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
