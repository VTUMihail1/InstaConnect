using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeIncludeDescriptorFactory
{
    PostsIncludeDescriptor CreateUser();

    PostsIncludeDescriptor CreatePost();
}
