using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record GetPostCommentByIdQuery(PostCommentId Id)
    : IIncludableQuery<PostCommentIncludeProperty>
{
    public CommonIncludeQuery<PostCommentIncludeProperty>? Include { get; private set; }

    public GetPostCommentByIdQuery AddInclude(CommonIncludeQuery<PostCommentIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
