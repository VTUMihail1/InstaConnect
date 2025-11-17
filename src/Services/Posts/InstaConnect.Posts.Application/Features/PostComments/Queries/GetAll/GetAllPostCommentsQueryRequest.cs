namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

public record GetAllPostCommentsQueryRequest(
    PostCommentFilterQueryRequest Filter,
    PostCommentSortingQueryRequest Sorting,
    PostCommentPaginationQueryRequest Pagination)
    : IQueryRequest<GetAllPostCommentsQueryResponse>;
