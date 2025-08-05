using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;

public class PostCommentLikeBuilderFactory
{
    private readonly ObjectBuilderFactory<PostCommentLike> _objectBuilderFactory = new();

    public PostCommentLikeBuilder Create(Post post, PostComment postComment, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var entityBuilder = new PostCommentLikeBuilder(objectBuilder, post, postComment, user);

        return entityBuilder;
    }
}
