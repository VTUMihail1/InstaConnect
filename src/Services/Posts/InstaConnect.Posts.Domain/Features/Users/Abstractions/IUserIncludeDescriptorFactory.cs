using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Users.Abstractions;

public interface IUserIncludeDescriptorFactory
{
	public PostsIncludeDescriptor CreatePosts();

    public PostsIncludeDescriptor CreatePostLikes();

    public PostsIncludeDescriptor CreatePostComments();

    public PostsIncludeDescriptor CreatePostCommentLikes();
}
