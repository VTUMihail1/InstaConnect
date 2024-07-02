using InstaConnect.Messages.Business.Write.Abstract;
using InstaConnect.Messages.Business.Write.Helpers.Hubs;
using InstaConnect.Messages.Business.Write.Models;
using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Messages.Business.Write.Helpers;

public class MessageSender : IMessageSender
{
    private readonly IHubContext<ChatHub> _hubContext;

    public MessageSender(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessageToUserAsync(SendMessageModel sendMessageDTO)
    {
        await _hubContext.Clients.User(sendMessageDTO.ReceiverId).SendAsync("ReceiveMessage", sendMessageDTO.Content);
    }
}
