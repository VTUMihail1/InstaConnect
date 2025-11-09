namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

public record GetAllPostCommentsQueryRequest(
    PostCommentQueryFilter Filter,
    PostCommentQuerySorting Sorting,
    PostCommentQueryPagination Pagination)
    : IQueryRequest<GetAllPostCommentsQueryResponse>;
