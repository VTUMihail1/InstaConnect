using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetPostByIdApiRequestBuilder
{
    private readonly ObjectBuilder<GetPostByIdApiRequest> _objectBuilder;

    public GetPostByIdApiRequestBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetPostByIdApiRequest>();

        WithId(PostDataFaker.GetId());
    }

    public GetPostByIdApiRequestBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetPostByIdApiRequest>();

        WithId(post.Id);
    }

    public GetPostByIdApiRequestBuilder WithId(string id)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public GetPostByIdApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
