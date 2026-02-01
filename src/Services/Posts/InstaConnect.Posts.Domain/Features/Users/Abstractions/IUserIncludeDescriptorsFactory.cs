using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Users.Abstractions;

public interface IUserIncludeDescriptorsFactory
{
    PostsIncludeDescriptor CreatePosts();

    PostsIncludeDescriptor CreatePostLikes();

    PostsIncludeDescriptor CreatePostComments();

    PostsIncludeDescriptor CreatePostCommentLikes();
}
