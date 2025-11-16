namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record GetPostCommentLikeByIdQuery(PostCommentLikeId Id)
{
    public PostCommentLikeIncludeQuery? Include { get; private set; }

    public GetPostCommentLikeByIdQuery AddInclude(PostCommentLikeIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
