using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Models;
using InstaConnect.Follows.Infrastructure.Features.Follows.Utilities;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers;

public class FollowQueryFactory : IFollowQueryFactory
{
    private readonly IPaginator _paginator;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IFollowByFollowerSortPropertyFactory _followByFollowerSortPropertyFactory;
    private readonly IFollowByFollowingSortPropertyFactory _followByFollowingSortPropertyFactory;

    public FollowQueryFactory(
        IPaginator paginator,
        ISortOrderFactory sortOrderFactory,
        IFollowByFollowerSortPropertyFactory followByFollowerSortPropertyFactory,
        IFollowByFollowingSortPropertyFactory followByFollowingSortPropertyFactory)
    {
        _paginator = paginator;
        _sortOrderFactory = sortOrderFactory;
        _followByFollowerSortPropertyFactory = followByFollowerSortPropertyFactory;
        _followByFollowingSortPropertyFactory = followByFollowingSortPropertyFactory;
    }

    public GetAllFollowsByFollowerQuerySpecification CreateGetAllByFollower(GetAllFollowsByFollowerQuery query)
    {
        var sortOrder = _sortOrderFactory.Create(query.Sorting.Order);
        var sortProperty = _followByFollowerSortPropertyFactory.Create(query.Sorting.Property);
        var offset = _paginator.GetOffset(query.Pagination.Page, query.Pagination.PageSize);
        var parameters = new GetAllFollowsByFollowerQueryParameters(
            query.Filter.FollowerId,
            query.Filter.FollowingName,
            sortOrder.Order,
            sortProperty.Property,
            offset,
            query.Pagination.PageSize);

        var specification = new GetAllFollowsByFollowerQuerySpecification(
            FollowQuerySql.GetAllByFollower,
            parameters);

        return specification;
    }

    public GetAllFollowsByFollowerTotalCountQuerySpecification CreateGetAllByFollowerTotalCount(FollowByFollowerFilterQuery query)
    {
        var parameters = new GetAllFollowsByFollowerTotalCountQueryParameters(
            query.FollowerId,
            query.FollowingName);

        var specification = new GetAllFollowsByFollowerTotalCountQuerySpecification(
            FollowQuerySql.GetAllByFollowerTotalCount,
            parameters);

        return specification;
    }

    public GetAllFollowsByFollowingQuerySpecification CreateGetAllByFollowing(GetAllFollowsByFollowingQuery query)
    {
        var sortOrder = _sortOrderFactory.Create(query.Sorting.Order);
        var sortProperty = _followByFollowingSortPropertyFactory.Create(query.Sorting.Property);
        var offset = _paginator.GetOffset(query.Pagination.Page, query.Pagination.PageSize);
        var parameters = new GetAllFollowsByFollowingQueryParameters(
            query.Filter.FollowingId,
            query.Filter.FollowerName,
            sortOrder.Order,
            sortProperty.Property,
            offset,
            query.Pagination.PageSize);

        var specification = new GetAllFollowsByFollowingQuerySpecification(
            FollowQuerySql.GetAllByFollowing,
            parameters);

        return specification;
    }

    public GetAllFollowsByFollowingTotalCountQuerySpecification CreateGetAllByFollowingTotalCount(FollowByFollowingFilterQuery query)
    {
        var parameters = new GetAllFollowsByFollowingTotalCountQueryParameters(
            query.FollowingId,
            query.FollowerName);

        var specification = new GetAllFollowsByFollowingTotalCountQuerySpecification(
            FollowQuerySql.GetAllByFollowingTotalCount,
            parameters);

        return specification;
    }

    public GetFollowByIdQuerySpecification CreateGetById(string followerId, string followingId)
    {
        var parameters = new GetFollowByIdQueryParameters(followerId, followingId);

        var result = new GetFollowByIdQuerySpecification(
            FollowQuerySql.GetById,
            parameters);

        return result;
    }
}
