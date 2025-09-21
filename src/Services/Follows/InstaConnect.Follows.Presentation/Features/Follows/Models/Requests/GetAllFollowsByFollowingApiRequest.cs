namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record GetAllFollowsByFollowingApiRequest(
    [FromQuery] FollowByFollowingFilterApiRequest Filter,
    [FromQuery] FollowByFollowingSortingApiRequest Sorting,
    [FromQuery] FollowPaginationApiRequest Pagination);
