namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;

public record GetAllPostCommentLikesQuery(
    PostCommentLikeFilterQuery Filter,
    PostCommentLikeSortingQuery Sorting,
    PostCommentLikePaginationQuery Pagination)
{
    public PostCommentLikeIncludeQuery? Include { get; private set; }

    public GetAllPostCommentLikesQuery AddInclude(PostCommentLikeIncludeQuery include)
    {
        Include = include;

        return this;
    }
};
