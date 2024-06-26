using InstaConnect.Messages.Data.Read.EntitiyConfigurations;
using InstaConnect.Messages.Data.Read.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Data.Read;

public class MessagesContext : DbContext
{
    public MessagesContext(DbContextOptions<MessagesContext> options) : base(options)
    {
    }

    public DbSet<Message> Messages { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new MessageConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
