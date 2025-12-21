using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;
public static class PostSetups
{
    public static IPostRepository GetPostRepository(this IServiceScope serviceScope)
    {
        var postRepository = serviceScope.ServiceProvider.GetRequiredService<IPostRepository>();

        return postRepository;
    }

    public static async Task<Post?> GetPostByIdAsync(
        this IServiceScope serviceScope,
        PostId id,
        CancellationToken cancellationToken)
    {
        var postRepository = serviceScope.GetPostRepository();

        return await postRepository.GetByIdAsync(id, cancellationToken);
    }

    public static async Task AddPostAsync(
        this IServiceScope serviceScope,
        Post post,
        CancellationToken cancellationToken)
    {
        var postRepository = serviceScope.GetPostRepository();

        await postRepository.AddAsync(post, cancellationToken);
    }

    public static async Task AddPostRangeAsync(
        this IServiceScope serviceScope,
        IEnumerable<Post> posts,
        CancellationToken cancellationToken)
    {
        var postRepository = serviceScope.GetPostRepository();

        await postRepository.AddRangeAsync(posts, cancellationToken);
    }

    public static async Task DeletePostAsync(
        this IServiceScope serviceScope,
        Post post,
        CancellationToken cancellationToken)
    {
        var postRepository = serviceScope.GetPostRepository();

        await postRepository.DeleteAsync(post, cancellationToken);
    }

    public static async Task ResetPostDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<IPostsContext>();

        await context.Posts.ResetAsync(cancellationToken);
        await context.Users.ResetAsync(cancellationToken);
    }
}
