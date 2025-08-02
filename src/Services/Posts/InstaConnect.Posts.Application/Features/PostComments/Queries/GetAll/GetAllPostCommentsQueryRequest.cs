using InstaConnect.PostComments.Domain.Features.PostComments.Models;

namespace InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;

public record GetAllPostCommentsQueryRequest(
    PostCommentQueryFilter Filter,
    PostCommentQuerySorting Sorting,
    PostCommentQueryPagination Pagination)
    : IQueryRequest<GetAllPostCommentsQueryResponse>;
