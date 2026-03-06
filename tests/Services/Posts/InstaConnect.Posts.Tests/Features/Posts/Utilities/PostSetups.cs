using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.Posts.Utilities;

public static class PostSetups
{
    extension(IServiceScope serviceScope)
    {
        public IPostCommandRepository GetPostCommandRepository()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IPostCommandRepository>();
        }

        public IPostIncludeBuilderFactory GetPostIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetRequiredService<IPostIncludeBuilderFactory>();
        }

        public async Task<Post?> GetPostByIdAsync(
            PostId id,
            CancellationToken cancellationToken)
        {
            var include = serviceScope.GetPostIncludeBuilderFactory().Create().WithUser().Build();
            var postRepository = serviceScope.GetPostCommandRepository();

            return await postRepository.GetByIdAsync(id, include, cancellationToken);
        }

        public async Task AddPostAsync(
            Post post,
            CancellationToken cancellationToken)
        {
            var postRepository = serviceScope.GetPostCommandRepository();

            await postRepository.AddAsync(post, cancellationToken);
        }

        public async Task AddPostRangeAsync(
            IEnumerable<Post> posts,
            CancellationToken cancellationToken)
        {
            var postRepository = serviceScope.GetPostCommandRepository();

            await postRepository.AddRangeAsync(posts, cancellationToken);
        }

        public async Task DeletePostAsync(
            Post post,
            CancellationToken cancellationToken)
        {
            var postRepository = serviceScope.GetPostCommandRepository();

            await postRepository.DeleteAsync(post, cancellationToken);
        }

        public async Task ResetPostDatabase(
            CancellationToken cancellationToken)
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<IPostsContext>();

            await context.PostLikes.ResetAsync(cancellationToken);
            await context.Posts.ResetAsync(cancellationToken);
            await context.Users.ResetAsync(cancellationToken);
        }
    }
}
