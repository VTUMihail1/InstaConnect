using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

public static class PostLikeSetups
{
    extension(IServiceScope serviceScope)
    {
        public async Task<PostLike?> GetPostLikeByIdAsync(
        PostLikeIdApiResponse id,
        CancellationToken cancellationToken)
        {
            return await serviceScope.GetPostLikeByIdAsync(
                new PostLikeId(
                               new(id.Id),
                               new(id.UserId)),
                cancellationToken);
        }
    }
}
