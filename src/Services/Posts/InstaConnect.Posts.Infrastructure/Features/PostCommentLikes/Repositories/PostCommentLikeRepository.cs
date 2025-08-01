using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Responses;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Abstractions;
using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Infrastructure;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Repositories;

internal class PostCommentLikeRepository : IPostCommentLikeRepository
{
    private readonly PostsContext _postsContext;
    private readonly IApplicationMapper _appclicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IPostCommentLikeQueryFactory _postCommentLikeQueryFactory;
    private readonly IPostCommentLikeCollectionFactory _postCommentLikeCollectionFactory;

    public PostCommentLikeRepository(
        PostsContext postsContext,
        IApplicationMapper appclicationMapper,
        ISqlConnectionFactory sqlConnectionFactory,
        IPostCommentLikeQueryFactory postCommentLikeQueryFactory,
        IPostCommentLikeCollectionFactory postCommentLikeCollectionFactory)
    {
        _postsContext = postsContext;
        _appclicationMapper = appclicationMapper;
        _sqlConnectionFactory = sqlConnectionFactory;
        _postCommentLikeQueryFactory = postCommentLikeQueryFactory;
        _postCommentLikeCollectionFactory = postCommentLikeCollectionFactory;
    }

    public async Task<PostCommentLikeCollection> GetAllAsync(GetAllPostCommentLikesQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllQuery = _postCommentLikeQueryFactory.CreateGetAll(query);
        var queryEntity = await connection.ExecuteQueryAsync<PostCommentLikeQueryEntity>(
            getAllQuery.Sql,
            getAllQuery.Parameters,
            cancellationToken);
        var postCommentLikes = _appclicationMapper.Map<ICollection<PostCommentLike>>(queryEntity.ToList());

        var getAllTotalCountQuery = _postCommentLikeQueryFactory.CreateGetAllTotalCount(query.Filter);
        var postCommentLikesTotalCount = await connection.ExecuteFunctionAsync<int>(getAllTotalCountQuery.Sql, getAllTotalCountQuery.Parameters, cancellationToken);

        var response = _postCommentLikeCollectionFactory.Create(postCommentLikes, postCommentLikesTotalCount, query.Pagination);

        return response;
    }

    public async Task<PostCommentLike?> GetByIdAsync(string id, string commentId, string commentLikeId, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdQuery = _postCommentLikeQueryFactory.CreateGetById(id, commentId, commentLikeId);
        var queryResponse = await connection.ExecuteQueryFirstAsync<PostCommentLikeQueryEntity>(
            getByIdQuery.Sql,
            getByIdQuery.Parameters,
            cancellationToken);
        var postCommentLike = _appclicationMapper.Map<PostCommentLike>(queryResponse!);

        return postCommentLike;
    }



    public async Task<PostCommentLike?> GetByIdAndUserIdAsync(string id, string commentId, string userId, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdAndUserIdQuery = _postCommentLikeQueryFactory.CreateGetByIdAndUserId(id, commentId, userId);
        var queryResponse = await connection.ExecuteQueryFirstAsync<PostCommentLikeQueryEntity>(
            getByIdAndUserIdQuery.Sql,
            getByIdAndUserIdQuery.Parameters,
            cancellationToken);
        var postCommentLike = _appclicationMapper.Map<PostCommentLike>(queryResponse!);

        return postCommentLike;
    }

    public void Add(PostCommentLike postCommentLike)
    {
        _postsContext
            .PostCommentLikes
            .Add(postCommentLike);
    }

    public void Update(PostCommentLike postCommentLike)
    {
        _postsContext
            .PostCommentLikes
            .Update(postCommentLike);
    }

    public void Delete(PostCommentLike postCommentLike)
    {
        _postsContext
            .PostCommentLikes
            .Remove(postCommentLike);
    }
}
