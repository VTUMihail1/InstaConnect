using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;

internal class PostCommentLikeQueryRepository : IPostCommentLikeQueryRepository
{
	private readonly IPaginator _paginator;
	private readonly IPostsContext _context;
	private readonly ISortOrdererFactory _sortOrdererFactory;
	private readonly IPostIncludeBuilderFactory _includeBuilderFactory;
	private readonly IPostCommentLikeIncluderFactory _commentLikeIncluderFactory;
	private readonly IPostCommentIncludeBuilderFactory _commentIncludeBuilderFactory;
	private readonly IPostCommentLikesSortTermerFactory _commentLikeSortTermerFactory;
	private readonly IPostCommentLikeIncludeBuilderFactory _commentLikeIncludeBuilderFactory;
	private readonly IPostCommentLikesForUserSortTermerFactory _commentLikeForUserSortTermerFactory;

	public PostCommentLikeQueryRepository(
		IPaginator paginator,
		IPostsContext context,
		ISortOrdererFactory sortOrdererFactory,
		IPostIncludeBuilderFactory includeBuilderFactory,
		IPostCommentLikeIncluderFactory commentLikeIncluderFactory,
		IPostCommentIncludeBuilderFactory commentIncludeBuilderFactory,
		IPostCommentLikesSortTermerFactory commentLikeSortTermerFactory,
		IPostCommentLikeIncludeBuilderFactory commentLikeIncludeBuilderFactory,
		IPostCommentLikesForUserSortTermerFactory commentLikeForUserSortTermerFactory)
	{
		_paginator = paginator;
		_context = context;
		_sortOrdererFactory = sortOrdererFactory;
		_includeBuilderFactory = includeBuilderFactory;
		_commentIncludeBuilderFactory = commentIncludeBuilderFactory;
		_commentLikeIncluderFactory = commentLikeIncluderFactory;
		_commentLikeSortTermerFactory = commentLikeSortTermerFactory;
		_commentLikeIncludeBuilderFactory = commentLikeIncludeBuilderFactory;
		_commentLikeForUserSortTermerFactory = commentLikeForUserSortTermerFactory;
	}

	public async Task<ICollection<PostCommentLikeResponse>> GetAllAsync(
		PostCommentLikesFilterQuery filter,
		CurrentUserQuery currentUser,
		PostCommentLikesSortingQuery sorting,
		PostCommentLikesPaginationQuery pagination,
		CancellationToken cancellationToken)
	{
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithUser().Build();

		return await _context
			.PostCommentLikes
			.AggregateWithCaseInsensitiveCollation()
			.Includes(_commentLikeIncluderFactory, commentLikeInclude)
			.Match(filter)
			.ProjectToResponseWithoutPostComment(currentUser)
			.Sort(_sortOrdererFactory, _commentLikeSortTermerFactory, sorting)
			.Paginate(_paginator, pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<PostCommentLikeResponse>> GetAllForUserAsync(
		PostCommentLikesForUserFilterQuery filter,
		CurrentUserQuery currentUser,
		PostCommentLikesForUserSortingQuery sorting,
		PostCommentLikesPaginationQuery pagination,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentLikes().Build();
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithPostComment(commentInclude).Build();

		return await _context
			.PostCommentLikes
			.Aggregate()
			.Includes(_commentLikeIncluderFactory, commentLikeInclude)
			.Match(filter)
			.ProjectToResponseWithoutUser(currentUser)
			.Sort(_sortOrdererFactory, _commentLikeForUserSortTermerFactory, sorting)
			.Paginate(_paginator, pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		PostCommentLikesFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithUser().Build();

		return await _context
			.PostCommentLikes
			.Aggregate()
			.Includes(_commentLikeIncluderFactory, commentLikeInclude)
			.Match(filter)
			.GetCount(cancellationToken);
	}

	public async Task<long> GetTotalCountForUserAsync(
		PostCommentLikesForUserFilterQuery filter,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentLikes().Build();
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithPostComment(commentInclude).Build();

		return await _context
			.PostCommentLikes
			.Aggregate()
			.Includes(_commentLikeIncluderFactory, commentLikeInclude)
			.Match(filter)
			.GetCount(cancellationToken);
	}

	public async Task<PostCommentLikeResponse?> GetByIdAsync(
		PostCommentLikeId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken)
	{
		var include = _includeBuilderFactory.Create().WithUser().WithPostLikes().Build();
		var commentInclude = _commentIncludeBuilderFactory.Create().WithUser().WithPost(include).WithPostCommentLikes().Build();
		var commentLikeInclude = _commentLikeIncludeBuilderFactory.Create().WithUser().WithPostComment(commentInclude).Build();

		return await _context
			.PostCommentLikes
			.Aggregate()
			.Includes(_commentLikeIncluderFactory, commentLikeInclude)
			.Match(id)
			.ProjectToFullResponse(currentUser)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken)
	{
		return await _context
			.PostCommentLikes
			.Aggregate()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
