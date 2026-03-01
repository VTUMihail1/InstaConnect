using InstaConnect.Follows.Application.Features.Users.Commands.Delete;

namespace InstaConnect.Follows.Presentation.Features.Users.EventHandlers;

public class UserDeletedEventHandler : IEventHandler<UserDeletedEventRequest>
{
    private readonly IApplicationMapper _mapper;
    private readonly IApplicationSender _sender;

    public UserDeletedEventHandler(
        IApplicationMapper mapper,
        IApplicationSender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    public async Task Consume(ConsumeContext<UserDeletedEventRequest> context)
    {
        var request = _mapper.Map<DeleteUserCommandRequest>(context.Message);
        await _sender.SendAsync(request, context.CancellationToken);
    }
}
