using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Helpers;

public class PostQueryFactory : IPostQueryFactory
{
    private readonly IPaginator _paginator;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IPostSortPropertyFactory _postSortPropertyFactory;

    public PostQueryFactory(
        IPaginator paginator,
        ISortOrderFactory sortOrderFactory,
        IPostSortPropertyFactory postSortPropertyFactory)
    {
        _paginator = paginator;
        _sortOrderFactory = sortOrderFactory;
        _postSortPropertyFactory = postSortPropertyFactory;
    }

    public GetAllPostsQuerySpecification CreateGetAll(GetAllPostsQuery query)
    {
        var sortOrder = _sortOrderFactory.Create(query.Sorting.Order);
        var sortProperty = _postSortPropertyFactory.Create(query.Sorting.Property);
        var offset = _paginator.GetOffset(query.Pagination.Page, query.Pagination.PageSize);
        var parameters = new GetAllPostsQueryParameters(
            query.Filter.UserId,
            query.Filter.UserName,
            query.Filter.Title,
            sortOrder.Order,
            sortProperty.Property,
            offset,
            query.Pagination.PageSize);

        var specification = new GetAllPostsQuerySpecification(
            PostQuerySql.GetAll,
            parameters);

        return specification;
    }

    public GetAllPostsTotalCountQuerySpecification CreateGetAllTotalCount(PostFilterQuery query)
    {
        var parameters = new GetAllPostsTotalCountQueryParameters(
            query.UserId,
            query.UserName,
            query.Title);

        var specification = new GetAllPostsTotalCountQuerySpecification(
            PostQuerySql.GetAllTotalCount,
            parameters);

        return specification;
    }

    public GetPostByIdQuerySpecification CreateGetById(string id)
    {
        var parameters = new GetPostByIdQueryParameters(id);

        var result = new GetPostByIdQuerySpecification(
            PostQuerySql.GetById,
            parameters);

        return result;
    }
}
