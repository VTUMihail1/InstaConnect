using InstaConnect.Follows.Application.Features.Users.Commands.Delete;

namespace InstaConnect.Chats.Presentation.Features.Users.EventHandlers;

internal class UserDeletedEventHandler : IEventHandler<UserDeletedEventRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public UserDeletedEventHandler(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    public async Task Consume(ConsumeContext<UserDeletedEventRequest> context)
    {
        var request = _applicationMapper.Map<DeleteUserCommandRequest>(context.Message);
        await _applicationSender.SendAsync(request, context.CancellationToken);
    }
}
