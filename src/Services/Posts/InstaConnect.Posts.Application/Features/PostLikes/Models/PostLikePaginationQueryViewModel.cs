namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikePaginationQueryViewModel(
    ICollection<PostLikeQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
