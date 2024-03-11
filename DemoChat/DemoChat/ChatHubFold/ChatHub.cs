using ChatModels;
using Microsoft.AspNetCore.SignalR;

namespace DemoChat.ChatHubFold
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Chat chat)
            => await Clients.All.SendAsync("RecieveMessage", chat);
    }
}
