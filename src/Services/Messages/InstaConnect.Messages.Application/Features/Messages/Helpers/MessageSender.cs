using InstaConnect.Messages.Business.Features.Messages.Abstractions;
using InstaConnect.Messages.Business.Features.Messages.Helpers.Hubs;
using InstaConnect.Messages.Business.Features.Messages.Models;
using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Messages.Business.Features.Messages.Helpers;

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
