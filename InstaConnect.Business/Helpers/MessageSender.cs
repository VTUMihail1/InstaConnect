using InstaConnect.Business.Abstraction.Helpers;
using InstaConnect.Business.Helpers.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Business.Helpers
{
    public class MessageSender : IMessageSender
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public MessageSender(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageToUserAsync(string receiverId, string content)
        {
            await _hubContext.Clients.User(receiverId).SendAsync("ReceiveMessage", content);
        }
    }
}
