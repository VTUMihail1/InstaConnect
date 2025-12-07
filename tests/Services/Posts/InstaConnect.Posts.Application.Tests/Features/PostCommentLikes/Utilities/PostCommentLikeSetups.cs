using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.Tests.Features.PostCommentLikes.Utilities;
public static class PostCommentLikeSetups
{
    public static async Task<PostCommentLike?> GetPostCommentLikeByIdAsync(
        this IServiceScope serviceScope,
        PostCommentLikeIdCommandResponse id,
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
