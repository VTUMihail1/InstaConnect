namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetAllUsersApiRequest(
    [FromQuery] UserFilterApiRequest Filter,
    [FromQuery] UserSortingApiRequest Sorting,
    [FromQuery] UserPaginationApiRequest Pagination);
