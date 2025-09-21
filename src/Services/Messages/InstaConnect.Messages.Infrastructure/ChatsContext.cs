using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Infrastructure.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Messages.Infrastructure;

public class ChatsContext : DbContext
{
    public ChatsContext(DbContextOptions<ChatsContext> options) : base(options)
    {
    }

    public DbSet<Chat> Chats { get; set; }

    public DbSet<ChatMessage> ChatMessages { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(ChatInfrastructureReference.Assembly);
    }
}
