using InstaConnect.Messages.Write.Business.Abstract;
using InstaConnect.Messages.Write.Business.Helpers.Hubs;
using InstaConnect.Messages.Write.Business.Models;
using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Messages.Write.Business.Helpers;

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
