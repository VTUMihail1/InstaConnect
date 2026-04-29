using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Helpers;

public class PostLikeIncludeDescriptorFactory : IPostLikeIncludeDescriptorFactory
{
	public PostsIncludeDescriptor CreateUser()
	{
		return new(PostsDestinationType.PostLike, PostsIncludeType.User);
	}

	public PostsIncludeDescriptor CreatePost()
	{
		return new(PostsDestinationType.PostLike, PostsIncludeType.Post);
	}
}
