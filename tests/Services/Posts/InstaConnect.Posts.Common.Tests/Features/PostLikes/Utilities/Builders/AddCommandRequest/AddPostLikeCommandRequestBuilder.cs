using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Common.Tests.Utilities.Types.Strings.Base;
using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddCommandRequest;
public class AddPostLikeCommandRequestBuilder
{
    private readonly ObjectBuilder<AddPostLikeCommandRequest> _objectBuilder;

    public AddPostLikeCommandRequestBuilder(ObjectBuilder<AddPostLikeCommandRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(PostLikeDataFaker.GetId());
        WithUserId(UserDataFaker.GetId());
    }

    public AddPostLikeCommandRequestBuilder(ObjectBuilder<AddPostLikeCommandRequest> objectBuilder, Post post, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(post.Id);
        WithUserId(user.Id);
    }

    public AddPostLikeCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public AddPostLikeCommandRequestBuilder WithUserId(string userId, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.UserId, userId, transformer);

        return this;
    }

    public AddPostLikeCommandRequest Create()
    {
        return _objectBuilder.Create();
    }
}
