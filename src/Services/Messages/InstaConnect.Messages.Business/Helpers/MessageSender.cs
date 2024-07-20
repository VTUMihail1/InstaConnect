using InstaConnect.Messages.Business.Abstract;
using InstaConnect.Messages.Business.Helpers.Hubs;
using InstaConnect.Messages.Business.Models;
using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Messages.Business.Helpers;

internal class MessageSender : IMessageSender
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
