namespace InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

public record GetAllPostCommentsQuery(
    PostCommentFilterQuery Filter,
    PostCommentSortingQuery Sorting,
    PostCommentPaginationQuery Pagination);
