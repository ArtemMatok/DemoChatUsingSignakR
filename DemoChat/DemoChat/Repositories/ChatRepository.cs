using ChatModels;
using DemoChat.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoChat.Repositories
{
    public class ChatRepository(ApplicationDbContext _context)
    {
        public async Task SaveChatAsync(Chat chat)
        {
            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Chat>> GetChatsAsync()
            => await _context.Chats.ToListAsync();
    }
}
