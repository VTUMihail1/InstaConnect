using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;

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
