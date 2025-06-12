namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record GetAllPostsRequest(
    [FromQuery] PostRequestFilter Filter,
    [FromQuery] PostRequestSorting Sorting,
    [FromQuery] PostRequestPagination Pagination);
