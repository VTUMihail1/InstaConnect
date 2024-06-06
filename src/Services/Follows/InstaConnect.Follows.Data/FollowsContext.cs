using InstaConnect.Follows.Data.EntitiyConfigurations;
using InstaConnect.Follows.Data.Models.Entities;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Data;

public class FollowsContext : BaseDbContext
{
    public FollowsContext(DbContextOptions<FollowsContext> options) : base(options)
    { }

    public DbSet<Follow> Follows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new FollowConfiguration());
    }
}
