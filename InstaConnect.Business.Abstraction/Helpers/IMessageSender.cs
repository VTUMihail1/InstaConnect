namespace InstaConnect.Business.Abstraction.Helpers
{
    public interface IMessageSender
    {
        Task SendMessageToUserAsync(string userId, string content);
    }
}