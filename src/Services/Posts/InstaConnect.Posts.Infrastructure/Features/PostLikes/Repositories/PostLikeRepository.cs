using InstaConnect.Common.Extensions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Repositories;

internal class PostLikeRepository : IPostLikeRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _postsContext;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IPostLikeCollectionFactory _postLikeCollectionFactory;
    private readonly IPostLikeSortPropertyFactory _postLikeSortPropertyFactory;
    private readonly IPostLikeIncludePropertyFactory _postLikeIncludePropertyFactory;

    public PostLikeRepository(
        IPaginator paginator,
        IPostsContext postsContext,
        ISortOrderFactory sortOrderFactory,
        IPostLikeCollectionFactory postLikeCollectionFactory,
        IPostLikeSortPropertyFactory postLikeSortPropertyFactory,
        IPostLikeIncludePropertyFactory postLikeIncludePropertyFactory)
    {
        _paginator = paginator;
        _postsContext = postsContext;
        _sortOrderFactory = sortOrderFactory;
        _postLikeCollectionFactory = postLikeCollectionFactory;
        _postLikeSortPropertyFactory = postLikeSortPropertyFactory;
        _postLikeIncludePropertyFactory = postLikeIncludePropertyFactory;
    }

    public async Task<PostLikeCollection> GetAllAsync(
        PostLikeFilterQuery filter,
        PostLikeSortingQuery sorting,
        PostLikePaginationQuery pagination,
        PostLikeIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var sortOrder = _sortOrderFactory.Create(sorting.Order);
        var sortProperty = _postLikeSortPropertyFactory.Create(sorting.Property);
        var includeProperties = _postLikeIncludePropertyFactory.Create(include?.Properties);
        var offset = _paginator.GetOffset(pagination.Page, pagination.PageSize);
        var isUserNameEmpty = filter.UserName.IsNullOrEmptyOrWhiteSpace();

        var pipeline = _postsContext
            .PostLikes
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == filter.Id &&
                        (isUserNameEmpty || p.User!.Name.StartsWithOrdinalIgnoreCase(filter.UserName)));

        var totalCountsResult = await pipeline.Count().FirstOrDefaultAsync(cancellationToken);

        var entities = await pipeline
            .Sort(sortOrder.Sort(sortProperty.Property))
            .Skip(offset)
            .Limit(pagination.PageSize)
            .ToListAsync(cancellationToken);

        var collectionEntities = _postLikeCollectionFactory.Create(entities, (int)totalCountsResult.Count, pagination);

        return collectionEntities;
    }

    public async Task<PostLike?> GetByIdAsync(
        string id,
        string userId,
        PostLikeIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _postLikeIncludePropertyFactory.Create(include?.Properties);

        var entity = await _postsContext
            .PostLikes
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == id && p.UserId == userId)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<PostLike?> GetByIdAsync(
        string id,
        string userId,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, userId, null, cancellationToken);
    }

    public async Task AddAsync(PostLike entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostLikes
            .AddAsync(_postsContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task UpdateAsync(PostLike entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostLikes
            .UpdateAsync(_postsContext.ClientSessionHandle, x => x.Id == entity.Id && x.UserId == entity.UserId, entity, cancellationToken);
    }

    public async Task DeleteAsync(PostLike entity, CancellationToken cancellationToken)
    {
        await _postsContext
            .PostLikes
            .DeleteAsync(_postsContext.ClientSessionHandle, x => x.Id == entity.Id && x.UserId == entity.UserId, cancellationToken);
    }
}
