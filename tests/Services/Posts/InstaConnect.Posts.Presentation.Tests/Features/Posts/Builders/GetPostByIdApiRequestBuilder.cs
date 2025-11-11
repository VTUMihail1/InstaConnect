namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetPostByIdApiRequestBuilder
{
    private string _id;

    public GetPostByIdApiRequestBuilder(Post post)
    {
        _id = post.Id;
    }

    public GetPostByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public GetPostByIdApiRequest Build()
    {
        return new(_id);
    }
}
