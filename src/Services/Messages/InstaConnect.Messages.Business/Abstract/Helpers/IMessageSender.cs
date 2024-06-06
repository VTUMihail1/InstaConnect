using InstaConnect.Messages.Business.Models;

namespace InstaConnect.Messages.Business.Abstract.Helpers;

public interface IMessageSender
{
    Task SendMessageToUserAsync(SendMessageDTO sendMessageDTO);
}
