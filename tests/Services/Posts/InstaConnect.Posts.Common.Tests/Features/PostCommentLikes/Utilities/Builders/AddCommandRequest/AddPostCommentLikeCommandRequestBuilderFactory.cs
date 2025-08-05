using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.PostCommentLikes.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddCommandRequest;

public class AddPostCommentLikeCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostCommentLikeCommandRequest> _objectBuilderFactory = new();

    public AddPostCommentLikeCommandRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostCommentLikeCommandRequestBuilder(objectBuilder);

        return addRequest;
    }

    public AddPostCommentLikeCommandRequestBuilder Create(Post post, PostComment postComment, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostCommentLikeCommandRequestBuilder(objectBuilder, post, postComment, user);

        return addRequest;
    }
}
