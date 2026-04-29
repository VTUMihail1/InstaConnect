using InstaConnect.Chats.Application.Features.Users.Commands.Add;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;
using InstaConnect.Common.Presentation.Features.Events.Abstractions;

namespace InstaConnect.Chats.Presentation.Features.Users.EventHandlers;

public class UserAddedEventHandler : IEventHandler<UserAddedEventRequest>
{
	private readonly IApplicationMapper _mapper;
	private readonly IApplicationSender _sender;

	public UserAddedEventHandler(
		IApplicationMapper mapper,
		IApplicationSender sender)
	{
		_mapper = mapper;
		_sender = sender;
	}

	public async Task Consume(ConsumeContext<UserAddedEventRequest> context)
	{
		var request = _mapper.Map<AddUserCommandRequest>(context.Message);
		await _sender.SendAsync(request, context.CancellationToken);
	}
}
