using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.Tests.Features.PostComments.Utilities;

public static class PostCommentSetups
{
    extension(IServiceScope serviceScope)
    {
        public async Task<PostComment?> GetPostCommentByIdAsync(
        PostCommentIdCommandResponse id,
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
