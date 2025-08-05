using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;

public class AddPostCommentLikeApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostCommentLikeApiRequest> _objectBuilderFactory = new();

    public AddPostCommentLikeApiRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostCommentLikeApiRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public AddPostCommentLikeApiRequestBuilder Create(Post post, PostComment postComment, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostCommentLikeApiRequestBuilder(objectBuilder, post, postComment, user);

        return requestBuilder;
    }
}
