﻿namespace InstaConnect.Follows.Infrastructure;

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
