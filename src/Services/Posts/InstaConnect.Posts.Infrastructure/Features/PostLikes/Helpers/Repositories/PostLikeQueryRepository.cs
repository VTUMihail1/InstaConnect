using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;

internal class PostLikeQueryRepository : IPostLikeQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _context;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IPostLikeIncluderFactory _likeIncluderFactory;
    private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
    private readonly IPostLikesSortTermerFactory _likeSortTermerFactory;
    private readonly IPostLikeIncludeBuilderFactory _likeIncludeBuilderFactory;
    private readonly IPostLikesForUserSortTermerFactory _likeForUserSortTermerFactory;

    public PostLikeQueryRepository(
        IPaginator paginator,
        IPostsContext context,
        ISortOrdererFactory sortOrdererFactory,
        IPostLikeIncluderFactory likeIncluderFactory,
        IPostIncludeBuilderFactory includeBuilderFactory,
        IPostLikesSortTermerFactory likeSortTermerFactory,
        IPostLikeIncludeBuilderFactory likeIncludeBuilderFactory,
        IPostLikesForUserSortTermerFactory likeForUserSortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrdererFactory = sortOrdererFactory;
        _likeIncluderFactory = likeIncluderFactory;
        _includeBuilderFactory = includeBuilderFactory;
        _likeSortTermerFactory = likeSortTermerFactory;
        _likeIncludeBuilderFactory = likeIncludeBuilderFactory;
        _likeForUserSortTermerFactory = likeForUserSortTermerFactory;
    }

    public async Task<ICollection<PostLikeResponse>> GetAllAsync(
        PostLikesFilterQuery filter,
        CurrentUserQuery currentUser,
        PostLikesSortingQuery sorting,
        PostLikesPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        var likeInclude = _likeIncludeBuilderFactory.Create().WithUser().Build();

        return await _context
            .PostLikes
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_likeIncluderFactory, likeInclude)
            .Match(filter)
            .ProjectToResponseWithoutPost(currentUser)
            .Sort(_sortOrdererFactory, _likeSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<PostLikeResponse>> GetAllForUserAsync(
        PostLikesForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostLikesForUserSortingQuery sorting,
        PostLikesPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var likeInclude = _likeIncludeBuilderFactory.Create().WithPost(include).Build();

        return await _context
            .PostLikes
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_likeIncluderFactory, likeInclude)
            .Match(filter)
            .ProjectToResponseWithoutUser(currentUser)
            .Sort(_sortOrdererFactory, _likeForUserSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        PostLikesFilterQuery filter,
        CancellationToken cancellationToken)
    {
        var likeInclude = _likeIncludeBuilderFactory.Create().WithUser().Build();

        return await _context
            .PostLikes
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_likeIncluderFactory, likeInclude)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountForUserAsync(
        PostLikesForUserFilterQuery filter,
        CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var likeInclude = _likeIncludeBuilderFactory.Create().WithPost(include).Build();

        return await _context
            .PostLikes
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_likeIncluderFactory, likeInclude)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<PostLikeResponse?> GetByIdAsync(
        PostLikeId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var likeInclude = _likeIncludeBuilderFactory.Create().WithUser().WithPost(include).Build();

        return await _context
            .PostLikes
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_likeIncluderFactory, likeInclude)
            .Match(id)
            .ProjectToFullResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        PostLikeId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostLikes
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
