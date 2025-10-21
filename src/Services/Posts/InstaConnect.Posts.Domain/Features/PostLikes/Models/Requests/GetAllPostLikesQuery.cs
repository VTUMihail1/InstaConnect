using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record GetAllPostLikesQuery(
    PostLikeFilterQuery Filter,
    PostLikeSortingQuery Sorting,
    PostLikePaginationQuery Pagination)
{
    public PostLikeIncludeQuery? Include { get; private set; }

    public GetAllPostLikesQuery AddInclude(PostLikeIncludeQuery include)
    {
        Include = include;

        return this;
    }
}
