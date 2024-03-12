using ChatModels;
using DemoChat.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace DemoChat.ChatHubFold
{
    public class ChatHub(ChatRepository _chatRepository) : Hub
    {
       public async Task SendMessage(Chat chat)
       {
            await _chatRepository.SaveChatAsync(chat);
            await Clients.All.SendAsync("ReceiveMessage", chat);
       }
    }
}
