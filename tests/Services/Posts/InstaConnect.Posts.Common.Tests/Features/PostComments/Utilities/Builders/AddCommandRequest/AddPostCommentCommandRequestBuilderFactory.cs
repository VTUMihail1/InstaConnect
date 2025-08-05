using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddCommandRequest;

public class AddPostCommentCommandRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostCommentCommandRequest> _objectBuilderFactory = new();

    public AddPostCommentCommandRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostCommentCommandRequestBuilder(objectBuilder);

        return addRequest;
    }

    public AddPostCommentCommandRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var addRequest = new AddPostCommentCommandRequestBuilder(objectBuilder, post, user);

        return addRequest;
    }
}
