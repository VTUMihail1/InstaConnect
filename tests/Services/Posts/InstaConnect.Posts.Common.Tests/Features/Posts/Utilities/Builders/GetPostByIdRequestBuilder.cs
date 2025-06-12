using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetPostByIdRequestBuilder
{
    private readonly ObjectBuilder<GetPostByIdRequest> _objectBuilder;

    public GetPostByIdRequestBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetPostByIdRequest>();

        WithId(PostDataFaker.GetId());
    }

    public GetPostByIdRequestBuilder(Post post)
    {
        _objectBuilder = ObjectBuilderFactory.Build<GetPostByIdRequest>();

        WithId(post.Id);
    }

    public GetPostByIdRequestBuilder WithId(string id)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public GetPostByIdRequestBuilder WithDifferentCaseId(string id)
    {
        _objectBuilder.With(p => p.Id, DataFaker.GetDifferentCaseString(id));

        return this;
    }

    public GetPostByIdRequestBuilder WithInvalidId()
    {
        _objectBuilder.With(p => p.Id, PostDataFaker.GetInvalidId());

        return this;
    }

    public GetPostByIdRequestBuilder WithoutId()
    {
        _objectBuilder.Without(p => p.Id);

        return this;
    }

    public GetPostByIdRequest Create()
    {
        return _objectBuilder.Create();
    }
}
