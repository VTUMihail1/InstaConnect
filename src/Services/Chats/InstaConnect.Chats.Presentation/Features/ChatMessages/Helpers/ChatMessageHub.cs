using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Presentation.Features.ChatMessages.Abstractions;
using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Helpers;

[Authorize]
public class ChatMessageHub : Hub<IChatMessageHubClient>
{
	private readonly IApplicationMapper _mapper;

	public ChatMessageHub(IApplicationMapper mapper)
	{
		_mapper = mapper;
	}

	public async Task TypingStarted(TypingStartedHubRequest request)
	{
		await Clients.User(request.ParticipantTwoId).TypingStarted(_mapper.Map<TypingStartedNotificationRequest>(Context));
	}
}
