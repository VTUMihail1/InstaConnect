﻿using Microsoft.AspNetCore.SignalR;

namespace InstaConnect.Business.Helpers.Hubs
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
