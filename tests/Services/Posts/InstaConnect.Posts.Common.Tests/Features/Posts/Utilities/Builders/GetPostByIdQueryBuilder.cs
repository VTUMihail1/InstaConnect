using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetPostByIdQueryBuilder
{
    private readonly ObjectBuilder<GetPostByIdQuery> _objectBuilder;

    public GetPostByIdQueryBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetPostByIdQuery>();

        WithId(PostDataFaker.GetId());
    }

    public GetPostByIdQueryBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetPostByIdQuery>();

        WithId(post.Id);
    }

    public GetPostByIdQueryBuilder WithId(string id)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public GetPostByIdQuery Create()
    {
        return _objectBuilder.Create();
    }
}
