using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentIncludeDescriptorFactory
{
    PostsIncludeDescriptor CreateUser();

    PostsIncludeDescriptor CreatePost();

    PostsIncludeDescriptor CreatePostCommentLikes();
}
