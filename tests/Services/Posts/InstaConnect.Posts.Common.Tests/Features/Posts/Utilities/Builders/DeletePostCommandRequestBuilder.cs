using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Factories;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;

public class DeletePostCommandRequestBuilder
{
    private readonly ObjectBuilder<DeletePostCommandRequest> _objectBuilder = new();

    public DeletePostCommandRequestBuilder()
    {
        WithId(PostDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
    }

    public DeletePostCommandRequestBuilder(Post post)
    {
        WithId(post.Id);
        WithUserId(post.UserId);
    }

    public DeletePostCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public DeletePostCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public DeletePostCommandRequest Create()
    {
        return _objectBuilder.Create();
    }
}
