namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetAllPostsQuery(
    PostFilterRequest Filter,
    PostSortingRequest Sorting,
    PostPaginationRequest Pagination);
