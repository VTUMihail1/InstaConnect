namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;

public record GetPostCommentByIdQuery(PostCommentId Id)
{
    public PostCommentIncludeQuery? Include { get; private set; }

    public GetPostCommentByIdQuery AddInclude(PostCommentIncludeQuery include)
    {
        Include = include;

        return this;
    }
}
