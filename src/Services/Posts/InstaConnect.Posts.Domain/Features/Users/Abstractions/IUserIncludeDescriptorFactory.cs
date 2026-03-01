using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Users.Abstractions;

public interface IUserIncludeDescriptorFactory
{
    PostsIncludeDescriptor CreatePosts();

    PostsIncludeDescriptor CreatePostLikes();

    PostsIncludeDescriptor CreatePostComments();

    PostsIncludeDescriptor CreatePostCommentLikes();
}
