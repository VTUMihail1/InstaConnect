using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record GetPostCommentLikeByIdQuery(PostCommentLikeId Id)
    : IIncludableQuery<PostCommentLikeIncludeProperty>
{
    public CommonIncludeQuery<PostCommentLikeIncludeProperty>? Include { get; private set; }

    public GetPostCommentLikeByIdQuery AddInclude(CommonIncludeQuery<PostCommentLikeIncludeProperty> include)
    {
        Include = include;

        return this;
    }
};
