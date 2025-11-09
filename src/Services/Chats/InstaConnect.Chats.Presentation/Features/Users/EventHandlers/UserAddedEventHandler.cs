using InstaConnect.Chats.Application.Features.Users.Commands.Add;

namespace InstaConnect.Chats.Presentation.Features.Users.EventHandlers;

internal class UserAddedEventHandler : IEventHandler<UserAddedEventRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public UserAddedEventHandler(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    public async Task Consume(ConsumeContext<UserAddedEventRequest> context)
    {
        var request = _applicationMapper.Map<AddUserCommandRequest>(context.Message);
        await _applicationSender.SendAsync(request, context.CancellationToken);
    }
}
