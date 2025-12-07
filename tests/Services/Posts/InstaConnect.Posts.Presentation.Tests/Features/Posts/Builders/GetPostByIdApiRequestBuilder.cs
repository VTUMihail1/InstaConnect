namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetPostByIdApiRequestBuilder
{
    private string _id;

    public GetPostByIdApiRequestBuilder(Post post)
    {
        _id = post.Id.Id;
    }

    public GetPostByIdApiRequestBuilder WithId(Post post, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(post.Id.Id);

        return this;
    }

    public GetPostByIdApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public GetPostByIdApiRequest Build()
    {
        return new(_id);
    }
}
