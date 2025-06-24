namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record GetAllPostsApiRequest(
    [FromQuery] PostFilterApiRequest Filter,
    [FromQuery] PostSortingApiRequest Sorting,
    [FromQuery] PostPaginationApiRequest Pagination);
