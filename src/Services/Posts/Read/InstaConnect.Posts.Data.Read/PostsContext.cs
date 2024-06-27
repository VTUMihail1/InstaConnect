using InstaConnect.Messages.Data.Read.EntitiyConfigurations;
using InstaConnect.Messages.Data.Read.Models.Entities;
using InstaConnect.Posts.Data.Read.EntityConfigurations;
using InstaConnect.Posts.Data.Read.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Data.Read;

public class PostsContext : DbContext
{
    public PostsContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }

    public DbSet<PostLike> PostLikes { get; set; }

    public DbSet<PostCommentLike> PostCommentLikes { get; set; }

    public DbSet<PostComment> PostComments { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var currentAssembly = typeof(PostsContext).Assembly;

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
    }
}
