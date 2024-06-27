using InstaConnect.Posts.Data.EntityConfigurations;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Data;

public class PostsContext : DbContext
{
    public PostsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }

    public DbSet<PostLike> PostLikes { get; set; }

    public DbSet<PostComment> PostComments { get; set; }

    public DbSet<PostCommentLike> PostCommentLikes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var currentAssembly = typeof(PostsContext).Assembly;

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
    }
}
