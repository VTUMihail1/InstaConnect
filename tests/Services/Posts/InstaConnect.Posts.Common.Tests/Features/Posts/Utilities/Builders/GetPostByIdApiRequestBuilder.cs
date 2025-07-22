using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class GetPostByIdApiRequestBuilder
{
    private readonly ObjectBuilder<GetPostByIdApiRequest> _objectBuilder = new();

    public GetPostByIdApiRequestBuilder() : this(new PostBuilder().Create())
    {
    }

    public GetPostByIdApiRequestBuilder(Post post)
    {
        WithId(post.Id);
    }

    public GetPostByIdApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public GetPostByIdApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
