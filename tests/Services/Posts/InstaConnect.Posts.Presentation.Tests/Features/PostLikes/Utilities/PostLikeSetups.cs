using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostLikes.Utilities;
public static class PostLikeSetups
{
    public static async Task<PostLike?> GetPostLikeByIdAsync(
        this IServiceScope serviceScope,
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
