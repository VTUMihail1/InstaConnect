namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

public record GetAllPostLikesQuery(
    PostLikeFilterQuery Filter,
    PostLikeSortingQuery Sorting,
    PostLikePaginationQuery Pagination);
