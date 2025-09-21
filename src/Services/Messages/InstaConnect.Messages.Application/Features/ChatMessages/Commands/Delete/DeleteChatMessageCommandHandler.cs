using InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Add;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Commands.Delete;

internal class DeleteChatMessageCommandHandler : ICommandHandler<DeleteChatMessageCommandRequest>
{
    private readonly IChatMessageService _chatMessageService;
    private readonly IApplicationMapper _applicationMapper;

    public DeleteChatMessageCommandHandler(
        IChatMessageService chatMessageService,
        IApplicationMapper applicationMapper)
    {
        _chatMessageService = chatMessageService;
        _applicationMapper = applicationMapper;
    }

    public async Task Handle(
        DeleteChatMessageCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeleteChatMessageCommand>(request);
        await _chatMessageService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
