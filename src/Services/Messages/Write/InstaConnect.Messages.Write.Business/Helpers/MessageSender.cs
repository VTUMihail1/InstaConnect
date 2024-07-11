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

    public async Task SendMessageToUserAsync(MessageSendModel messageSendModel, CancellationToken cancellationToken)
    {
        await _hubContext
            .Clients
            .User(messageSendModel.ReceiverId)
            .SendAsync("ReceiveMessage", messageSendModel.Content, cancellationToken);
    }
}
