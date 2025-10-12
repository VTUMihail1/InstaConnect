using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;

internal class PostRepository : IPostRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _postsContext;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IPostCollectionFactory _postCollectionFactory;
    private readonly IPostSortPropertyFactory _postSortPropertyFactory;
    private readonly IPostIncludePropertyFactory _postIncludePropertyFactory;

    public PostRepository(
        IPaginator paginator,
        IPostsContext postsContext,
        ISortOrderFactory sortOrderFactory,
        IPostCollectionFactory postCollectionFactory,
        IPostSortPropertyFactory postSortPropertyFactory,
        IPostIncludePropertyFactory postIncludePropertyFactory)
    {
        _paginator = paginator;
        _postsContext = postsContext;
        _sortOrderFactory = sortOrderFactory;
        _postCollectionFactory = postCollectionFactory;
        _postSortPropertyFactory = postSortPropertyFactory;
        _postIncludePropertyFactory = postIncludePropertyFactory;
    }

    public async Task<PostCollection> GetAllAsync(
        PostFilterQuery filter,
        PostSortingQuery sorting,
        PostPaginationQuery pagination,
        PostIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _postSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _postIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);

        var basePipeline = _postsContext
            .Posts
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => (filter.UserId.IsNullOrEmptyOrWhiteSpace() || p.UserId == filter.UserId) &&
                        (filter.UserName.IsNullOrEmptyOrWhiteSpace() || p.User!.Name == filter.UserName) &&
                        (filter.Title.IsNullOrEmptyOrWhiteSpace() || p.Title == filter.Title));

        var totalCountsResult = await basePipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await basePipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _postCollectionFactory.Create(entities, totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<Post?> GetByIdAsync(
        string id,
        PostIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _postIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
            .Posts
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<Post?> GetByIdAsync(
        string id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(Post entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .Posts
            .AddAsync(_postsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task UpdateAsync(Post entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .Posts
            .UpdateAsync(_postsContext.ClientSessionHandle, x => x.Id == entity.Id, entity, cancellationToken);
    }

    public async Task DeleteAsync(Post entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .Posts
            .DeleteAsync(_postsContext.ClientSessionHandle, x => x.Id == entity.Id, cancellationToken);
    }
}
