using ChatModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace DemoChat.Client.ChatServices
{
    public class ChatService
    {
        public Action? InvokeChatDisplay { get; set; }
        public List<Chat> Chats { get; set; } = [];
        private readonly HubConnection _hubConnection;

        public ChatService(NavigationManager navigationManager)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(navigationManager.ToAbsoluteUri("/chathub"))
                .Build();
        }

        public void ReceiveMessage()
        {
            _hubConnection.On<Chat>("ReceiveMessage", (chat) =>
            {
                Chats.Add(chat);
                InvokeChatDisplay?.Invoke();
            });
        }
    }
}
