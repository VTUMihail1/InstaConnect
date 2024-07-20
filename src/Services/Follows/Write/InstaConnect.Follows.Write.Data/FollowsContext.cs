﻿using InstaConnect.Follows.Write.Data.Models.Entities;
using InstaConnect.Shared.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Follows.Write.Data;

public class FollowsContext : DbContext
{
    public FollowsContext(DbContextOptions<FollowsContext> options) : base(options)
    { }

    public DbSet<Follow> Follows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var currentAssembly = typeof(FollowsContext).Assembly;

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);

        modelBuilder.ApplyTransactionalOutboxEntityConfiguration();
    }
}