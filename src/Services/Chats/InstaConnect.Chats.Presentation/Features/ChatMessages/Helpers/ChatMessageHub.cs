using InstaConnect.Chats.Presentation.Features.ChatMessages.Abstractions;

using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Helpers;

[Authorize]
public class ChatMessageHub : Hub<IChatMessageHubClient>;
