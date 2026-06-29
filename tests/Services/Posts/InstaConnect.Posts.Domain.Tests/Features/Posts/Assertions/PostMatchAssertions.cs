using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;

public static class PostMatchAssertions
{
	extension(PostId response)
	{
		public void ShouldSatisfy(Post post, AddPostCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(post, command));
		}

		public void ShouldSatisfy(Post post, UpdatePostCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(post, command));
		}
	}

	extension(PostResponse response)
	{
		public void ShouldSatisfy(Post post, GetPostByIdQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(post, query));
		}
	}

	extension(PostCollectionResponse response)
	{
		public void ShouldSatisfy(
		ICollection<Post> posts,
		GetAllPostsQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(posts, query));
		}

		public void ShouldSatisfy(
			ICollection<Post> posts,
			GetAllPostsQuery query,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(posts, query, termTransformer));
		}

		public void ShouldSatisfy(
		User user,
		ICollection<Post> posts,
		GetAllPostsForUserQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(user, posts, query));
		}

		public void ShouldSatisfy(
			User user,
			ICollection<Post> posts,
			GetAllPostsForUserQuery query,
			ISortEnumTermTransformer<Post> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(user, posts, query, termTransformer));
		}
	}

	extension(Post p)
	{
		public void ShouldSatisfy(AddPostCommand command)
		{
			p.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfy(UpdatePostCommand command)
		{
			p.ShouldSatisfy(p => p.Matches(command));
		}
	}
}
