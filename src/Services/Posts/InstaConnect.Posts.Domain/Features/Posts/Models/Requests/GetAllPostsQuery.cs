namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record GetAllPostsQuery(
    PostFilterQuery Filter,
    PostSortingQuery Sorting,
    PostPaginationQuery Pagination);
