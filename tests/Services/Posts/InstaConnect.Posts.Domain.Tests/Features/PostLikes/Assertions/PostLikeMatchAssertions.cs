using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
	extension(PostLikeId response)
	{
		public void ShouldSatisfy(PostLike postLike, AddPostLikeCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(postLike, command));
		}
	}

	extension(PostLikeResponse response)
	{
		public void ShouldSatisfy(PostLike postLike, GetPostLikeByIdQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(postLike, query));
		}
	}

	extension(PostLikeCollectionResponse response)
	{
		public void ShouldSatisfy(
		Post post,
		ICollection<PostLike> postLikes,
		GetAllPostLikesQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(post, postLikes, query));
		}

		public void ShouldSatisfy(
			Post post,
			ICollection<PostLike> postLikes,
			GetAllPostLikesQuery query,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(post, postLikes, query, termTransformer));
		}

		public void ShouldSatisfy(
		User user,
		ICollection<PostLike> postLikes,
		GetAllPostLikesForUserQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(user, postLikes, query));
		}

		public void ShouldSatisfy(
			User user,
			ICollection<PostLike> postLikes,
			GetAllPostLikesForUserQuery query,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(user, postLikes, query, termTransformer));
		}
	}

	extension(PostLike postLike)
	{
		public void ShouldSatisfy(AddPostLikeCommand command)
		{
			postLike.ShouldSatisfy(p => p.Matches(command));
		}
	}
}
