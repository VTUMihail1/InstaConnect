using InstaConnect.Messages.Write.Business.Models;

namespace InstaConnect.Messages.Write.Business.Abstract;

public interface IMessageSender
{
    Task SendMessageToUserAsync(SendMessageModel sendMessageDTO);
}
