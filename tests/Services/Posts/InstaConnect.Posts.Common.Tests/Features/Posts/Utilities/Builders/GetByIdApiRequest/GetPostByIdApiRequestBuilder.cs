using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.GetByIdApiRequest;

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
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public GetPostByIdApiRequest Build()
    {
        return _objectBuilder.Build();
    }
}
