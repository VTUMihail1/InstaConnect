namespace InstaConnect.Chats.Application.Features.Chats.Commands.Delete;

internal class DeleteChatCommandHandler : ICommandHandler<DeleteChatCommandRequest>
{
    private readonly IApplicationMapper _mapper;
    private readonly IChatCommandService _service;

    public DeleteChatCommandHandler(
        IApplicationMapper mapper,
        IChatCommandService service)
    {
        _mapper = mapper;
        _service = service;
    }

    public async Task Handle(
        DeleteChatCommandRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _mapper.Map<DeleteChatCommand>(request);
        await _service.DeleteAsync(serviceRequest, cancellationToken);
    }
}
