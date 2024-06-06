using InstaConnect.Messages.Business.Abstract.Helpers;
using InstaConnect.Messages.Business.Helpers.Hubs;
using InstaConnect.Messages.Business.Models;
using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Messages.Business.Helpers;

public class MessageSender : IMessageSender
{
    private readonly IHubContext<ChatHub> _hubContext;

    public MessageSender(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessageToUserAsync(SendMessageDTO sendMessageDTO)
    {
        await _hubContext.Clients.User(sendMessageDTO.ReceiverId).SendAsync("ReceiveMessage", sendMessageDTO.Content);
    }
}
