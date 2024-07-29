using InstaConnect.Messages.Business.Features.Messages.Models;

namespace InstaConnect.Messages.Business.Features.Messages.Abstractions;

public interface IMessageSender
{
    Task SendMessageToUserAsync(MessageSendModel messageSendModel, CancellationToken cancellationToken);
}
