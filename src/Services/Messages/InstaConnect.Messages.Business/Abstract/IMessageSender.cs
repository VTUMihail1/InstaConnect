using InstaConnect.Messages.Business.Models;

namespace InstaConnect.Messages.Business.Abstract;

public interface IMessageSender
{
    Task SendMessageToUserAsync(SendMessageModel sendMessageDTO);
}
