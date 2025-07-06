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

    public GetAllQuerySpecification CreateGetAll(GetAllPostsRequest queryParameters)
    {
        var sortOrder = _sortOrderFactory.Create(queryParameters.Sorting.Order);
        var sortProperty = _postSortPropertyFactory.Create(queryParameters.Sorting.Property);
        var offset = _paginator.GetOffset(queryParameters.Pagination.Page, queryParameters.Pagination.PageSize);
        var parameters = new GetAllQueryParameters(
            queryParameters.Filter.UserId,
            queryParameters.Filter.UserName,
            queryParameters.Filter.Title,
            sortOrder.Order,
            sortProperty.Property,
            offset,
            queryParameters.Pagination.PageSize);

        var specification = new GetAllQuerySpecification(
            PostQuerySql.GetAll,
            parameters);

        return specification;
    }

    public GetAllTotalCountQuerySpecification CreateGetAllTotalCount(PostFilterRequest filter)
    {
        var parameters = new GetAllTotalCountQueryParameters(
            filter.UserId,
            filter.UserName,
            filter.Title);

        var specification = new GetAllTotalCountQuerySpecification(
            PostQuerySql.GetAllTotalCount,
            parameters);

        return specification;
    }

    public GetPostByIdSpecification CreateGetById(string id)
    {
        var parameters = new GetPostByIdParameters(id);

        var result = new GetPostByIdSpecification(
            PostQuerySql.GetAll,
            parameters);

        return result;
    }
}
