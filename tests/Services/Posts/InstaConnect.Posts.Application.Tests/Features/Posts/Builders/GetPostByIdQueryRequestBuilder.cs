using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetPostByIdQueryRequestBuilder
{
    private string _id;

    public GetPostByIdQueryRequestBuilder(Post post)
    {
        _id = post.Id;
    }

    public GetPostByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetPostByIdQueryRequest Build()
    {
        return new(_id);
    }
}
