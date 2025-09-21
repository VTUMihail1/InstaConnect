namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowerApiRequest(
    [FromQuery] FollowByFollowerFilterApiRequest Filter,
    [FromQuery] FollowByFollowerSortingApiRequest Sorting,
    [FromQuery] FollowPaginationApiRequest Pagination);
