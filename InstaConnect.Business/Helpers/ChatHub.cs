using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;

namespace InstaConnect.Business.Helpers
{
    public class ChatHub : Hub
    {
        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
