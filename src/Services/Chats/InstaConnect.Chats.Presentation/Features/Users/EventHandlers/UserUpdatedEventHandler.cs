using InstaConnect.Chats.Application.Features.Users.Commands.Update;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Presentation.Features.Events.Abstractions;

namespace InstaConnect.Chats.Presentation.Features.Users.EventHandlers;

public class UserUpdatedEventHandler : IEventHandler<UserUpdatedEventRequest>
{
    private readonly IApplicationMapper _mapper;
    private readonly IApplicationSender _sender;

    public UserUpdatedEventHandler(
        IApplicationMapper mapper,
        IApplicationSender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    public async Task Consume(ConsumeContext<UserUpdatedEventRequest> context)
    {
        var request = _mapper.Map<UpdateUserCommandRequest>(context.Message);
        await _sender.SendAsync(request, context.CancellationToken);
    }
}
