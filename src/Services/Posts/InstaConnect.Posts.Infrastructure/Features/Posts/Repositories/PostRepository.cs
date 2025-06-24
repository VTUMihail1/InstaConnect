using Dapper;

using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Shared.Infrastructure.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;

internal class PostRepository : IPostRepository
{
    private readonly PostsContext _postsContext;
    private readonly IPostQueryFactory _postQueryFactory;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IPostCollectionFactory _postCollectionFactory;

    public PostRepository(
        PostsContext postsContext,
        IPostQueryFactory postQueryFactory,
        ISqlConnectionFactory sqlConnectionFactory,
        IPostCollectionFactory postCollectionFactory)
    {
        _postsContext = postsContext;
        _postQueryFactory = postQueryFactory;
        _sqlConnectionFactory = sqlConnectionFactory;
        _postCollectionFactory = postCollectionFactory;
    }

    public async Task<PostCollection> GetAllAsync(GetAllPostsRequest request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllQuery = _postQueryFactory.CreateGetAll(request);
        var posts = await connection.ExecuteQueryAsync(
            getAllQuery.Sql,
            getAllQuery.Map,
            getAllQuery.Parameters,
            getAllQuery.SplitOn,
            cancellationToken);

        var getAllTotalCountQuery = _postQueryFactory.CreateGetAllTotalCount(request.Filter);
        var postsTotalCount = await connection.ExecuteFunctionAsync<int>(getAllTotalCountQuery.Sql, getAllTotalCountQuery.Parameters, cancellationToken);

        var response = _postCollectionFactory.Create(posts, postsTotalCount, request.Pagination);

        return response;
    }

    public async Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdQuery = _postQueryFactory.CreateGetById(id);
        var post = await connection.ExecuteQueryFirstAsync(
            getByIdQuery.Sql,
            getByIdQuery.Map,
            getByIdQuery.Parameters,
            getByIdQuery.SplitOn,
            cancellationToken);

        return post;
    }

    public void Add(Post post)
    {
        _postsContext
            .Posts
            .Add(post);
    }

    public void Update(Post post)
    {
        _postsContext
            .Posts
            .Update(post);
    }

    public void Delete(Post post)
    {
        _postsContext
            .Posts
            .Remove(post);
    }
}
