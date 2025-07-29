using Dapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;

internal class PostRepository : IPostRepository
{
    private readonly PostsContext _postsContext;
    private readonly IPostQueryFactory _postQueryFactory;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IPostCollectionFactory _postCollectionFactory;

    public PostRepository(
        PostsContext postsContext,
        IPostQueryFactory postQueryFactory,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory,
        IPostCollectionFactory postCollectionFactory)
    {
        _postsContext = postsContext;
        _postQueryFactory = postQueryFactory;
        _applicationMapper = applicationMapper;
        _sqlConnectionFactory = sqlConnectionFactory;
        _postCollectionFactory = postCollectionFactory;
    }

    public async Task<PostCollection> GetAllAsync(GetAllPostsQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllQuery = _postQueryFactory.CreateGetAll(query);
        var queryEntity = await connection.ExecuteQueryAsync<PostQueryEntity>(
            getAllQuery.Sql,
            getAllQuery.Parameters,
            cancellationToken);
        var posts = _applicationMapper.Map<ICollection<Post>>(queryEntity.ToList());

        var getAllTotalCountQuery = _postQueryFactory.CreateGetAllTotalCount(query.Filter);
        var postsTotalCount = await connection.ExecuteFunctionAsync<int>(getAllTotalCountQuery.Sql, getAllTotalCountQuery.Parameters, cancellationToken);

        var response = _postCollectionFactory.Create(posts, postsTotalCount, query.Pagination);

        return response;
    }

    public async Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdQuery = _postQueryFactory.CreateGetById(id);
        var queryResponse = await connection.ExecuteQueryFirstAsync<PostQueryEntity>(
            getByIdQuery.Sql,
            getByIdQuery.Parameters,
            cancellationToken);
        var post = _applicationMapper.Map<Post>(queryResponse!);

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
