using InstaConnect.Follows.Application.Features.Users.Commands.Update;

namespace InstaConnect.Chats.Presentation.Features.Users.EventHandlers;

internal class UserUpdatedEventHandler : IEventHandler<UserUpdatedEventRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public UserUpdatedEventHandler(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    public async Task Consume(ConsumeContext<UserUpdatedEventRequest> context)
    {
        var request = _applicationMapper.Map<UpdateUserCommandRequest>(context.Message);
        await _applicationSender.SendAsync(request, context.CancellationToken);
    }
}
