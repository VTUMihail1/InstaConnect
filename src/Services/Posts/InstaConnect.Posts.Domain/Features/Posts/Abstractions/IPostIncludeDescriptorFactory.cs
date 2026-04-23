using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostIncludeDescriptorFactory
{
    PostsIncludeDescriptor CreateUser();

    PostsIncludeDescriptor CreatePostLikes();

    PostsIncludeDescriptor CreatePostComments();
}
