using InstaConnect.Messages.Domain.Features.Messages.Models;

namespace InstaConnect.Messages.Domain.Features.Messages.Abstractions;

public interface IMessageSender
{
    Task SendMessageToUserAsync(MessageSendModel messageSendModel, CancellationToken cancellationToken);
}
