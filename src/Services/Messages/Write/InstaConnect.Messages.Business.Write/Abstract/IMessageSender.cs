using InstaConnect.Messages.Business.Write.Models;

namespace InstaConnect.Messages.Business.Write.Abstract;

public interface IMessageSender
{
    Task SendMessageToUserAsync(SendMessageModel sendMessageDTO);
}
