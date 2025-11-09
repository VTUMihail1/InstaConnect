namespace InstaConnect.Posts.Presentation.Tests.Features.Posts.Builders;

public class GetPostByIdApiRequestBuilder
{
    private readonly ObjectBuilder<GetPostByIdApiRequest> _objectBuilder;

    public GetPostByIdApiRequestBuilder(ObjectBuilder<GetPostByIdApiRequest> objectBuilder, Post post)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
    }

    public GetPostByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public GetPostByIdApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
