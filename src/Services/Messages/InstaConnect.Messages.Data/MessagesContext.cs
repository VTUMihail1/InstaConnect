using InstaConnect.Messages.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Data;

public class MessagesContext : DbContext
{
    public MessagesContext(DbContextOptions<MessagesContext> options) : base(options)
    {
    }

    public DbSet<Message> Messages { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var currentAssembly = typeof(MessagesContext).Assembly;

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
    }
}
