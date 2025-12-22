using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Repositories;

internal class PostCommentRepository : IPostCommentRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _postsContext;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IPostCommentCollectionFactory _postCommentCollectionFactory;
    private readonly IPostCommentSortPropertyFactory _postCommentSortPropertyFactory;
    private readonly IPostCommentIncludePropertyFactory _postCommentIncludePropertyFactory;

    public PostCommentRepository(
        IPaginator paginator,
        IPostsContext postsContext,
        ISortOrderFactory sortOrderFactory,
        IPostCommentCollectionFactory postCommentCollectionFactory,
        IPostCommentSortPropertyFactory postCommentSortPropertyFactory,
        IPostCommentIncludePropertyFactory postCommentIncludePropertyFactory)
    {
        _paginator = paginator;
        _postsContext = postsContext;
        _sortOrderFactory = sortOrderFactory;
        _postCommentCollectionFactory = postCommentCollectionFactory;
        _postCommentSortPropertyFactory = postCommentSortPropertyFactory;
        _postCommentIncludePropertyFactory = postCommentIncludePropertyFactory;
    }

    public async Task<PostCommentCollection> GetAllAsync(
        PostCommentFilterQuery filter,
        CommonSortingQuery<PostCommentSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<PostCommentIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var match = filter.GetFilter();

        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _postCommentSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _postCommentIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var pipeline = _postsContext
            .PostComments
            .Aggregate()
            .Includes(includeProperties)
            .Match(match);
        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _postsContext.PostComments.GetCount(match, cancellationToken);
        var collectionEntities = _postCommentCollectionFactory.Create(entities, totalCount, pagination);

        return collectionEntities;
    }

    public async Task<PostComment?> GetByIdAsync(
        PostCommentId id,
        CommonIncludeQuery<PostCommentIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _postCommentIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
            .PostComments
            .Aggregate()
            .Includes(includeProperties)
            .Match(id.GetFilter())
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<PostComment?> GetByIdAsync(
        PostCommentId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(PostComment entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostComments
            .AddAsync(_postsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<PostComment> entities, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostComments
            .AddRangeAsync(_postsContext.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task UpdateAsync(PostComment entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostComments
            .UpdateAsync(
            _postsContext.ClientSessionHandle,
            entity.Id.GetFilter(),
            entity,
            cancellationToken);
    }

    public async Task DeleteAsync(PostComment entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostComments
            .DeleteAsync(
            _postsContext.ClientSessionHandle,
            entity.Id.GetFilter(),
            cancellationToken);
    }
}
