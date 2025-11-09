namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

public record GetAllPostLikesQueryResponse(
    ICollection<PostLikeQueryResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
