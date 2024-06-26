using InstaConnect.Follows.Data.Write.EntitiyConfigurations;
using InstaConnect.Follows.Data.Write.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Data.Write;

public class FollowsContext : DbContext
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
