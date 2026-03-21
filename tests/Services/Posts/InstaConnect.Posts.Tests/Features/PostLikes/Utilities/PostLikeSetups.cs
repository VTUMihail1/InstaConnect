using InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
    extension(IServiceProvider serviceProvider)
    {
        public IPostLikeCommandRepository GetPostLikeCommandRepository()
        {
            return serviceProvider.GetRequiredService<IPostLikeCommandRepository>();
        }

        public IPostLikeIncludeBuilderFactory GetPostLikeIncludeBuilderFactory()
        {
            return serviceProvider.GetRequiredService<IPostLikeIncludeBuilderFactory>();
        }
    }

    extension(IServiceScope serviceScope)
    {
        public IPostLikeCommandRepository GetPostLikeCommandRepository()
        {
            return serviceScope.ServiceProvider.GetPostLikeCommandRepository();
        }

        public IPostLikeIncludeBuilderFactory GetPostLikeIncludeBuilderFactory()
        {
            return serviceScope.ServiceProvider.GetPostLikeIncludeBuilderFactory();
        }

        public async Task<PostLike?> GetPostLikeByIdAsync(
            PostLikeId id,
            CancellationToken cancellationToken)
        {
            return await serviceScope.GetPostLikeCommandRepository().GetByIdAsync(id, cancellationToken);
        }

        public async Task AddPostLikeAsync(
            PostLike postLike,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetPostLikeCommandRepository().AddAsync(postLike, cancellationToken);
        }

        public async Task AddPostLikeRangeAsync(
            IEnumerable<PostLike> postLikes,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetPostLikeCommandRepository().AddRangeAsync(postLikes, cancellationToken);
        }

        public async Task DeletePostLikeAsync(
            PostLike postLike,
            CancellationToken cancellationToken)
        {
            await serviceScope.GetPostLikeCommandRepository().DeleteAsync(postLike, cancellationToken);
        }
    }
}
