namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record GetPostCommentByIdQuery(
    string Id,
    string CommentId)
{
    public PostCommentIncludeQuery? Include { get; private set; }

    public GetPostCommentByIdQuery AddInclude(PostCommentIncludeQuery include)
    {
        Include = include;

        return this;
    }
}
