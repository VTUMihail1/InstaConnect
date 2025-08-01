using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;
using InstaConnect.Posts.Infrastructure;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Repositories;

internal class PostLikeRepository : IPostLikeRepository
{
    private readonly PostsContext _postsContext;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IPostLikeQueryFactory _postLikeQueryFactory;
    private readonly IPostLikeCollectionFactory _postLikeCollectionFactory;

    public PostLikeRepository(
        PostsContext postsContext,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory,
        IPostLikeQueryFactory postLikeQueryFactory,
        IPostLikeCollectionFactory postLikeCollectionFactory)
    {
        _postsContext = postsContext;
        _applicationMapper = applicationMapper;
        _sqlConnectionFactory = sqlConnectionFactory;
        _postLikeQueryFactory = postLikeQueryFactory;
        _postLikeCollectionFactory = postLikeCollectionFactory;
    }

    public async Task<PostLikeCollection> GetAllAsync(GetAllPostLikesQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllQuery = _postLikeQueryFactory.CreateGetAll(query);
        var queryEntity = await connection.ExecuteQueryAsync<PostLikeQueryEntity>(
            getAllQuery.Sql,
            getAllQuery.Parameters,
            cancellationToken);
        var postLikes = _applicationMapper.Map<ICollection<PostLike>>(queryEntity.ToList());

        var getAllTotalCountQuery = _postLikeQueryFactory.CreateGetAllTotalCount(query.Filter);
        var postLikesTotalCount = await connection.ExecuteFunctionAsync<int>(getAllTotalCountQuery.Sql, getAllTotalCountQuery.Parameters, cancellationToken);

        var response = _postLikeCollectionFactory.Create(postLikes, postLikesTotalCount, query.Pagination);

        return response;
    }

    public async Task<PostLike?> GetByIdAsync(string id, string likeId, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdQuery = _postLikeQueryFactory.CreateGetById(id, likeId);
        var queryResponse = await connection.ExecuteQueryFirstAsync<PostLikeQueryEntity>(
            getByIdQuery.Sql,
            getByIdQuery.Parameters,
            cancellationToken);
        var postLike = _applicationMapper.Map<PostLike>(queryResponse!);

        return postLike;
    }



    public async Task<PostLike?> GetByIdAndUserIdAsync(string id, string userId, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdAndUserIdQuery = _postLikeQueryFactory.CreateGetByIdAndUserId(id, userId);
        var queryResponse = await connection.ExecuteQueryFirstAsync<PostLikeQueryEntity>(
            getByIdAndUserIdQuery.Sql,
            getByIdAndUserIdQuery.Parameters,
            cancellationToken);
        var postLike = _applicationMapper.Map<PostLike>(queryResponse!);

        return postLike;
    }

    public void Add(PostLike postLike)
    {
        _postsContext
            .PostLikes
            .Add(postLike);
    }

    public void Update(PostLike postLike)
    {
        _postsContext
            .PostLikes
            .Update(postLike);
    }

    public void Delete(PostLike postLike)
    {
        _postsContext
            .PostLikes
            .Remove(postLike);
    }
}
