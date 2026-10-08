using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Infrastructure.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Infrastructure.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Infrastructure.Tests.Features.PostLikes.Utilities;

public static class PostLikeMapper
{
	extension(PostLike postLike)
	{
		internal PostLikeResponse ToFullResponse(CurrentUserQuery query)
		{
			return new(postLike.Id,
					   postLike.User?.ToFullResponse(),
					   postLike.Post?.ToFullResponse(query),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeResponse ToResponseWithoutUser(CurrentUserQuery query)
		{
			return new(postLike.Id,
					   null,
					   postLike.Post?.ToFullResponse(query),
					   postLike.CreatedAtUtc);
		}

		internal PostLikeResponse ToResponseWithoutPost()
		{
			return new(postLike.Id,
					   postLike.User?.ToFullResponse(),
					   null,
					   postLike.CreatedAtUtc);
		}
	}

	extension(ICollection<PostLike> postLikes)
	{
		public ICollection<PostLikeResponse> ToResponse(
			PostLikesFilterQuery filterQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return postLikes.Filter(paginationQuery, postLike => postLike.MatchesFilter(filterQuery), postLike => postLike.ToResponseWithoutPost());
		}

		public ICollection<PostLikeResponse> ToResponse(
			PostLikesForUserFilterQuery filterQuery,
			PostLikesPaginationQuery paginationQuery,
			CurrentUserQuery currentUserQuery)
		{
			return postLikes.Filter(paginationQuery, postLike => postLike.MatchesFilter(filterQuery), postLike => postLike.ToResponseWithoutUser(currentUserQuery));
		}

		public long ToTotalCountResponse(
			PostLikesFilterQuery filterQuery)
		{
			return postLikes.Count(postLike => postLike.MatchesFilter(filterQuery));
		}

		public long ToTotalCountResponse(
			PostLikesForUserFilterQuery filterQuery)
		{
			return postLikes.Count(postLike => postLike.MatchesFilter(filterQuery));
		}
	}
}
