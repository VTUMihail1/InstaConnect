using InstaConnect.Messages.Domain.Features.Messages.Models.Entities;
using InstaConnect.Messages.Domain.Features.Users.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Infrastructure;

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
