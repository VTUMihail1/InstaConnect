using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;

public record GetPostCommentLikeByIdQuery(
    string Id,
    string CommentId,
    string UserId)
{
    public PostCommentLikeIncludeQuery? Include { get; private set; }

    public GetPostCommentLikeByIdQuery AddInclude(PostCommentLikeIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
