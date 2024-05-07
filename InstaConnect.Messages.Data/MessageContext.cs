using InstaConnect.Messages.Data.EntitiyConfigurations;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Data;

public class MessageContext : BaseDbContext
{
    public MessageContext(DbContextOptions<MessageContext> options) : base(options)
    { }

    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new MessageConfiguration());
    }
}
