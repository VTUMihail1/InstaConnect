using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
    extension(IServiceScope serviceScope)
    {
        public async Task<PostComment?> GetPostCommentByIdAsync(
        PostCommentIdApiResponse id,
        CancellationToken cancellationToken)
        {
            return await serviceScope.GetPostCommentByIdAsync(
                new PostCommentId(
                               new(id.Id),
                               id.CommentId),
                cancellationToken);
        }
    }
}
