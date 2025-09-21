using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Utilities;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Helpers;

public class PostLikeQueryFactory : IPostLikeQueryFactory
{
    private readonly IPaginator _paginator;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IPostLikeSortPropertyFactory _postLikeSortPropertyFactory;

    public PostLikeQueryFactory(
        IPaginator paginator,
        ISortOrderFactory sortOrderFactory,
        IPostLikeSortPropertyFactory postLikeSortPropertyFactory)
    {
        _paginator = paginator;
        _sortOrderFactory = sortOrderFactory;
        _postLikeSortPropertyFactory = postLikeSortPropertyFactory;
    }

    public GetAllPostLikesQuerySpecification CreateGetAll(GetAllPostLikesQuery query)
    {
        var sortOrder = _sortOrderFactory.Create(query.Sorting.Order);
        var sortProperty = _postLikeSortPropertyFactory.Create(query.Sorting.Property);
        var offset = _paginator.GetOffset(query.Pagination.Page, query.Pagination.PageSize);
        var parameters = new GetAllPostLikesQueryParameters(
            query.Filter.Id,
            query.Filter.UserName,
            sortOrder.Order,
            sortProperty.Property,
            offset,
            query.Pagination.PageSize);

        var specification = new GetAllPostLikesQuerySpecification(
            PostLikeQuerySql.GetAll,
            parameters);

        return specification;
    }

    public GetAllPostLikesTotalCountQuerySpecification CreateGetAllTotalCount(PostLikeFilterQuery query)
    {
        var parameters = new GetAllPostLikesTotalCountQueryParameters(
            query.Id,
            query.UserName);

        var specification = new GetAllPostLikesTotalCountQuerySpecification(
            PostLikeQuerySql.GetAllTotalCount,
            parameters);

        return specification;
    }

    public GetPostLikeByIdQuerySpecification CreateGetById(string id, string userId)
    {
        var parameters = new GetPostLikeByIdQueryParameters(id, userId);

        var result = new GetPostLikeByIdQuerySpecification(
            PostLikeQuerySql.GetById,
            parameters);

        return result;
    }
}
