using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeSetups
{
    public static async Task<PostCommentLike?> GetPostCommentLikeByIdAsync(
        this IServiceScope serviceScope,
        PostCommentLikeIdApiResponse id,
        CancellationToken cancellationToken)
    {
        return await serviceScope.GetPostCommentLikeByIdAsync(
            new PostCommentLikeId(
                                  new(
                                      new(id.Id),
                                      id.CommentId),
                                  new(id.UserId)),
            cancellationToken);
    }
}
