using InstaConnect.Follows.Data.Read.EntitiyConfigurations;
using InstaConnect.Follows.Data.Read.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Data.Read;

public class FollowsContext : DbContext
{
    public FollowsContext(DbContextOptions<FollowsContext> options) : base(options)
    { }

    public DbSet<Follow> Follows { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var currentAssembly = typeof(FollowsContext).Assembly;

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
    }
}
