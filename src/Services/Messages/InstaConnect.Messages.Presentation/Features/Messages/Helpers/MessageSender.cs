using InstaConnect.Messages.Domain.Features.Messages.Abstractions;
using InstaConnect.Messages.Domain.Features.Messages.Models;
using InstaConnect.Messages.Presentation.Features.Messages.Helpers.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Messages.Presentation.Features.Messages.Helpers;

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
