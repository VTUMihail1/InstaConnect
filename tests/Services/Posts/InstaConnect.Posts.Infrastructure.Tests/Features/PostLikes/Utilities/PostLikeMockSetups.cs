using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;

public static class PostLikeMockSetups
{
	extension(IPostLikeCollection collection)
	{
		public void SetupAggregateFluent(
			PostLikeId id,
			IPostLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			IPostLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostLikesFilterQuery filterQuery,
			IPostLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}

		public void SetupAggregateFluent(
			PostLikesForUserFilterQuery filterQuery,
			IPostLikeFluent fluent)
		{
			collection.AggregateFluent().ReturnsResponse(fluent);
		}
	}

	extension(IPostLikeFluent fluent)
	{
		public void SetupGetCountAsync(
			PostLikesFilterQuery filterQuery,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			fluent.GetCountAsync(cancellationToken).ReturnsTaskResponse(postLikes.ToTotalCountResponse(filterQuery));
		}

		public void SetupGetCountAsync(
			PostLikesForUserFilterQuery filterQuery,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			fluent.GetCountAsync(cancellationToken).ReturnsTaskResponse(postLikes.ToTotalCountResponse(filterQuery));
		}

		public void SetupAnyAsync(
			PostLikeId id,
			PostLike? postLike,
			CancellationToken cancellationToken)
		{
			fluent.AnyAsync(cancellationToken).ReturnsTaskResponse(postLike != null);
		}

		public void SetupApplyIncludes(
			PostLikeId id,
			PostLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostLikesFilterQuery filterQuery,
			PostLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostLikesForUserFilterQuery filterQuery,
			PostLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupApplyIncludes(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			PostLikeInclude include)
		{
			fluent.ApplyIncludes(include).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostLikeId id)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostLikeId id,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(id).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostLikesFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(PostLikesForUserFilterQuery filterQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupMatch(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.Match(filterQuery).ReturnsResponse(fluent);
		}

		public void SetupProjectToFullResponse(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			IPostLikeResponseFluent responseFluent)
		{
			fluent.ProjectToFullResponse(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutPost(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostLikeResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutPost(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupProjectToResponseWithoutUser(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			IPostLikeResponseFluent responseFluent)
		{
			fluent.ProjectToResponseWithoutUser(currentUserQuery).ReturnsResponse(responseFluent);
		}

		public void SetupFirstOrDefaultAsync(
			PostLikeId id,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(postLike);
		}
	}

	extension(IPostLikeResponseFluent fluent)
	{
		public void SetupApplySorting(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplySorting(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplySorting(sortingQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupApplyPagination(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			fluent.ApplyPagination(paginationQuery).ReturnsResponse(fluent);
		}

		public void SetupToListAsync(
			PostLikesFilterQuery filterQuery,
			PostLikesSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(postLikes.ToResponse(filterQuery, paginationQuery, currentUserQuery));
		}

		public void SetupToListAsync(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesForUserSortingQuery sortingQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery,
			ICollection<PostLike> postLikes,
			CancellationToken cancellationToken)
		{
			fluent.ToListAsync(cancellationToken).ReturnsTaskResponse(postLikes.ToResponse(filterQuery, paginationQuery, currentUserQuery));
		}

		public void SetupFirstOrDefaultAsync(
			PostLikeId id,
			CurrentUserQuery currentUserQuery,
			PostLike postLike,
			CancellationToken cancellationToken)
		{
			fluent.FirstOrDefaultAsync(cancellationToken).ReturnsTaskResponse(postLike.ToFullResponse(currentUserQuery));
		}
	}
}
