using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetPostByIdQueryRequestBuilder
{
    private string _id;

    public GetPostByIdQueryRequestBuilder(Post post)
    {
        _id = post.Id.Id;
    }

    public GetPostByIdQueryRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetPostByIdQueryRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetPostByIdQueryRequest Build()
    {
        return new(_id);
    }
}
