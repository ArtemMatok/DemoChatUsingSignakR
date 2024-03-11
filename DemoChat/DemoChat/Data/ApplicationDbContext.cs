using ChatModels;
using Microsoft.EntityFrameworkCore;

namespace DemoChat.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<Chat> Chats { get; set; }

    }
}
