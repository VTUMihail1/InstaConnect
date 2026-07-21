using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.PostLikes.Assertions;

public static class PostLikeMatchAssertions
{
	extension(PostLikeId response)
	{
		public void ShouldSatisfy(AddPostLikeCommand command, PostLike postLike)
		{
			response.ShouldSatisfy(p => p.Matches(command, postLike));
		}
	}

	extension(PostLikeResponse response)
	{
		public void ShouldSatisfy(GetPostLikeByIdQuery query, PostLike postLike)
		{
			response.ShouldSatisfy(p => p.Matches(query, postLike));
		}
	}

	extension(PostLikeCollectionResponse response)
	{
		public void ShouldSatisfy(
		GetAllPostLikesQuery query,
		Post post,
		ICollection<PostLike> postLikes)
		{
			response.ShouldSatisfy(p => p.Matches(query, post, postLikes));
		}

		public void ShouldSatisfy(
			GetAllPostLikesQuery query,
			Post post,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, post, postLikes, termTransformer));
		}

		public void ShouldSatisfy(
		GetAllPostLikesForUserQuery query,
		User user,
		ICollection<PostLike> postLikes)
		{
			response.ShouldSatisfy(p => p.Matches(query, user, postLikes));
		}

		public void ShouldSatisfy(
			GetAllPostLikesForUserQuery query,
			User user,
			ICollection<PostLike> postLikes,
			ISortEnumTermTransformer<PostLike> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(query, user, postLikes, termTransformer));
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
