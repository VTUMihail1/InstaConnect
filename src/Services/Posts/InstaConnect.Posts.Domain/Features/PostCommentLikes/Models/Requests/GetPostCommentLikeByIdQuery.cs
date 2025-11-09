namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

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
