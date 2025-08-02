namespace InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

public record GetAllPostCommentsApiRequest(
    [FromQuery] PostCommentFilterApiRequest Filter,
    [FromQuery] PostCommentSortingApiRequest Sorting,
    [FromQuery] PostCommentPaginationApiRequest Pagination);
