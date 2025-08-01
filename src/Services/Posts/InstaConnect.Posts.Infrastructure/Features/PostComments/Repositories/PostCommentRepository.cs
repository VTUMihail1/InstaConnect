using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Responses;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Infrastructure.Features.PostComments.Models;
using InstaConnect.Posts.Infrastructure;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Repositories;

internal class PostCommentRepository : IPostCommentRepository
{
    private readonly PostsContext _postsContext;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IPostCommentQueryFactory _postCommentQueryFactory;
    private readonly IPostCommentCollectionFactory _postCommentCollectionFactory;

    public PostCommentRepository(
        PostsContext postsContext,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory,
        IPostCommentQueryFactory postCommentQueryFactory,
        IPostCommentCollectionFactory postCommentCollectionFactory)
    {
        _postsContext = postsContext;
        _applicationMapper = applicationMapper;
        _sqlConnectionFactory = sqlConnectionFactory;
        _postCommentQueryFactory = postCommentQueryFactory;
        _postCommentCollectionFactory = postCommentCollectionFactory;
    }

    public async Task<PostCommentCollection> GetAllAsync(GetAllPostCommentsQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllQuery = _postCommentQueryFactory.CreateGetAll(query);
        var queryEntity = await connection.ExecuteQueryAsync<PostCommentQueryEntity>(
            getAllQuery.Sql,
            getAllQuery.Parameters,
            cancellationToken);
        var postComments = _applicationMapper.Map<ICollection<PostComment>>(queryEntity.ToList());

        var getAllTotalCountQuery = _postCommentQueryFactory.CreateGetAllTotalCount(query.Filter);
        var postCommentsTotalCount = await connection.ExecuteFunctionAsync<int>(getAllTotalCountQuery.Sql, getAllTotalCountQuery.Parameters, cancellationToken);

        var response = _postCommentCollectionFactory.Create(postComments, postCommentsTotalCount, query.Pagination);

        return response;
    }

    public async Task<PostComment?> GetByIdAsync(string id, string commentId, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdQuery = _postCommentQueryFactory.CreateGetById(id, commentId);
        var queryResponse = await connection.ExecuteQueryFirstAsync<PostCommentQueryEntity>(
            getByIdQuery.Sql,
            getByIdQuery.Parameters,
            cancellationToken);
        var postComment = _applicationMapper.Map<PostComment>(queryResponse!);

        return postComment;
    }

    public void Add(PostComment postComment)
    {
        _postsContext
            .PostComments
            .Add(postComment);
    }

    public void Update(PostComment postComment)
    {
        _postsContext
            .PostComments
            .Update(postComment);
    }

    public void Delete(PostComment postComment)
    {
        _postsContext
            .PostComments
            .Remove(postComment);
    }
}
