using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostIncludeDescriptorFactory
{
    PostsIncludeDescriptor CreateUser();

    PostsIncludeDescriptor CreatePostLikes();

    PostsIncludeDescriptor CreatePostComments();
}
