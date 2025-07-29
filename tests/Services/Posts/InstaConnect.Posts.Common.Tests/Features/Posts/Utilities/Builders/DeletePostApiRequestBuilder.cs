using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class DeletePostApiRequestBuilder
{
    private readonly ObjectBuilder<DeletePostApiRequest> _objectBuilder = new();

    public DeletePostApiRequestBuilder()
    {
        WithId(PostDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
    }

    public DeletePostApiRequestBuilder(Post post)
    {
        WithId(post.Id);
        WithUserId(post.UserId);
    }

    public DeletePostApiRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostApiRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostApiRequest Create()
    {
        return _objectBuilder.Create();
    }
}
