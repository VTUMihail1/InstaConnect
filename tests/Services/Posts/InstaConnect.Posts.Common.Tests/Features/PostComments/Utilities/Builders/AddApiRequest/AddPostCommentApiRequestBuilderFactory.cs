using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.Builders.AddApiRequest;

public class AddPostCommentApiRequestBuilderFactory
{
    private readonly ObjectBuilderFactory<AddPostCommentApiRequest> _objectBuilderFactory = new();

    public AddPostCommentApiRequestBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostCommentApiRequestBuilder(objectBuilder);

        return requestBuilder;
    }

    public AddPostCommentApiRequestBuilder Create(Post post, User user)
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var requestBuilder = new AddPostCommentApiRequestBuilder(objectBuilder, post, user);

        return requestBuilder;
    }
}
