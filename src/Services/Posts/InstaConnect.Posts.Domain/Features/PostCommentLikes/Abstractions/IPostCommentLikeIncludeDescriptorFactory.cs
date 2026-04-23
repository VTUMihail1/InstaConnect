using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeIncludeDescriptorFactory
{
    PostsIncludeDescriptor CreateUser();

    PostsIncludeDescriptor CreatePostComment();
}
