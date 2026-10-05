using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeMockSetups
{
	extension(IPostCommentLikeCollection collection)
	{
		public void SetupAggregateFluent(
			PostCommentLikeId id,
			IPostCommentLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentLikesFilterQuery filterQuery,
			IPostCommentLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentLikesForUserFilterQuery filterQuery,
			IPostCommentLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IPostCommentLikeFluent fluent)
	{
		public void SetupGetCountAsync(
			PostCommentLikesFilterQuery filterQuery,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			fluent.GetCountAsync(cancellationToken).ReturnsTaskResponse(postCommentLikes.ToTotalCountResponse(filterQuery));
		}

		public void SetupGetCountAsync(
			PostCommentLikesForUserFilterQuery filterQuery,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			fluent.GetCountAsync(cancellationToken).ReturnsTaskResponse(postCommentLikes.ToTotalCountResponse(filterQuery));
		}

		public void SetupAnyAsync(
			PostCommentLikeId id,
			CancellationToken cancellationToken)
		{
			fluent.AnyAsync(cancellationToken).ReturnsTaskResponse(true);
		}

		public void SetupApplyIncludes(
			PostCommentLikeId id,
			PostCommentLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			PostCommentLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostCommentLikeId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostCommentLikesFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostCommentLikesForUserFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupProjectToFullResponse(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutPostComment(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutPostComment(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentLikeResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutUser(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			PostCommentLikeId id,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(postCommentLike);
		}
	}

	extension(IPostCommentLikeResponseFluent fluent)
	{
		public void SetupApplySorting(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplySorting(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			PostCommentLikesFilterQuery filterQuery,
			PostCommentLikesSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(postCommentLikes.ToResponse(filterQuery, paginationQuery, currentUserQuery));
		}

		public void SetupToListAsync(
			PostCommentLikesForUserFilterQuery filterQuery,
			PostCommentLikesForUserSortingQuery sortingQuery,
			PostCommentLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostCommentLike> postCommentLikes,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(postCommentLikes.ToResponse(filterQuery, paginationQuery, currentUserQuery));
		}

		public void SetupFirstOrDefaultAsync(
			PostCommentLikeId id,
			CurrentUserQuery currentUserQuery,
			PostCommentLike postCommentLike,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(postCommentLike.ToFullResponse(currentUserQuery));
		}
	}
}
