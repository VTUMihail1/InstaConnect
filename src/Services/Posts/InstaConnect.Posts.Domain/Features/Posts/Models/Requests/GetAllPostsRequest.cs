namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetAllPostsRequest(
    PostFilterRequest Filter,
    PostSortingRequest Sorting,
    PostPaginationRequest Pagination);
