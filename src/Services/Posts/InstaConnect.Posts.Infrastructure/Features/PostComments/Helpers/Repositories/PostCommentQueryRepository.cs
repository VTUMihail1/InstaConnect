using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Helpers.Repositories;

internal class PostCommentQueryRepository : IPostCommentQueryRepository
{
    private readonly IPaginator _paginator;
    private readonly IPostsContext _context;
    private readonly ISortOrdererFactory _sortOrdererFactory;
    private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
    private readonly IPostCommentIncluderFactory _commentIncluderFactory;
    private readonly IPostCommentsSortTermerFactory _commentSortTermerFactory;
    private readonly IPostCommentIncludeBuilderFactory _commentIncludeBuilderFactory;
    private readonly IPostCommentsForUserSortTermerFactory _commentForUserSortTermerFactory;

    public PostCommentQueryRepository(
        IPaginator paginator,
        IPostsContext context,
        ISortOrdererFactory sortOrdererFactory,
        IPostIncludeBuilderFactory includeBuilderFactory,
        IPostCommentIncluderFactory commentIncluderFactory,
        IPostCommentsSortTermerFactory commentSortTermerFactory,
        IPostCommentIncludeBuilderFactory commentIncludeBuilderFactory,
        IPostCommentsForUserSortTermerFactory commentForUserSortTermerFactory)
    {
        _paginator = paginator;
        _context = context;
        _sortOrdererFactory = sortOrdererFactory;
        _includeBuilderFactory = includeBuilderFactory;
        _commentIncluderFactory = commentIncluderFactory;
        _commentSortTermerFactory = commentSortTermerFactory;
        _commentIncludeBuilderFactory = commentIncludeBuilderFactory;
        _commentForUserSortTermerFactory = commentForUserSortTermerFactory;
    }

    public async Task<ICollection<PostCommentResponse>> GetAllAsync(
        PostCommentsFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentsSortingQuery sorting,
        PostCommentsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().Build();

        return await _context
            .PostComments
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_commentIncluderFactory, commentInclude)
            .Match(filter)
            .ProjectToResponseWithoutPost(currentUser)
            .Sort(_sortOrdererFactory, _commentSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<PostCommentResponse>> GetAllForUserAsync(
        PostCommentsForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentsForUserSortingQuery sorting,
        PostCommentsPaginationQuery pagination,
        CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var commentInclude = _commentIncludeBuilderFactory.Create().WithPost(include).WithPostCommentLikes().Build();

        return await _context
            .PostComments
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_commentIncluderFactory, commentInclude)
            .Match(filter)
            .ProjectToResponseWithoutUser(currentUser)
            .Sort(_sortOrdererFactory, _commentForUserSortTermerFactory, sorting)
            .Paginate(_paginator, pagination)
            .ToListAsync(cancellationToken);
    }

    public async Task<long> GetTotalCountAsync(
        PostCommentsFilterQuery filter,
        CancellationToken cancellationToken)
    {
        var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().Build();

        return await _context
            .PostComments
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_commentIncluderFactory, commentInclude)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<long> GetTotalCountForUserAsync(
        PostCommentsForUserFilterQuery filter,
        CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var commentInclude = _commentIncludeBuilderFactory.Create().WithPost(include).WithPostCommentLikes().Build();

        return await _context
            .PostComments
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_commentIncluderFactory, commentInclude)
            .Match(filter)
            .GetCount(cancellationToken);
    }

    public async Task<PostCommentResponse?> GetByIdAsync(
        PostCommentId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken)
    {
        var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
        var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPostCommentLikes().WithPost(include).Build();

        return await _context
            .PostComments
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_commentIncluderFactory, commentInclude)
            .Match(id)
            .ProjectToFullResponse(currentUser)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        PostCommentId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .PostComments
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }
}
