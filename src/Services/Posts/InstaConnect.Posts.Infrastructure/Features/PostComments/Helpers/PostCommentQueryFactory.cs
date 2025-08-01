using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Models;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Helpers;

public class PostCommentQueryFactory : IPostCommentQueryFactory
{
    private readonly IPaginator _paginator;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IPostCommentSortPropertyFactory _postCommentSortPropertyFactory;

    public PostCommentQueryFactory(
        IPaginator paginator,
        ISortOrderFactory sortOrderFactory,
        IPostCommentSortPropertyFactory postCommentSortPropertyFactory)
    {
        _paginator = paginator;
        _sortOrderFactory = sortOrderFactory;
        _postCommentSortPropertyFactory = postCommentSortPropertyFactory;
    }

    public GetAllPostCommentsQuerySpecification CreateGetAll(GetAllPostCommentsQuery query)
    {
        var sortOrder = _sortOrderFactory.Create(query.Sorting.Order);
        var sortProperty = _postCommentSortPropertyFactory.Create(query.Sorting.Property);
        var offset = _paginator.GetOffset(query.Pagination.Page, query.Pagination.PageSize);
        var parameters = new GetAllPostCommentsQueryParameters(
            query.Filter.Id,
            query.Filter.UserId,
            query.Filter.UserName,
            sortOrder.Order,
            sortProperty.Property,
            offset,
            query.Pagination.PageSize);

        var specification = new GetAllPostCommentsQuerySpecification(
            PostCommentQuerySql.GetAll,
            parameters);

        return specification;
    }

    public GetAllPostCommentsTotalCountQuerySpecification CreateGetAllTotalCount(PostCommentFilterQuery query)
    {
        var parameters = new GetAllPostCommentsTotalCountQueryParameters(
            query.Id,
            query.UserId,
            query.UserName);

        var specification = new GetAllPostCommentsTotalCountQuerySpecification(
            PostCommentQuerySql.GetAllTotalCount,
            parameters);

        return specification;
    }

    public GetPostCommentByIdQuerySpecification CreateGetById(string id, string commentId)
    {
        var parameters = new GetPostCommentByIdQueryParameters(id, commentId);

        var result = new GetPostCommentByIdQuerySpecification(
            PostCommentQuerySql.GetById,
            parameters);

        return result;
    }
}
