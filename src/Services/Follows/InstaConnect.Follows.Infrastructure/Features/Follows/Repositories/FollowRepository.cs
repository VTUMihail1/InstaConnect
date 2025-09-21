using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Follows.Domain.Features.Follows.Abstractions;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
using InstaConnect.Follows.Infrastructure.Features.Follows.Models;
using InstaConnect.Posts.Infrastructure;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Repositories;

internal class FollowRepository : IFollowRepository
{
    private readonly FollowsContext _followsContext;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IFollowQueryFactory _followQueryFactory;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IFollowCollectionFactory _followCollectionFactory;

    public FollowRepository(
        FollowsContext followsContext,
        IApplicationMapper applicationMapper,
        IFollowQueryFactory followQueryFactory,
        ISqlConnectionFactory sqlConnectionFactory,
        IFollowCollectionFactory followCollectionFactory)
    {
        _followsContext = followsContext;
        _applicationMapper = applicationMapper;
        _followQueryFactory = followQueryFactory;
        _sqlConnectionFactory = sqlConnectionFactory;
        _followCollectionFactory = followCollectionFactory;
    }

    public async Task<FollowCollection> GetAllByFollowerAsync(GetAllFollowsByFollowerQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllByFollowerQuery = _followQueryFactory.CreateGetAllByFollower(query);
        var queryEntity = await connection.ExecuteQueryAsync<FollowQueryEntity>(
            getAllByFollowerQuery.Sql,
            getAllByFollowerQuery.Parameters,
            cancellationToken);
        var follows = _applicationMapper.Map<ICollection<Follow>>(queryEntity.ToList());

        var getAllByFollowerTotalCountQuery = _followQueryFactory.CreateGetAllByFollowerTotalCount(query.Filter);
        var followsTotalCount = await connection.ExecuteFunctionAsync<int>(getAllByFollowerTotalCountQuery.Sql, getAllByFollowerTotalCountQuery.Parameters, cancellationToken);

        var response = _followCollectionFactory.Create(follows, followsTotalCount, query.Pagination);

        return response;
    }

    public async Task<FollowCollection> GetAllByFollowingAsync(GetAllFollowsByFollowingQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllByFollowingQuery = _followQueryFactory.CreateGetAllByFollowing(query);
        var queryEntity = await connection.ExecuteQueryAsync<FollowQueryEntity>(
            getAllByFollowingQuery.Sql,
            getAllByFollowingQuery.Parameters,
            cancellationToken);
        var follows = _applicationMapper.Map<ICollection<Follow>>(queryEntity.ToList());

        var getAllByFollowingTotalCountQuery = _followQueryFactory.CreateGetAllByFollowingTotalCount(query.Filter);
        var followsTotalCount = await connection.ExecuteFunctionAsync<int>(getAllByFollowingTotalCountQuery.Sql, getAllByFollowingTotalCountQuery.Parameters, cancellationToken);

        var response = _followCollectionFactory.Create(follows, followsTotalCount, query.Pagination);

        return response;
    }

    public async Task<Follow?> GetByIdAsync(string followerId, string followingId, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdAndUserIdQuery = _followQueryFactory.CreateGetById(followerId, followingId);
        var queryResponse = await connection.ExecuteQueryFirstAsync<FollowQueryEntity>(
            getByIdAndUserIdQuery.Sql,
            getByIdAndUserIdQuery.Parameters,
            cancellationToken);
        var follow = _applicationMapper.Map<Follow>(queryResponse!);

        return follow;
    }

    public void Add(Follow follow)
    {
        _followsContext
            .Follows
            .Add(follow);
    }

    public void Update(Follow follow)
    {
        _followsContext
            .Follows
            .Update(follow);
    }

    public void Delete(Follow follow)
    {
        _followsContext
            .Follows
            .Remove(follow);
    }
}
