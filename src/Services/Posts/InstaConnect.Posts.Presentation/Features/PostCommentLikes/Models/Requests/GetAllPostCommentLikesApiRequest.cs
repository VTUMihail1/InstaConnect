namespace InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;

public record GetAllPostCommentLikesApiRequest(
    [FromQuery] PostCommentLikeFilterApiRequest Filter,
    [FromQuery] PostCommentLikeSortingApiRequest Sorting,
    [FromQuery] PostCommentLikePaginationApiRequest Pagination);
