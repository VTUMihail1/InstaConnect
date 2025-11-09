namespace InstaConnect.Posts.Application.Tests.Features.Posts.Builders;

public class GetPostByIdQueryRequestBuilder
{
    private readonly ObjectBuilder<GetPostByIdQueryRequest> _objectBuilder;

    public GetPostByIdQueryRequestBuilder(ObjectBuilder<GetPostByIdQueryRequest> objectBuilder, Post post)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
    }

    public GetPostByIdQueryRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public GetPostByIdQueryRequest Build()
    {
        return _objectBuilder.Build();
    }
}
