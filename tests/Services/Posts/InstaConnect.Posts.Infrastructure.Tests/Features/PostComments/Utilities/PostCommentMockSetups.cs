using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.PostComments.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostComments.Utilities;

public static class PostCommentMockSetups
{
	extension(IPostCommentCollection collection)
	{
		public void SetupAggregateFluent(
			PostCommentId id,
			IPostCommentFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			IPostCommentFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentsFilterQuery filterQuery,
			IPostCommentFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostCommentsForUserFilterQuery filterQuery,
			IPostCommentFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IPostCommentFluent fluent)
	{
		public void SetupGetCountAsync(
			PostCommentsFilterQuery filterQuery,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			fluent.GetCountAsync(cancellationToken).ReturnsTaskResponse(postComments.ToTotalCountResponse(filterQuery));
		}

		public void SetupGetCountAsync(
			PostCommentsForUserFilterQuery filterQuery,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			fluent.GetCountAsync(cancellationToken).ReturnsTaskResponse(postComments.ToTotalCountResponse(filterQuery));
		}

		public void SetupAnyAsync(
			PostCommentId id,
			PostComment? postComment,
			CancellationToken cancellationToken)
		{
			fluent.AnyAsync(cancellationToken).ReturnsTaskResponse(postComment != null);
		}

		public void SetupApplyIncludes(
			PostCommentId id,
			PostCommentInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			PostCommentInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostCommentsFilterQuery filterQuery,
			PostCommentInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostCommentInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostCommentId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostCommentId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostCommentsFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostCommentsForUserFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupProjectToFullResponse(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			IPostCommentResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutPost(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutPost(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostCommentResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutUser(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			PostCommentId id,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(postComment);
		}
	}

	extension(IPostCommentResponseFluent fluent)
	{
		public void SetupApplySorting(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplySorting(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			PostCommentsFilterQuery filterQuery,
			PostCommentsSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(postComments.ToResponse(filterQuery, paginationQuery, currentUserQuery));
		}

		public void SetupToListAsync(
			PostCommentsForUserFilterQuery filterQuery,
			PostCommentsForUserSortingQuery sortingQuery,
			PostCommentsPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostComment> postComments,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(postComments.ToResponse(filterQuery, paginationQuery, currentUserQuery));
		}

		public void SetupFirstOrDefaultAsync(
			PostCommentId id,
			CurrentUserQuery currentUserQuery,
			PostComment postComment,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(postComment.ToFullResponse(currentUserQuery));
		}
	}
}
