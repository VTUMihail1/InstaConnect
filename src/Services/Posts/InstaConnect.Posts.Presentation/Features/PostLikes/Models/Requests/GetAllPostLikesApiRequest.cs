namespace InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

public record GetAllPostLikesApiRequest(
    [FromQuery] PostLikeFilterApiRequest Filter,
    [FromQuery] PostLikeSortingApiRequest Sorting,
    [FromQuery] PostLikePaginationApiRequest Pagination);
