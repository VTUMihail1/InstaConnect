using InstaConnect.Posts.Domain.Features.PostComments.Helpers;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentIncludeBuilderFactory
{
    PostCommentIncludeBuilder Create();
}
